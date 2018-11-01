using Northwind.Models;
using System.Collections.Generic;

namespace Northwind.BusinessLogic.Interfaces
{
    public interface IOrderLogic
    {
        IEnumerable<OrderList> GetPaginatedOrder(int page, int rows);
        OrderList GetOrderById(int orderId);
        bool Delete(Order entity);
        Order GetById(int orderId);
        string GetOrderNumber(int orderId);
    }
}
