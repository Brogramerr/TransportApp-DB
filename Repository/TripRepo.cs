using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportApp.Enums;
using TransportApp.Models;

namespace TransportApp.Repository
{
    public class TripRepo
    {
        private  int count = 1;
        private  int myIndex = 0;
        Location location;
        Driver driver = new Driver();

       List<Trip> trips = new List<Trip>();
      // public static Trip[] trips = new Trip[5];


        public TripRepo()
        {
            trips = new List<Trip>();

            string path = @"C:\Users\HI\source\repos\TransportApp\Repository\trips.txt";


            if (File.Exists(path))
            {
                var lines = File.ReadAllLines(@"C:\Users\HI\source\repos\TransportApp\Repository\trips.txt");
                foreach (var line in lines)
                {
                    var trip = Trip.FormatLine(line);
                    trips.Add(trip);
                }
            }
        }

        public bool AddTrip(int id, DateTime startTime, Driver driver, Customer customer, 
            string startLocation, string endLocation, string reference)
        {
           // var trip = new Trip(count, startTime, driver, customer, startLocation, endLocation, reference);

           /* trips[myIndex] = trip;
            myIndex++;*/
            //trips.Add(trip);
           
            //count++;
            Trip trip = new Trip(id, startTime, driver, customer, startLocation, endLocation, reference);
            TextWriter writer = new StreamWriter(@"C:\Users\HI\source\repos\TransportApp\Repository\trips.txt", true);
            writer.WriteLine(trip.ToString());
            writer.Close();
            Console.WriteLine("Trip Succesfully added");
            count++;
            return true;

        }


        public Trip GetTripByReference(string referenceNum)
        {
            for (int i = 0; i < trips.Count; i++)
            {
                if (trips[i].Reference == referenceNum)
                {
                    return trips[i];
                }
            }
            return null;
        }
        public Trip GetAllTrips()
        {
            for (int i = 0; i < trips.Count; i++)
            {
                return trips[i];
            }
            return null;
        }




    }
}
