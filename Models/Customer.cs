using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportApp.Enums;

namespace TransportApp.Models
{

    
    public class Customer:Person
    {

        public string CustomerNo { get; set; }
        public decimal Wallet { get; set; }

        public Customer()
        {

        }

        public Customer(int id, string firstName, string lastName, Gender gender, string password, string email, string address, string phoneNo, string nextOfKin, DateTime dob) :
        base(id, firstName, lastName, gender, password, email, address, phoneNo, nextOfKin, dob)
        {
            CustomerNo = $"CUS{Guid.NewGuid().ToString().Replace("-", " ").Substring(0, 5).ToUpper()}";
            Wallet = 0m;
        }
        internal static Customer FormatLine(string line)
        {
            var props = line.Split('\t');
            return new Customer(int.Parse(props[0]), props[1], props[2], (Gender)Enum.Parse(typeof(Gender), props[3]), props[4], props[5], props[6], props[7], props[8], DateTime.Parse(props[9]));
        }
        public override string ToString()
        {
            return $"{Id}\t{FirstName}\t{LastName}\t{Gender}\t{Password}\t{Email}\t{Address}\t{PhoneNo}\t{NextOfKin}\t{DateOfBirth}";
        }


    }
}
