using Entities;
using Gym.BLL.Interface;
using Gym.DAL.Interface;
using System;

namespace Gym.BLL.Logic
{
    public class AdministratorLogic : IAdministrator
    {
        private readonly IAdministratorDAO _adminDao;

        public AdministratorLogic(IAdministratorDAO adminDao)
        {
            _adminDao = adminDao;
        }

        public bool AddAdministrator(string name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                var newAdmin = new Administrator { IdAdministrator = new Random().Next(3,2000), Name = name };

                _adminDao.AddAdministrator(newAdmin);

                return true;
            }

            return false;
        }

        public bool DeleteAdministrator(string name)
        {
            if (name != null)
            {
                _adminDao.DeleteAdministrator(name);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
