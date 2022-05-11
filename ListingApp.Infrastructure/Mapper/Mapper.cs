using ListingApp.DAL.Interfaces;
using ListingApp.DAL.unitOfWork;
using ListingApp.DAL;
using ListingApp.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListingApp.Infrastructure.Mapper
{
    public class Mapper
    {
        public static usersDTO ConvertToVM(users entity)
        {
            if (entity == null)
            {
                return null;
            }
            else 
            {
                return new usersDTO 
                { 
                    usersID = entity.usersID,
                    userName = entity.userName,
                    password = entity.password,
                    //hashedPassword - entity.hashedPassword,
                    createdOn  = entity.createdOn
                };
            }
        }
        public static List<usersDTO> ConvertToEntity(List<users> entities)
        { 
        
        }
        public static users ConvertToEntity(usersDTO data)
        {
            if (data == null)
            {
                return null;
            }
            else
            {
                return new users
                {
                    usersID = data.usersID,
                    userName = data.userName,
                    password = data.password,
                    //hashedPassword - entity.hashedPassword,
                    createdOn = data.createdOn
                };
            }
        }
    }
}
