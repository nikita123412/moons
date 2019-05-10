using Entities;

namespace Gym.BLL.Interface
{
    public interface IAdministrator
    {
        bool AddAdministrator(string Name);
        bool DeleteAdministrator(string Name);
    }
}
