using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportApp.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Driver Driver;
        public Customer Customer;
        public decimal Price { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public string Reference { get; set; }

        

        public Trip()
        {

        }

        public Trip(int id,DateTime startTime, Driver driver, Customer customer, string startLocation, string endLocation,string reference)
        {
            Id = id;
            StartTime = startTime;
            Customer = customer; 
            StartLocation = startLocation;
            EndLocation = endLocation;
            Reference = reference;
            Driver = driver;
            //Price = price;
        }

        public decimal GetPrice()
        {
            return (EndTime.Ticks - StartTime.Ticks) * (0.001m) ;
        }

        internal static Trip FormatLine(string line)
        {
            var props = line.Split('\t');
          return new Trip(int.Parse(props[0]), DateTime.Parse(props[1]), Driver.FormatLine(props[2]),Customer.FormatLine(props[3]), props[4], props[5], props[6]);
       }
        public override string ToString()
        {
          return $"{Id}\t{StartTime}\t{Driver.FirstName}\t{Customer.FirstName}\t{StartLocation}\t{EndLocation}\t{Reference}";
        }


    }
}
