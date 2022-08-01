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
    public class StaffRepo
    {
        private static int count = 0;
       
        List<Staff> staffs;
        public  decimal CompanyWallet = 0;


        public StaffRepo()
        {
            staffs = new List<Staff>();

            string path = @"C:\Users\HI\source\repos\TransportApp\Repository\staffs.txt";


            if (File.Exists(path))
            {
                var lines = File.ReadAllLines(@"C:\Users\HI\source\repos\TransportApp\Repository\staffs.txt");
                foreach (var line in lines)
                {
                    var staff = Staff.FormatLine(line);
                    staffs.Add(staff);
                }
            }
        }
        public bool AddNewStaff(string fName, string lName, string email, Gender gender, DateTime dateOfBirth,
        string address, string phone, string password, string nextOfKin, Role role)
        {
            Staff staff = new Staff(count, fName, lName, gender, password, email, address, phone, nextOfKin, dateOfBirth,role);
            staffs.Add(staff);
            TextWriter writer = new StreamWriter(@"C:\Users\HI\source\repos\TransportApp\Repository\staffs.txt", true);
            writer.WriteLine(staff.ToString());
            writer.Close();
            Console.WriteLine("Succesfully added");
            count++;
            return true;

        }

        public Staff Login(string email, string password)
        {
            var staff = GetStaff(email);
            if (staff != null && staff.Password == password)
            { 
                return staff;
            }
            return null;
        }

        public Staff GetStaff(string email)
        {
            foreach (var staff in staffs)
            {
                if (staff.Email == email)
                {
                    return staff;
                }
            }
            return null;
        }

        public void GetCompanyWalletBalance()
        {
            Console.WriteLine($"The Amount in the company walllet is {CompanyWallet}") ;
        }
    }
}
