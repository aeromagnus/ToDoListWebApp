using ListingApp.BusinessObjects;
using ListingApp.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListingApp.Infrastructure
{
    public class Mapper
    {
        #region Listing 
        public static toDoListVM convert(toDoList entity)
        {

            if (entity != null)
            {
                toDoListVM record = new toDoListVM
                {
                    toDoListID = entity.toDoListID,
                    Name = entity.Name,
                    CreatedOn = entity.CreatedOn,
                    is_Deleted = Convert.ToBoolean(entity.is_Deleted)
                };
                return record;
            }
            return null;

        }
        public static toDoList convert(toDoListVM data)
        {
            if (data == null)
            {
                return null;
            }
            else
            {
                return new toDoList
                {
                    toDoListID = data.toDoListID,
                    Name = data.Name,
                    CreatedOn = data.CreatedOn,
                    is_Deleted = data.is_Deleted
                };
            }
        }
        public static List<toDoListVM> convert(List<toDoList> entities)
        {
            List<toDoListVM> Result = new List<toDoListVM>();
            foreach (var entity in entities)
            {
                Result.Add(convert(entity));
            }
            return Result;
        }
        public static List<toDoList> convert(List<toDoListVM> data)
        {
            List<toDoList> Result = new List<toDoList>();
            foreach (var vm in data)
            {
                Result.Add(convert(vm));
            }
            return Result;
        }
        #endregion


        #region Users
        public static usersVM convert(users entity)
        {
            if (entity == null)
            {
                return null;
            }
            else
            {
                return new usersVM
                {
                    usersID = entity.usersID,
                    userName = entity.userName,
                    pass = Others.Hashing.hashPassword(entity.password),
                    createdOn = entity.createdOn,
                    is_Deleted= entity.is_Deleted
                };

            }
        }

        public static List<usersVM> convert(List<users> entities)
        {
            List<usersVM> data = new List<usersVM>();
            foreach (var entity in entities)
            {
                var vm = new usersVM();
                vm.usersID = entity.usersID;
                vm.userName = entity.userName;
                vm.pass = Others.Hashing.hashPassword(entity.password);
                //vm.hashedPass = Others.Hashing.hashPassword(entity.password);
                vm.createdOn = entity.createdOn;
                vm.is_Deleted = entity.is_Deleted;
                data.Add(vm);
            }
            return data;

            

        }
        public static users convert(usersVM data)
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
                    password = Others.Hashing.hashPassword(data.pass),
                    //hashedPassword = Others.Hashing.hashPassword(data.pass),
                    createdOn = data.createdOn,
                    is_Deleted = data.is_Deleted
                };
            }
        }
        public static List<users> convert(List<usersVM> Record)
        {
            List<users> Result = new List<users>();
            foreach (var entity in Record)
            {
                Result.Add(convert(entity));
            }
            return Result;
        }
        #endregion
    }
}
