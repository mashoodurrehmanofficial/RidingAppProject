using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using DriverLibrary;
using System.IO.Pipes;
using System.Text.Json;
using System.Text.Json.Serialization;

using RideLibrary;
using System.Reflection.Metadata;

namespace FileHandlerLibrary
{
    public class FileHandler
    {
        private int driverId;
        private string driverFilePath = "Drivers.txt";
        private string dpassengerFilePath = "Passengers.txt";

        public FileHandler()
        {
            this.driverId = 0;
        }
        public int driverid
        {
            get { return driverId; }
            set { driverId = value; }
        }

        public List<Driver> getDriversList()
        {
            List<Driver> driversList = new List<Driver>();


            if(!File.Exists(driverFilePath))
            {
                FileStream fs = new FileStream(driverFilePath, FileMode.Create);
                driverid = 0;
                fs.Close();
            }
            else
            {
                FileStream fs = new FileStream(driverFilePath, FileMode.Open);
                StreamReader  reader = new StreamReader(fs);
                string jsonString = reader.ReadLine();
                if(jsonString != null)
                {
                    driversList = JsonSerializer.Deserialize<List<Driver>>(jsonString);
                } 
                reader.Close();
                fs.Close();
            }

            return driversList;
        }
        public void InsertDiver(ref List<Driver> drivers)
        { 
            FileStream fs = new FileStream(driverFilePath, FileMode.Create);
            StreamWriter writer = new StreamWriter(fs);
            string list = JsonSerializer.Serialize(drivers);
            writer.WriteLine(list);
            writer.Close();
            fs.Close();

        }


        public void AssignDriver(ref Ride r)
        {
             
            FileStream handle;
            if (!File.Exists(dpassengerFilePath))
            {
                handle = new FileStream(dpassengerFilePath, FileMode.Create);
                handle.Close();
            }
            handle = new FileStream(dpassengerFilePath, FileMode.Append);
            StreamWriter writer = new StreamWriter(handle);
            string list = JsonSerializer.Serialize(r);
            writer.WriteLine(list);
            writer.Close();
            handle.Close();
        }
    }
}