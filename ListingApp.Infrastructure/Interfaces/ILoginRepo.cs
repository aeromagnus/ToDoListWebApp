using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListingApp.Infrastructure.Interfaces
{
    public interface ILoginRepo: IDisposable
    {
        string check_username_pass(string username, string pass);
    }
}
