using Northwind.BusinessLogic.Interfaces;
using Northwind.Models;
using Northwind.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace Northwind.BusinessLogic.Implementations
{
    public class OrderLogic : IOrderLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool Delete(Order entity)
        {
            return _unitOfWork.Order.Delete(entity);
        }

        public Order GetById(int orderId)
        {
            return _unitOfWork.Order.GetById(orderId);
        }

        public OrderList GetOrderById(int orderId)
        {
            return _unitOfWork.Order.GetOrderById(orderId);
        }

        public IEnumerable<OrderList> GetPaginatedOrder(int page, int rows)
        {
            return _unitOfWork.Order.getPaginatedOrder(page, rows);
        }

        public string GetOrderNumber(int orderId)
        {
            var list = _unitOfWork.Order.GetList();
            if (list == null) return string.Empty;

            var record = list.FirstOrDefault(x => x.Id == orderId);
            return record.OrderNumber;
        }
    }
}
