using Entities;

namespace Gym.BLL.Interface
{
    public interface IOffice
    {
        bool AddOffice(string Name, string Location);
        bool DeleteOffice(string Name);
    }
}
