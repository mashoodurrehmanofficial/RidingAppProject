using DriverLibrary;
using VehicleLibrary;
using LocationLibrary;
using RideLibrary;
using AdminLibrary;
using System.Collections.Generic;
using FileHandlerLibrary;
using DatabaseHandler;
using System.Reflection.Metadata;
using System.Reflection;


int DisplayMenu()
{
    Console.WriteLine("------------------------------------"); 
    Console.WriteLine("1. Book a Ride");
    Console.WriteLine("2. Enter as Driver");
    Console.WriteLine("3. Enter as Admin");
    Console.WriteLine("4. Exit from App");
    int choice = 0;
    while (choice < 1 || choice > 4)
    {
        Console.Write(" Press 1 to 4 to select an option: ");
        choice = Convert.ToInt32(Console.ReadLine());
    }
    return choice;
}


void startApp()
{

    DBHandler db = new DBHandler();

    List<Driver> driverList = db.getAllDrivers();
    FileHandler fileHandler = new FileHandler();
    /*List<Driver> driverList = fileHandler.getDriversList();*/

    int user_choice = DisplayMenu();
    while (user_choice >= 1 && user_choice <= 3)
    {
        if (user_choice == 1)
        {
            if (driverList.Count == 0)
            {
                Console.WriteLine("** No Rider Available");
            }
            else
            {
                Ride ride = new Ride();
                ride.assignPassenger();
                ride.getLocation();
                int catgery = ride.assignDriver(driverList);
                if (catgery != 0)
                { 
                    ride.calculatePrice();
                    Console.WriteLine("Fare for this ride is: " + ride.Fare);
                    Console.Write("Enter ‘Y’ if you want to Book the ride, enter ‘N’ if you want to cancel operation: ");
                    char ch = 'z';
                    while (ch != 'Y' && ch != 'N')
                    {
                        ch = Console.ReadLine()[0];
                    }
                    if (ch == 'Y')
                    {
                        Console.WriteLine("-> Ride has been Satrted");

                        float rating = ride.giveRating();

                        db.insertDriverRating(ride);

                    }
                    else
                    {
                        Console.WriteLine("** Ride Canceled");
                    }
                }
                else
                {
                    Console.WriteLine("** Rider not Avalible of this category.");
                }
            }
        }
        else if (user_choice == 2)
        {
            Console.Write("Enter ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n Enter Name:");
            string name = Console.ReadLine();
            bool isRegistered = false;
            Driver user = null;
            int index =0;
            /*foreach (var driver in driverList)*/
            foreach (var (driver, i) in driverList.Select((value, i) => (value, i)))
            { 
                if (id == driver.Id && name.ToLower() == driver.Name.ToLower())
                {
                    isRegistered = true;
                    user = driver;
                    index = i; 
                }
            }
            if (isRegistered)
            {
                Console.WriteLine("\n Hello " + user.Name);
                Console.Write("\n Enter your current Location ( , ) :");
                string location = Console.ReadLine();
                location = location.Replace(" ", "");
                string[] points = location.Split(",");
                user.DriverLatitude = float.Parse(points[0]);
                user.DriverLongitude = float.Parse(points[1]);

                db.updateLocation(id: user.Id, latitude: user.DriverLatitude, longitude: user.DriverLongitude);

                driverList[index] = user;
                int choice = 1;
                while (choice == 1 || choice == 2)
                {
                    Console.Write("\n 1) Change availability\n 2) Change Location\n 3) Exit as Driver\n Press 1 to 3 to select an option: ");
                    choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 1)
                    {
                        bool availability = user.updateAvailability();
                        db.updateAvailability(id: user.Id,availability:availability);
                    }
                    else if (choice == 2)
                    {
                        Location loc = user.updateLocation();
                        db.updateLocation(id: user.Id, latitude: loc.Latitude, longitude: loc.Longitude);

                    }

                }
            }
            else
            {
                Console.WriteLine("* You are not Registred in this App as a driver");
            }
        }
        else if (user_choice == 3)
        {
            int ch = 1;
            Admin admin = new Admin(ref driverList);
            while (ch >= 1 && ch <= 4)
            {
                Console.WriteLine("\n 1) Add Driver\n 2) Remove Driver\n 3) Update Driver\n 4) Search Driver\n 5) Exit as Admin");
                Console.Write("\n Press 1 to 5 to select an option: ");
                ch = Convert.ToInt32(Console.ReadLine());
                if (ch == 1)
                {
                    Driver newDriver = admin.AddDriver();
                    db.AddNewDriver(newDriver); 
                }
                else if (ch == 2)
                {
                    int id = admin.deleteDriver();
                    if (id > 0)
                    {
                        db.deleteDriver(id);

                    } 
                }
                else if (ch == 3)
                {
                    Driver driver = admin.updateDriver();
                    db.updateDriver(driver);
                }
                else if (ch == 4)
                {
                    admin.SearchDriver();
                }
            }
        }
        user_choice = DisplayMenu();

    }
}
startApp();