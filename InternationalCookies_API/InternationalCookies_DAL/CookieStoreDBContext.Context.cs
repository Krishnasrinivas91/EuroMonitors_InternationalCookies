﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CookieStoreDBContext : DbContext
    {
        public CookieStoreDBContext()
            : base("name=CookieStoreDBContext")
        {
            //this.Configuration.LazyLoadingEnabled = true;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CookieOrder> CookieOrders { get; set; }
        public virtual DbSet<StoreDetail> StoreDetails { get; set; }
    }
}
