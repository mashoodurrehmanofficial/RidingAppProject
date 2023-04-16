using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocationLibrary;
using VehicleLibrary;
namespace DriverLibrary
{
    public class Driver
    {
        private  int ID;
        private static int _ID;

        private string name;
        private int age;
        private string gender;
        private string address;
        private string phoneNo;
        private bool availability;
        private Location location;
        private Vehicle vehicle;
        private List<float> rating;
        public int Id
        {
            get { return ID; }
            private set { ID = value; }
        }
        public Driver(int dbId = 0)
        { 
            rating = new List<float>();
            vehicle = new Vehicle();
            location = new Location();
             
            if (dbId > 0)
            {
                _ID = dbId;
            }
            else
            {
                _ID++;
            }
            this.Id = _ID; 
        }
        public Driver(string name, int age, string gender, string address, string phoneNo,  Vehicle vehicle,int dbId=0): this(dbId)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
            this.address = address;
            this.phoneNo = phoneNo;
            this.availability = false;
            this.vehicle.Type = vehicle.Type;
            this.vehicle.LicensePlate = vehicle.LicensePlate;
            this.vehicle.Model = vehicle.Model;
            rating = new List<float>();

        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Gender
        {
            set { gender = value; }
            get { return gender; }
        }
        public string Address
        {
            set { address = value; }
            get { return address; }
        }
        public string PhoneNo
        {
            get { return phoneNo; }
            set { phoneNo = value; }
        }

        public string vehicleType
        {
            set { this.vehicle.Type = value; }
            get { return this.vehicle.Type; }
        }
        public string vehicleLicensePlate
        {
            set { this.vehicle.LicensePlate = value; }
            get { return this.vehicle.LicensePlate; }
        }
        public string vehicleModel
        {
            set { this.vehicle.Model = value; }
            get { return this.vehicle.Model; }
        } 
        public List<float> Rating
        {
            get { return rating; }
        }
        public void setRating(float newRating)
        {
            this.rating.Add(newRating);
        }
        public float DriverLatitude
        {
            get { return this.location.Latitude; }
            set { this.location.Latitude = value; }
        }
        public float DriverLongitude
        {
            get { return location.Longitude; }
            set { this.location.Longitude = value; }
        }

        public bool Availability
        {
            get { return availability; }
            set { availability = value; }
        }

        public bool updateAvailability()
        {
            Console.WriteLine("Are you Available ?");
            Console.WriteLine("1) Available");
            Console.WriteLine("2) Unavailable");
            Console.Write("Select option 1 or 2 : ");
            int option = Convert.ToInt32(Console.ReadLine());
            while (option < 1 || option > 2)
            {
                Console.Write("Select option 1 or 2 : ");
                option = Convert.ToInt32(Console.ReadLine());
            } 
            if (option == 1)
                this.availability = true;
            else
                this.availability = false;

            return this.availability;
        }
        public float getRating()
        {
            if (this.rating.Count == 0)
            {
                return 0;
            } 
            return (float)this.rating.Sum() / this.rating.Count;
        }

        public Location updateLocation()
        {
            Console.Write("Enter the latitude: ");
            float latitude = float.Parse(Console.ReadLine());
            Console.Write("Enter the longitude: ");
            float longitude = float.Parse(Console.ReadLine());
            this.location.setLocation(longitude: longitude, latitude: latitude);
            return this.location;
        }
    }
}
