using ListingApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListingApp.Infrastructure.Services
{
    public class usersServices : IusersServices
    {
        private IUnitOfWork _unitOfWork;
        public usersServices(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
        }

        public string getUsername(int userId)
        {
            try
            {
                var userid = _unitOfWork.usersRepo.GetUsersByID(userId).ToString();
                _unitOfWork.Save();
                return userid;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public string checkPassword(string password)
        {
            try
            {
                return _unitOfWork.usersRepo.checkpass(Others.Hashing.hashPassword(password));
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

    }
}
