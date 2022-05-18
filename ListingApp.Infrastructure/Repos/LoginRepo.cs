using ListingApp.DAL.Entity;
using ListingApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListingApp.Infrastructure.Repos
{
    public class LoginRepo:ILoginRepo
    {
        public readonly crudContext _context;
        public LoginRepo(crudContext Context)
        {
            _context = Context;
        }

        public string check_username_pass(string username, string pass)
        {

            try
            {
                return _context.users.Where(fucker => fucker.userName == username && fucker.password == pass).ToString();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public void Dispose()
        {
        }
    }
}
