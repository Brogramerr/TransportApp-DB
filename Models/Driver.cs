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

        public Driver() : base()
        {

        }

        public Driver (int id, string firstName, string lastName, Gender gender, string password, string email, string address, string phoneNo, string nextOfKin, DateTime dob, string driverLocation) :
            base(id, firstName, lastName, gender, password, email, address, phoneNo, nextOfKin, dob)
        {
            DriverNo = $"DR{Guid.NewGuid().ToString().Replace("-", " ").Substring(0, 5).ToUpper()}";
            Wallet = 0m;
            DriverLocation = driverLocation;
            Status = Status.Available;
        }

        internal static Driver FormatLine(string line)
        {
            var props = line.Split('\t');
            var id = int.Parse(props[0]);
            var firstName = props[1];
            var lastName = props[2];
            var gender = (Gender)Enum.Parse(typeof(Gender), props[3]);
            var password = props[4];
            var email = props[5];
            var address = props[6];
            var phoneNo = props[7];
            var nextOfKin = props[8];
            var dob = DateTime.Parse(props[9]);
            var driverLocation = props[10];

            return new Driver(id,firstName,lastName,gender,password,email,address,phoneNo,nextOfKin,dob,driverLocation);
        }
        public override string ToString()
        {
            return $"{Id}\t{FirstName}\t{LastName}\t{Gender}\t{Password}\t{Email}\t{Address}\t{PhoneNo}\t{NextOfKin}\t{DateOfBirth}\t{DriverLocation}";
        }



    }
}
