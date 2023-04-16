using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Data;
using System.Threading.Tasks; 
using Microsoft.Data.SqlClient;
using DriverLibrary;
using LocationLibrary;
using VehicleLibrary;
using RideLibrary;

namespace DatabaseHandler
{
    public class DBHandler
    {
        private string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=""New Database"";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        private SqlConnection connection ;
        public DBHandler()
        {
            /*SqlConnection connection = new SqlConnection(connString);
            connection.Open(); */
            /*List<Driver> drivers =  getAllDrivers(); */ 
        }
        
        public List<Driver> getAllDrivers()
        {
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            List<Driver> drivers = new List<Driver>();
            string query = "Select * from drivers";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader dr = cmd.ExecuteReader(); 

            while (dr.Read())
            {

                int Id = Convert.ToInt32(dr["id"]);
                string Name = Convert.ToString(dr["name"]);
                int Age = Convert.ToInt32(dr["age"]);
                string Address  = Convert.ToString(dr["address"]);
                string PhoneNo = Convert.ToString(dr["PhoneNo"]);
                string VehicleType = Convert.ToString(dr["VehicleType"]);
                string VehicleLicensePlate = Convert.ToString(dr["VehicleLicensePlate"]); 
                string VehicleModel = Convert.ToString(dr["VehicleModel"]); 
                int DriverLatitude = Convert.ToInt32(dr["DriverLatitude"]); 
                int DriverLongitude = Convert.ToInt32(dr["DriverLongitude"]); 
                bool Availability = Convert.ToBoolean(dr["Availability"]); 
                string Gender = Convert.ToString(dr["Gender"]); 
                 
                Driver driver = new Driver(dbId:Id);
                /*driver.Id = Id;*/
                driver.Name = Name;
                driver.Age = Age;
                driver.Gender = Gender;
                driver.Address = Address;
                driver.PhoneNo = PhoneNo;
                driver.Availability = Availability;
                driver.DriverLatitude = DriverLatitude;
                driver.DriverLongitude = DriverLongitude;
                driver.vehicleModel = VehicleModel;
                driver.vehicleType = VehicleType;
                driver.vehicleLicensePlate = VehicleLicensePlate; 
                drivers.Add(driver);

            }
            connection.Close();
             
            return drivers;
        }

        public void AddNewDriver(Driver driver)
        {                       
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();  
            string query = @$"INSERT INTO [dbo].[Drivers] ( [Name], [Age], [Address], [PhoneNo], [VehicleType], [VehicleLicensePlate], [VehicleModel], [DriverLatitude], [DriverLongitude], [Availability], [Gender]) VALUES 
                            (N'{driver.Name}', {driver.Age}, N'{driver.Address}', N'{driver.PhoneNo}', N'{driver.vehicleType}',
                            N'{driver.vehicleLicensePlate}', {driver.vehicleModel}, {driver.DriverLatitude}, {driver.DriverLongitude},
                            0, N'{driver.Gender}')";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            connection.Close(); 
        }
        public void updateDriver(Driver driver)
        {
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            string query = @$"update Drivers set 
                            Name='{driver.Name}',Age={driver.Age},Address='{driver.Address}',PhoneNo='{driver.PhoneNo}',vehicleType='{driver.vehicleType}',
                            vehicleLicensePlate='{driver.vehicleLicensePlate}',vehicleModel={driver.vehicleModel},Gender='{driver.Gender}'
                            where id = {driver.Id}";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }



        public void deleteDriver(int id)
        { 
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            string query = @$"delete from Drivers where id = {id}";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            connection.Close(); 
        }

        public void updateLocation(int id,float latitude, float longitude)
        {
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            string query = @$"update Drivers set DriverLatitude={latitude},DriverLongitude={longitude} where id = {id} ";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void updateAvailability(int id, bool availability)
        {
            SqlConnection connection = new SqlConnection(connString);
            int _availability = 0;
            if (availability)
            {
                _availability = 1;  
            }
            connection.Open();
            string query = @$"update Drivers set Availability={_availability} where id = {id} ";
            SqlCommand cmd = new SqlCommand(query, connection);
            /*cmd.ExecuteNonQuery();*/
            object r = cmd.ExecuteNonQuery(); 
            connection.Close();
        }

        public int insertRide(Ride ride)
        {
            Console.WriteLine(ride.Fare);
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            string query = @$"INSERT INTO[dbo].[Rides] ([Fare]) VALUES({ride.Fare}) ";
            SqlCommand cmd = new SqlCommand(query, connection);
            /*cmd.ExecuteNonQuery();*/
            object r = cmd.ExecuteNonQuery(); 
            connection.Close(); 
            return 0;
        }

        public void  insertDriverRating(Ride ride)
        {
            Console.WriteLine(ride.Fare);
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            string query = @$"INSERT INTO [dbo].[Ratings] ( [rating], [driverId]) VALUES ( {ride.Rating}, {ride.Driver.Id} )"; 
            SqlCommand cmd = new SqlCommand(query, connection);
            /*cmd.ExecuteNonQuery();*/
            object r = cmd.ExecuteNonQuery();
            connection.Close(); 
        }



        




        ~DBHandler(){ 
        }
    }
}