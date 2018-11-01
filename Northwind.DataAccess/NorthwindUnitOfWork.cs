using Northwind.Repositories;
using Northwind.UnitOfWork;

namespace Northwind.DataAccess
{
    public class NorthwindUnitOfWork : IUnitOfWork
    {
        public NorthwindUnitOfWork(string connectionString)
        {
            Customer = new CustomerRepository(connectionString);
            User = new UserRepository(connectionString);
            Supplier = new SupplierRepository(connectionString);
            Order = new OrderRepository(connectionString);
        }
        public ICustomerRepository Customer { get; private set; }

        public IUserRepository User { get; private set; }

        public ISupplierRepository Supplier { get; private set; }
        public IOrderRepository Order { get; private set; }
    }
}
