using Entities;
using Gym.BLL.Interface;
using Gym.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.BLL.Logic
{
    public class OfficeLogic : IOffice
    {
        private readonly IOfficeDAO _officeDao;

        public OfficeLogic(IOfficeDAO officeDao)
        {
            _officeDao = officeDao;
        }

        public bool AddOffice(string name, string location)
        {
            if (!String.IsNullOrEmpty(name))
            {
                var newOffice = new Office { IdOffice = new Random().Next(3, 2000), Name = name, Location = location };

                _officeDao.AddOffice(newOffice);

                return true;
            }

            return false;
        }

        public bool DeleteOffice(string name)
        {
            if (name != null)
            {
                _officeDao.DeleteOffice(name);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
