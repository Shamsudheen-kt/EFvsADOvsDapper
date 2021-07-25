using Microsoft.EntityFrameworkCore;
using Model.EntityModel;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeAllowance>().HasKey(s => new { s.EmployeeId, s.AllowanceId });

            modelBuilder.Entity<CombinedView>()
.ToView(nameof(CombinedView));
        }
        public DbSet<CombinedView> CombinedView { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Allowance> Allowance { get; set; }
        public DbSet<EmployeeAllowance> EmployeeAllowance { get; set; }
        

    }
}
