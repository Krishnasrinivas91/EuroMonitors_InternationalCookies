using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalCookies_DAL.Interfaces
{
    public interface IStoreDetails
    {
        void AddStoreDetails(StoreDetail storeDetails);

        List<StoreDetail> GetStoreDetails();

        StoreDetail GetStoreDetail(int StoreID);                      

    }
}
