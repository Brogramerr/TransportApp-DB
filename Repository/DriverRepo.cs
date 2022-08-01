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
    public class DriverRepo
    {
        private static int count = 1;
        private static int myIndex = 1;
        Location location = new Location();
        Driver driver = new Driver();
        LocationRepo locationRepo = new LocationRepo();
        private TextWriter textWriter;
        List<Driver> drivers;


        public DriverRepo()
        {
             drivers = new List<Driver>();

            string path = @"C:\Users\HI\source\repos\TransportApp\Repository\drivers.txt";


            if (File.Exists(path))
            {
                var lines = File.ReadAllLines(@"C:\Users\HI\source\repos\TransportApp\Repository\drivers.txt");
                foreach (var line in lines)
                {
                    
                    drivers.Add(driver);
                }
            }
        }


        public bool Register(string firstName, string lastName, Gender gender, string password,
       string email, string address, string phoneNo, string nextOfKin, DateTime dob,string location)
        {
            
            return true;
        }



        public Driver Login(string email, string password)
        {
            var driver = GetDriver(email);
            if (driver != null && driver.Password == password)
            {
                return driver;
            }
            return null;
        }

        public Driver GetDriver(string email)
        {
            foreach (var driver in drivers)
            {
                if (driver.Email == email)
                {
                    return driver;
                }

            }
            return null;
        }

        public Driver GetAvailableDriver(string location)
        {

            foreach (var driver in drivers)
            {
                if (driver != null && driver.DriverLocation == location && driver.Status == Status.Available)
                {
                    return driver;
                }
    
            }
            return null;

        }
        public Driver GetDriverById(int id)
        {
            foreach (var driver in drivers)
            {
                if ((driver != null) && driver.Id == id)
                {
                    return driver;
                }

            }
            return null;
        }

        public void GetDriverWalleBalance(Driver driver)
        {
            Console.WriteLine($" Your Wallet Balance Is {driver.Wallet}");
        }

        public void PrintDrivers(string location)
        {
           var driverProfile = GetAvailableDriver(location);
            Console.WriteLine("ID--------------NAME" );
            Console.WriteLine($"{driverProfile.Id} {driverProfile.FirstName}  ");
        }

        public void GetAllDrivers()
        {
            foreach (var driver in drivers)
            {
                if (driver != null)
                {
                    Console.WriteLine($"{driver.Id} {driver.FullName()} ");
                }

            }
        }


    }
}
