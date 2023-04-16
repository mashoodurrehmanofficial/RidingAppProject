using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationLibrary
{
    public class Location
    {
        private float latitude;
        private float longitude;
        public Location()
        {
            latitude = 0.0f;
            longitude = 0.0f;
        }

        public Location(float latitude, float longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public void setLocation(float latitude, float longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public float Latitude
        {
            get { return this.latitude; }
            set{ this.latitude = value; }
        }

        public float Longitude
        {
            get { return this.longitude; }
            set { this.longitude = value; }
        }

    }
}
