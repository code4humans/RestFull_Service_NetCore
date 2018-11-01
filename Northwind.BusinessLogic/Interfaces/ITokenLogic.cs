using Northwind.Models;

namespace Northwind.BusinessLogic.Interfaces
{
    public interface ITokenLogic
    {
        User ValidateUser(string email, string password);
    }
}
