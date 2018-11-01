using Northwind.Models;
using System.Collections.Generic;

namespace Northwind.Repositories
{
    public interface ICustomerRepository:IRepository<Customer>
    {
        IEnumerable<CustomerList> CustomerPagedList(int page, int rows);
    }
}
