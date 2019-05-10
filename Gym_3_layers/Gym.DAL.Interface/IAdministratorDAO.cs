using Entities;
using System.Collections.Generic;

namespace Gym.DAL.Interface
{
    public interface IAdministratorDAO
    {
        void AddAdministrator(Administrator administrator);
        void DeleteAdministrator(string Name);
        IEnumerable<Administrator> GetAdministrators();
    }
}
