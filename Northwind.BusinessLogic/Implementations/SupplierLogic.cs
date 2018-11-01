using Northwind.BusinessLogic.Interfaces;
using Northwind.Models;
using Northwind.UnitOfWork;
using System.Collections.Generic;

namespace Northwind.BusinessLogic.Implementations
{
    public class SupplierLogic : ISupplierLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public SupplierLogic(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public bool Delete(Supplier supplier) => _unitOfWork.Supplier.Delete(supplier);

        public Supplier GetById(int id) => _unitOfWork.Supplier.GetById(id);

        public int Insert(Supplier supplier) => _unitOfWork.Supplier.Insert(supplier);

        public IEnumerable<Supplier> SupplierPagedList(int page, int rows, string searchTerm) 
            => _unitOfWork.Supplier.SupplierPagedList(page, rows, searchTerm);

        public bool Update(Supplier supplier) => _unitOfWork.Supplier.Update(supplier);
    }
}
