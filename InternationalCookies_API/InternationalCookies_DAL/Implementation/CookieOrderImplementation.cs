using InternationalCookies_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalCookies_DAL.Implementation
{
    public class CookieOrderImplementation : ICookieOrders
    {
        public void AddCookieOrder(CookieOrder cookieOrder)
        {
            using (var context = new CookieStoreDBContext())
            {
                context.CookieOrders.Add(cookieOrder);
                context.SaveChanges();
            }
        }

        public List<CookieOrder> GetCookieOrderOfStore(int StoreID)
        {
            using (var context = new CookieStoreDBContext())
            {
                return context.CookieOrders.Where(m => m.StoreID == StoreID).ToList();
            }
        }
    }
}
