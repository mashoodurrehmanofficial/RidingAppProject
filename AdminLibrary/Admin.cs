using DriverLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleLibrary;

namespace AdminLibrary
{
    public class Admin
    {
        private List<Driver> driversList ;
        
        public Admin(ref List<Driver> driversList) {
      
            this.driversList = driversList;
        }

        public int deleteDriver()
        {

            Console.Write("Enter ID: ");
            bool flag = false;
            int id = Convert.ToInt32(Console.ReadLine());
            for (int j = 0; j < driversList.Count(); j++)
            {
                if (driversList[j].Id == id)
                {
                    driversList.RemoveAt(j);
                    flag = true;
                    return id; 
                }
            }
            if (!flag)
            {
                Console.WriteLine("* Driver Not Found");
            }
            return -1;
        }


        public Driver AddDriver()
        {
            bool flag = true;
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            int age = 0;
            while (age <= 0)
            {
                Console.Write("Enter Age: ");
                age = Convert.ToInt32(Console.ReadLine());
            }

            Console.Write("Enter Phone No: ");
            string num = Console.ReadLine();
            while ((num.Length != 11 || !num.All(char.IsDigit)))
            {
                Console.Write("Enter Phone No: ");
                num = Console.ReadLine();
            }
            string gender = "";
            while (flag)
            {
                Console.Write("Enter Gender: ");
                gender = Console.ReadLine();
                gender = gender.Replace(" ", "");
                if (gender.ToLower() == "male" || gender.ToLower() == "female")
                {
                    flag = false;
                }
            }

            Console.Write("Enter Address: ");
            string address = Console.ReadLine();

            flag = true;
            string type = "";
            while (flag)
            {
                Console.Write("Enter Vehicle Type: ");
                type = Console.ReadLine().Replace(" ", "");
                if (type.ToLower() == "car")
                {
                    flag = false;

                }
                else if (type.ToLower() == "rickshaw")
                {
                    flag = false;

                }
                else if (type.ToLower() == "bike")
                {
                    flag = false;

                }
            }
            flag = true;
            string model = "";
            while (flag)
            {
                Console.Write("Enter Vehicle Model: ");
                model = Console.ReadLine();
                if (model != "" && model.All(char.IsDigit) && model.Length == 4)
                {
                    flag = false;
                }
            }

            flag = false;
            string plate = "";
            while (!flag)
            {
                flag = true;
                Console.Write("Enter Vehicle License Plate: ");
                plate = Console.ReadLine();
                string temp = plate.ToLower();
                if (plate.Length == 8)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        if ((i >= 0 && i <= 2) && (temp[i] >= 'a' && temp[i] <= 'z'))
                        {

                        }
                        else if (i == 3 && temp[i] == ' ')
                        {

                        }
                        else if ((i >= 4 && i <= 7) && (temp[i] >= '0' && temp[i] <= '9'))
                        {

                        }
                        else
                        {
                            flag = false;
                        }
                    }
                }
                else
                {
                    flag = false;
                }
            }

