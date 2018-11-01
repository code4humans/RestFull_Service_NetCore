using Northwind.Models;
using System.Collections.Generic;

namespace Northwind.BusinessLogic.Interfaces
{
    public interface ICustomerLogic
    {
        Customer GetById(int id);
        IEnumerable<Customer> GetList();
        IEnumerable<CustomerList> CustomerPagedList(int page, int rows);
        int Insert(Customer customer);
        bool Update(Customer customer);
        bool Delete(Customer customer);
    }
}
