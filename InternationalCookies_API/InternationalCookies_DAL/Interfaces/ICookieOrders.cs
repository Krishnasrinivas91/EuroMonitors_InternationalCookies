using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalCookies_DAL.Interfaces
{
    public interface ICookieOrders
    {
        void AddCookieOrder(CookieOrder cookieOrder);

        List<CookieOrder> GetCookieOrderOfStore(int StoreID);
    }
}
