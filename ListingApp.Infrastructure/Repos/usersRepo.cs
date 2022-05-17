using ListingApp.BusinessObjects;
using ListingApp.DAL;
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

        public void InsertUsers(usersVM data)
        {
            try
            {
                users entity = new users();
                entity = Mapper.convert(data);
                _context.users.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public void DeleteUsers(int userID)
        {
            users Result = _context.users.Find(userID);
            _context.users.Remove(Result);
        }

        public void UpdateUsers(usersVM Record)
        {

            _context.Entry(Record).State = EntityState.Modified;
        }
        public string checkpass(int userid,string pass)
        {
            return _context.users.Where(x =>x.usersID == userid && x.password == pass).ToString();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
