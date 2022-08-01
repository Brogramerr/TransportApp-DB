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

        Customer create();

        Customer AddCustomer(string firstName, string lastName, string password,string email, string address, string phoneNo);

        Customer InsertStudent(Customer customer);
        IEnumerable<Customer> displayAll();

      //  public Customer find(string lastName);

        public void Login(string email, string password);

        public void FundWallet(Customer customer);
       Customer Get(int id);

    }
}
