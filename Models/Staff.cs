using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportApp.Enums;

namespace TransportApp.Models
{
    public class Staff:Person
    {
        public string StaffNo { get; set; }
        public Role Role { get; set; }

        public Staff(int id, string firstName, string lastName, Gender gender, string password, string email, string address, string phoneNo, string nextOfKin, DateTime dob, Role role) :
       base(id, firstName, lastName, gender, password, email, address, phoneNo, nextOfKin, dob)
        {
            StaffNo = $"ST{Guid.NewGuid().ToString().Replace("-", " ").Substring(0, 5).ToUpper()}";
            Role = role;
        }

        internal static Staff FormatLine(string line)
        {
            var props = line.Split('\t');
            return new Staff(int.Parse(props[0]), props[1], props[2], (Gender)Enum.Parse(typeof(Gender), props[3]), props[4], props[5], props[6], props[7], props[8], DateTime.Parse(props[9]), (Role)Enum.Parse(typeof(Role), props[10]));
        }
        public override string ToString()
        {
            return $"{Id}\t{FirstName}\t{LastName}\t{Gender}\t{Password}\t{Email}\t{Address}\t{PhoneNo}\t{NextOfKin}\t{DateOfBirth}\t{Role}";
        }
    }
}
