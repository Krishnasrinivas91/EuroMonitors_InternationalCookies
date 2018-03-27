using InternationalCookies_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalCookies_DAL.Implementation
{
    public class StoreDetailsImplementation : IStoreDetails
    {
        public void AddStoreDetails(StoreDetail storeDetails)
        {
            using (var context = new CookieStoreDBContext())
            {
                context.StoreDetails.Add(storeDetails);
                context.SaveChanges();
            }
        }

        public List<StoreDetail> GetStoreDetails()
        {
            using (var context = new CookieStoreDBContext())
            {
                
                return context.StoreDetails.ToList();
            }
        }

        public StoreDetail GetStoreDetail(int StoreID)
        {
            using (var context = new CookieStoreDBContext())
            {
                return context.StoreDetails.FirstOrDefault(m => m.StoreID == StoreID);
            }
        }
    }
}
