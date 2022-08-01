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
    public class CustomerRepo: ICustomerRepo
        

    {


        static string path = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        
     
        MySqlConnection connection = new MySqlConnection(path);


        
        public void Create()
        {

            try
            {
                using (connection)
                {
                    MySqlCommand command = new MySqlCommand("create table customer (id int not null auto_increment key,firstName varchar(200),lastName varchar(200),Gender varchar(30),password varchar(200),email varchar(100),address varchar(500),phoneNo varchar(200),DateofBirth varchar(40))", connection);
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



        public void AddCustomer(string firstName, string lastName,Gender gender, string password,
        string email, string address, string phoneNo,DateTime dob)
        {
            var customer = new Customer(firstName,lastName,gender,password,email,address,phoneNo,dob);
            InsertStudent(customer);
            Console.WriteLine("Successfull");
           
            
        }

        public void InsertStudent(Customer customer)
        {
            try
            {
               Create();

                using (MySqlConnection connection = new MySqlConnection(path))
                {
                   
                    MySqlCommand command = new MySqlCommand($"insert into customer(firstName, lastName,gender, password, email, address, phoneNo,DateofBirth) value('{customer.FirstName}', '{customer.LastName}','{customer.Gender}' ,' {customer.Password} ', ' {customer.Email} ', ' {customer.Address} ', ' {customer.PhoneNo}', '{customer.DateOfBirth}')", connection);
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

        public List <Customer> ListAllCustomers()
        {
           List <Customer> customer = new List<Customer>();

            try
            {
                var sql = "select * from customer";
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
                    var customers = new Customer(fName, lName, pass, mail, address, phone);
                    customer.Add(customers);

                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            return customer;

        }

        public void PrintAllCustomers()
        {
            var customers = ListAllCustomers();
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.Id}" );
            }
        }

        public Customer Login(string email, string password)
        {
            Customer customer = null;
            try
            {
                var sql = "select firstName,lastName,gender,password,email,address,phoneNo,DateofBirth from customer where email = '" + email + "'";
                MySqlCommand command = new MySqlCommand(sql, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string fName = reader.GetString(0);
                    string lName = reader.GetString(1);
                    Gender gender = (Gender)Enum.Parse(typeof(Gender),reader.GetString(2));
                    string pass = reader.GetString(3);
                    string mail = reader.GetString(4);
                    string address = reader.GetString(5);
                    string phone = reader.GetString(6);
                    DateTime dob = DateTime.Parse(reader.GetString(7));
                    customer = new Customer(fName, lName,gender, pass, mail, address, phone,dob);

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

        public Customer create()
        {
            throw new NotImplementedException();
        }



        Customer ICustomerRepo.AddCustomer(string firstName, string lastName, string password, string email, string address, string phoneNo)
        {
            throw new NotImplementedException();
        }

        Customer ICustomerRepo.InsertStudent(Customer customer)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Customer> ICustomerRepo.displayAll()
        {
            throw new NotImplementedException();
        }

        void ICustomerRepo.Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
