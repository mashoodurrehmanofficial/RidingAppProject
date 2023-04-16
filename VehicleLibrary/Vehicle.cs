using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleLibrary
{
    public class Vehicle
    {
        private string type, model, licensePlate;

        public Vehicle()
        {
            type = "";
            model = "";
            licensePlate = "";
        }

        public Vehicle(string type, string model, string licensePlate)
        {
            this.type = type;
            this.model = model;
            this.licensePlate = licensePlate;
        }
        public string Type
        {
            get { return type; }
            set
            { type = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        } 
        public string LicensePlate
        {
            get { return licensePlate; }
            set { licensePlate = value; }
        } 
    }
}
