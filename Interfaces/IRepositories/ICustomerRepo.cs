using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportApp.Models;

namespace TransportApp.Interfaces.IRepositories
{
    public interface ICustomerRepo
    {

        public int create();

        public bool AddCustomer(string firstName, string lastName, string password,string email, string address, string phoneNo);

        public bool InsertStudent(Customer customer);

      //  public Customer find(string lastName);

        public void Login(string email, string password);

        public void FundWallet(Customer customer);
    }
}
