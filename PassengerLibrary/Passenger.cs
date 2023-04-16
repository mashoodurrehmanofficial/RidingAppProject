using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassengerLibrary
{
    public class Passenger
    {
        private string name;
        private string phoneNo;

        public string PhoneNo { get { return phoneNo; } set { phoneNo = value; } }
        public string Name { get { return name; } set { name = value; } }
    }

}
