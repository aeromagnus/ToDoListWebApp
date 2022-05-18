using ListingApp.BusinessObjects;
using ListingApp.DAL.Entity;
using ListingApp.Infrastructure.Interfaces;
using ListingApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListingApp.Infrastructure.Repos
{
    public class usersRepo: IusersRepo
    {
        private readonly crudContext _context;
   

        public usersRepo(crudContext Context)
        {
            _context = Context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    
        public List<usersVM> GetUsers()
         {
            try
            {
                List<usersVM> list = new List<usersVM>();
                return Mapper.convert(_context.users.ToList());
            }
            catch {
                return new List<usersVM>();
            }
        }

        public usersVM GetUsersByID(int userId)
        {
            try
            {
                return Mapper.convert(_context.users.Find(userId));
            }
            catch
            {
                return new usersVM();
            }
        }

        public string InsertUsers(usersVM data)
        {
            try
            {
                users entity = new users();
                //var exisiting = _context.users.Where(x=>x.userName == data.userName).FirstOrDefault();
                //if (exisiting == null)
                //{
                    entity = Mapper.convert(data);
                    entity.createdOn = DateTime.Now;
                    entity.is_Deleted = false;
                    _context.users.Add(entity);
                    _context.SaveChanges();
                    return "Success";
                //}
                //else
                //{
                //    var message = "Couldnot be added due to the existing user" + data.userName;
                //    return message;
                //}
          
            }
            catch (Exception)
            {
                //throw ex.InnerException;
                throw new Exception("Cannot handled simple CRUD Operation!");
            }
        }

        public bool DeleteUsers(int userID)
        {
            try
            {
                var data = _context.users.Find(userID);
                if (data == null)
                {
                    return false;
                }
                else
                {
                    data.is_Deleted = true;
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public void UpdateUsers(usersVM data)
        {
            try 
            {
                var record = Mapper.convert(data);
                var existing = _context.users.Find(data.usersID);
                if (existing != null)
                {
                    _context.Entry(existing).State = EntityState.Detached;
                    _context.users.Attach(record);
                    _context.Entry(record).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            catch 
            { 
                throw null; 
            }
        }
        public string checkpass(string pass)
        {
            try
            {
                return _context.users.Where(x => x.password == pass).ToString();
            }
            catch(Exception ex)
            {
                throw ex.InnerException;
            }
        }
        public string checkusername(string username)
        {
            try
            {
                return _context.users.Where(fucker => fucker.userName == username).ToString();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
