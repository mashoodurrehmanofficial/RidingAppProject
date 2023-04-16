using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Threading.Tasks;
using DriverLibrary;
using PassengerLibrary;
using LocationLibrary;
using System.Diagnostics;


namespace RideLibrary
{
    public class Ride
    {
        private int fare;
        private float rating;
        private Location startLocation;
        private Location endLocation;
        private Passenger passenger;
        private Driver driver;
        public Ride()
        {

        }


        public Driver Driver
        {
            get { return driver; }
        }

        public int Fare
        {
            get { return fare; }
            set { fare = value; }
        }  
        public float Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        public void getLocation()
        {
            Console.Write("\n Enter Start Location : ");
            string location = Console.ReadLine().Replace(" ", ""); 
            string[] points = location.Split(",");
            startLocation = new Location(longitude: float.Parse(points[1]), latitude: float.Parse(points[0]));

            Console.Write("Enter End Location : ");
            location = Console.ReadLine().Replace(" ", "");
            points = location.Split(",");
            endLocation = new Location(longitude: float.Parse(points[1]), latitude: float.Parse(points[0]));
        }


        public int assignDriver(List<Driver> driverList)
        {
            bool flag = true;
            int category = 0;
            List<Driver> templist = new List<Driver>();
            while (flag)
            {
                Console.Write("Enter Ride Type ( 1.Car, 2.Rickshaw, 3.Bike ): ");
                string type = Console.ReadLine().Replace(" ", ""); 
                if (type.ToLower() == "car")
                {
                    category = 1;
                    flag = false;
                    foreach (var driver in driverList)
                    {
                        if (driver.Availability == true && driver.vehicleType.ToLower() == "car")
                        {
                            templist.Add(driver);
                        }
                    }
                }
                else if (type.ToLower() == "rickshaw")
                {
                    category = 2;
                    flag = false;
                    foreach (var driver in driverList)
                    {
                        if (driver.Availability == true && driver.vehicleType.ToLower() == "rickshaw")
                        {
                            templist.Add(driver);
                        }
                    }
                }
                else if (type.ToLower() == "bike")
                {
                    category = 3;
                    flag = false;
                    foreach (var driver in driverList)
                    {
                        if (driver.Availability == true && driver.vehicleType.ToLower() == "bike")
                        {
                            templist.Add(driver);
                        }
                    }
                }
            }

            // if selected category driver is not avaliable 
            if (templist.Count == 0)
            {
                return 0;
            }

            int id = CalculateNearestDistance(templist); 
            int i = 0;
            foreach (var driver in driverList)
            {
                if (driver.Id == id)
                {
                    this.driver = driver;
                }
                i++;
            }
            return category; 
        }


        private int CalculateNearestDistance(List<Driver> list)
        {

            int minID = 0;
            double minDistance = -1; // if rider and driver at same point
            foreach (var driver in list)
            {
                var dx = driver.DriverLatitude - startLocation.Latitude;
                var dy = driver.DriverLongitude - startLocation.Longitude;
                double x = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
                if (minDistance == -1)
                {
                    minDistance = x;
                    minID = driver.Id;
                }
                else if (x < minDistance)
                {
                    minDistance = x;
                    minID = driver.Id;
                }
            }
            return minID;
        }
        public void assignPassenger()
        {
            passenger = new Passenger();
            Console.Write("Enter Name: ");
            string nam = Console.ReadLine();
            passenger.Name = nam;
            Console.Write("Enter Phone No: ");
            string num = Console.ReadLine();

            while ((num.Length != 11 || !num.All(char.IsDigit)))
            {
                Console.Write("Enter Phone No: ");
                num = Console.ReadLine();
            }

            passenger.PhoneNo = num;
        }




        public void calculatePrice()
        {
            double commission = 0.0;
            int fuelPrice = 266;
            int avgFuel = 1;
            if (driver.vehicleType.ToLower() == "bike")
            {
                commission = 5;
                avgFuel = 50;
            }
            else if (driver.vehicleType.ToLower() == "rickshaw")
            {
                commission = 10;
                avgFuel = 35;
            }
            else if (driver.vehicleType.ToLower() == "car")
            {
                commission = 20;
                avgFuel = 15;
            }

            var dx = endLocation.Latitude - startLocation.Latitude;
            var dy = endLocation.Longitude - startLocation.Longitude;
            int distance = (int)Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
            // commission formula 
            commission = (((distance * fuelPrice) / avgFuel) * commission) / 100;
            // total price formula
            int price = (int)(((distance * fuelPrice) / avgFuel) + commission);
            fare = price;
        }
        public float giveRating()
        {
            Console.Write("Leave a rating out of 5:  ");
            float rating = float.Parse(Console.ReadLine());
            while (rating < 1 || rating > 5)
            {
                Console.Write("Leave a rating out of 5 : ");
                rating = float.Parse(Console.ReadLine());
            }
            this.Rating = rating;
            this.driver.setRating(rating);
            return rating;

        }
        ~Ride()
        {
            driver = null;
        }
    }
}
