using Entities;
using System.Collections.Generic;

namespace Gym.DAL.Interface
{
    public interface IOfficeDAO
    {
        void AddOffice(Office office);
        void DeleteOffice(string Name);
        IEnumerable<Office> GetOffices();
    }
}
