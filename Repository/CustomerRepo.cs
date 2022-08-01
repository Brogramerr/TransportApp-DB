using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportApp.Enums;
using TransportApp.Interfaces.IRepositories;
using TransportApp.Models;

namespace TransportApp.Repository
{
    public class CustomerRepo 
    {
        static string path = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        
     
        MySqlConnection connection = new MySqlConnection(path);


        
        public void Create()
        {

            try
            {
                using (connection)
                {
                    MySqlCommand command = new MySqlCommand("create table customer (id int not null auto_increment key,firstName varchar(200),lastName varchar(200),password varchar(200),email varchar(100),address varchar(500),phoneNo varchar(200))", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Customer Table Created Successfully");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOP's , Something Went Wrong", e.Message);

            }
        }



        public void AddCustomer(string firstName, string lastName, string password,
        string email, string address, string phoneNo)
        {
            var customer = new Customer(firstName,lastName,password,email,address,phoneNo);
            InsertStudent(customer);
            Console.WriteLine("Successfull");
           
            
        }

        public void InsertStudent(Customer customer)
        {
            try
            {
               //Create();

                using (MySqlConnection connection = new MySqlConnection(path))
                {
                   
                    MySqlCommand command = new MySqlCommand($"insert into customer(firstName, lastName, password, email, address, phoneNo) value('{customer.FirstName}', '{customer.LastName}', ' {customer.Password} ', ' {customer.Email} ', ' {customer.Address} ', ' {customer.PhoneNo}')", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Successful");
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, Somethinge Went Wrong", e);

            }
        }

        public void displayAll()
        {
            List<Customer> customers = getAll();
            foreach (Customer customer in customers)
            {
                Console.WriteLine($"{customer.Id}, {customer.FullName()}, {aircraft.getType()}, {aircraft.getCapacity()}, {aircraft.getManufacturer()}, {aircraft.getCruiseSpeed()}");
            }
        }


        public Customer Login(string email, string password)
        {
            Customer customer = null;
            try
            {
                var sql = "select firstName,lastName,password,email,address,phoneNo from customer where email = '" + email + "'";
                MySqlCommand command = new MySqlCommand(sql, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.FieldCount != 0)
                {
                    reader.Read();
                    var fName = reader.GetString(0);
                    var lName = reader.GetString(1);
                    string pass = reader.GetString(2);
                    string mail = reader.GetString(3);
                    string address = reader.GetString(4);
                    string phone = reader.GetString(5);
                    customer = new Customer(fName, lName, pass, mail, address, phone);

                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            return customer;
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
