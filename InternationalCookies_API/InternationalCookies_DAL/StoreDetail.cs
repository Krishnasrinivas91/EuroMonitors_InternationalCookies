//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InternationalCookies_DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class StoreDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StoreDetail()
        {
            this.CookieOrders = new HashSet<CookieOrder>();
        }
    
        public int StoreID { get; set; }
        public string StoreName { get; set; }
        public string StoreLocation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<CookieOrder> CookieOrders { get; set; }
    }
}
