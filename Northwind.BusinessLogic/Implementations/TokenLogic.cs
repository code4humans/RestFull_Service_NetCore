using Northwind.BusinessLogic.Interfaces;
using Northwind.Models;
using Northwind.UnitOfWork;

namespace Northwind.BusinessLogic.Implementations
{
    public class TokenLogic : ITokenLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public TokenLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public User ValidateUser(string email, string password)
        {
            return _unitOfWork.User.ValidateUser(email, password);
        }
    }
}
