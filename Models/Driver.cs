using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportApp.Enums;

namespace TransportApp.Models
{
    public class Driver:Person
    {

        public string DriverNo { get; set; }
        public decimal Wallet { get; set; }
        public string DriverLocation { get; set; }
        public Status Status { get; set; }
        public string CarPlateNumber { get; set; }
        public string CarName { get; set; }
        public string CarColour { get; set; }
        public bool Availability { get; set; }


        public Driver() : base()
        {

        }

        public Driver (int id, string firstName, string lastName, Gender gender, string password, string email, string address, string phoneNo, DateTime dob, string driverLocation, bool availability) :
            base(id, firstName, lastName, gender, password, email, address, phoneNo, dob)
        {
            DriverNo = $"DR{Guid.NewGuid().ToString().Replace("-", " ").Substring(0, 5).ToUpper()}";
            Wallet = 0m;
            DriverLocation = driverLocation;
            Status = Status.Available;
            Availability = availability;
        }

      



    }
}
