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
    public class CustomerRepo
    {

        List<Customer> customers;

        
        private static int count = 1;
        public CustomerRepo()
        {
            customers = new List<Customer>();

            string path = @"C:\Users\HI\source\repos\TransportApp\Repository\customers.txt";
            
                    
            if (File.Exists(path))
            {
                var lines = File.ReadAllLines(@"C:\Users\HI\source\repos\TransportApp\Repository\customers.txt");
                foreach (var line in lines)
                {
                    var customer = Customer.FormatLine(line);
                    customers.Add(customer);
                }
            }
        }

        public bool AddCustomer(string firstName, string lastName, Gender gender, string password,
        string email, string address, string phoneNo, string nextOfKin, DateTime dob)
        {
            Customer customer = new Customer(count,firstName,lastName, gender, password, email, address, phoneNo, nextOfKin, dob);
            customers.Add(customer);
            TextWriter writer = new StreamWriter(@"C:\Users\HI\source\repos\TransportApp\Repository\customers.txt", true);
            writer.WriteLine(customer.ToString());
            writer.Close();
            customer.Wallet += 1000000000000m;
            Console.WriteLine("Account Succesfully Created");
            count++;
            return true;
        }


        public Customer Login(string email, string password)
        {
            var customer = GetCustomer(email);
            if (customer != null && customer.Password == password)
            {
                return customer;
            }
            return null;
        }
        public Customer GetCustomer(string email)
        {
            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].Email == email)
                {
                    return customers[i];
                }

            }
            return null;
        }

        public void FundWallet(Customer customer)
        {
            Console.Write("Enter Amount you want to credit");
            decimal amount = decimal.Parse(Console.ReadLine());
            customer.Wallet += amount;
            Console.WriteLine($"You Have Successfully Funded Yoor Wallet And Your Balance is {customer.Wallet}");
        }

    }
}