            Vehicle s = new Vehicle(type: type, model: model, licensePlate: plate);
            Driver newDriver = new Driver(name: name, age: Convert.ToInt32(age), address: address, phoneNo: num, vehicle: s, gender: gender);
            driversList.Add(newDriver);
            return newDriver;
        }

        public Driver updateDriver()
        {
                Driver tempDriver = new Driver();

            if (driversList.Count == 0)
            {
                Console.WriteLine("** No Driver Found");
                return tempDriver;
            }
            int id = 0;
            while (id <= 0)
            {
                Console.Write("Enter Driver ID: ");
                id = Convert.ToInt32(Console.ReadLine());
            }
            for (int j = 0; j < driversList.Count(); j++)
            {
                if (driversList[j].Id == id)
                {
                    Console.WriteLine($"\n-------------Driver with ID  {driversList[j].Id} exists-------------\n");
                    Console.Write("\n Enter Name: ");
                    string name = Console.ReadLine();
                    if (name != "")
                    {
                        driversList[j].Name = name;
                    }
                    bool flag = true;
                    string age = "";
                    while (flag)
                    {
                        Console.Write("\n Enter Age: ");
                        age = Console.ReadLine();
                        if (age != "" && age.All(char.IsDigit))
                        {
                            flag = false;
                            driversList[j].Age = Convert.ToInt32(age);
                        }
                        if (age == "")
                        {
                            flag = false;
                        }
                    }
                    flag = true;
                    string gender = "";
                    while (flag)
                    {
                        Console.Write("\n Enter Gender: ");
                        gender = Console.ReadLine();
                        gender = gender.Replace(" ", "");
                        if (gender != "" && (gender.ToLower() == "male" || gender.ToLower() == "female"))
                        {
                            flag = false;
                            driversList[j].Gender = gender;
                        }
                        if (gender == "")
                        {
                            flag = false;
                        }
                    }
                    flag = true;
                    string type = "";
                    while (flag)
                    {
                        Console.Write("\n Enter Vehicle Type: ");
                        type = Console.ReadLine();
                        type = type.Replace(" ", "");
                        if (type != "" && type.ToLower() == "car")
                        {
                            flag = false;
                            driversList[j].vehicleType = type;

                        }
                        else if (type != "" && type.ToLower() == "rickshaw")
                        {
                            flag = false;
                            driversList[j].vehicleType = type;
                        }
                        else if (type != "" && type.ToLower() == "bike")
                        {
                            flag = false;
                            driversList[j].vehicleType = type;

                        }
                        if (type == "")
                        {
                            flag = false;
                        }
                    }
                    flag = true;
                    string model = "";
                    while (flag)
                    {
                        Console.Write("\n Enter Vehicle Model: ");
                        model = Console.ReadLine();
                        if (model != "" && model.All(char.IsDigit) && model.Length == 4)
                        {
                            flag = false;
                            driversList[j].vehicleModel = model;
                        }
                        if (model == "")
                        {
                            flag = false;
                        }
                    }
                    flag = false;
                    string plate = "";
                    while (!flag)
                    {
                        flag = true;
                        Console.Write("\n Enter Vehicle License Plate: ");
                        plate = Console.ReadLine();
                        string temp = plate.ToLower();
                        if (plate.Length == 8)
                        {
                            for (int i = 0; i < 8; i++)
                            {
                                if ((i >= 0 && i <= 2) && (temp[i] >= 'a' && temp[i] <= 'z'))
                                {

                                }
                                else if (i == 3 && temp[i] == ' ')
                                {

                                }
                                else if ((i >= 4 && i <= 7) && (temp[i] >= '0' && temp[i] <= '9'))
                                {

                                }
                                else
                                {
                                    flag = false;
                                }
                            }
                            if (flag)
                            {
                                driversList[j].vehicleLicensePlate = plate;
                                return driversList[j];
                            }
                        }
                        else if (plate == "")
                        {
                            return driversList[j];
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    return driversList[j];
                }

                return driversList[j];
            }
            Console.WriteLine("\n Driver with this ID does not exist !!!!");
            return tempDriver;

        }

        public void SearchDriver()
        {
            bool flag = true;
            int count = 0;
            string id = "";
            Console.Write("Enter ID: ");
            id = Console.ReadLine();  
            Console.Write("Enter Name: ");
            string name = Console.ReadLine(); 
            string age = "";
            Console.Write("Enter Age: ");
            age = Console.ReadLine(); 
            Console.Write("Enter Gender: ");
            string gender = Console.ReadLine();
            Console.Write("Enter Address: ");
            string address = Console.ReadLine();
             
            string type = "";
            Console.Write("Enter Vehicle Type: ");
            type = Console.ReadLine();
            type = type.Replace(" ", ""); 
            string model = "";
            Console.Write("Enter Vehicle Model: ");
            model = Console.ReadLine();
            
            Console.Write("Enter Vehicle License Plate: ");
            string plate = Console.ReadLine(); 
       
            List<Driver> validDrivers = new List<Driver>{ };
            foreach (var driver in driversList)
            {
                flag = true;

                if (id == "" || (id != "" && id.All(char.IsDigit) && id == Convert.ToString(driver.Id)))
                {
                } 
                else
                {
                    flag = false;
                }
                if (name=="" || Convert.ToString(driver.Name).ToLower().Contains(name.ToLower()))
                {
                }
                else
                {
                    flag = false;
                }
                if (age=="" ||(age != "" && age.All(char.IsDigit) && age == Convert.ToString(driver.Age)))
                {
                }
                else
                {
                    flag = false;
                }
                if (gender=="" || (Convert.ToString(driver.Gender)).ToLower().Contains(gender.ToLower()))
                {
                }
                else
                {
                    flag = false;
                }
                if (type=="" || (Convert.ToString(driver.vehicleType)).ToLower().Contains(type.ToLower()))
                {
                }
                else
                {
                    flag = false;
                }
                if (model=="" || model != "" && model.All(char.IsDigit) && model == Convert.ToString(driver.vehicleModel))
                {
                }
                else
                {
                    flag = false;
                }
                if (plate=="" || (Convert.ToString(driver.vehicleLicensePlate)).ToLower().Contains(plate.ToLower()))
                {
                }
                else
                {
                    flag = false;
                }

                if (flag==true)
                {
                    count++;
                    validDrivers.Append(driver);
                    Console.WriteLine($"ID: {driver.Id}");
                    Console.WriteLine($"Name: {driver.Name}");
                    Console.WriteLine($"Age: {driver.Age}");
                    Console.WriteLine($"Gender: {driver.Gender}");
                    Console.WriteLine($"V.Type: {driver.vehicleType}");
                    Console.WriteLine($"V.Model: {driver.vehicleModel}");
                    Console.WriteLine($"V.License: {driver.vehicleLicensePlate}");
                    Console.WriteLine("--------------------------------------------------------------------------------------------------------\n");

                } 
            } 
            if (count <1)
            { 
                Console.WriteLine("* No Driver Match");
            }
             

        }


    }
}
