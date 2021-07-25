using Dapper;
using DataAccess.Data;
using DataAccess.Repository.Abstract;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Model.EntityModel;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace DataAccess.Repository
{
    public class HomeRepository : IHomeRepository
    {
        private readonly AppDbContext Context;
        private readonly AppSettings appSettings;
        public HomeRepository(AppDbContext _Context, IOptions<AppSettings> _appSettings)
        {
            Context = _Context;
            appSettings = _appSettings.Value;
        }
       
        public IList<HomeDTO> GetPerfomanceDetails()
        {
            List<HomeDTO> objList = new List<HomeDTO>();

            var item_Join = new HomeDTO();
            item_Join.HeaderName = "Join Multiple Tables";
            item_Join.TakenTime_EF = EfJoin();
            item_Join.TakenTime_ADO = AdoJoin();
            item_Join.TakenTime_Dapper = DapperJoin();
            item_Join.TakenTime_EFwithSP = EfJoinSp();

            var item_Single = new HomeDTO();
            item_Single.HeaderName = "Single Table";
            item_Single.TakenTime_EF = EfSingle();
            item_Single.TakenTime_Dapper = DapperSingle();
            item_Single.TakenTime_ADO = AdoSingle();
            item_Single.TakenTime_EFwithSP = EfSingleSp();

            var item_Bulk = new HomeDTO();
            item_Bulk.HeaderName = "Bulk Data Retrieve";
            item_Bulk.TakenTime_ADO = AdoBulk();
            item_Bulk.TakenTime_EF = EfBulk();
            item_Bulk.TakenTime_Dapper = DapperBulk();
            item_Bulk.TakenTime_EFwithSP = EfBulkSp();

            objList.Add(item_Single);
            objList.Add(item_Join);
            objList.Add(item_Bulk);

            return objList;

        }
       
        //---------------------Entity Framework-----------------//
        public long EfSingle()
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();
            var EmployeeEf = Context.Employee.Where(i => i.Active ==true).ToList();
            watch.Stop();

            return watch.ElapsedMilliseconds;
        }
        public long EfJoin()
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();
            var EmployeeEf = Context.Employee
                .Include(a => a.Department)
                //.Include(a => a.EmployeeAllowance)
                //.ThenInclude(a => a.Allowance)
                .Where(i => i.Active == true).ToList();
            watch.Stop();

            return watch.ElapsedMilliseconds;
        }
        public long EfBulk()
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();
            var AddressEf = Context.Address.ToList();
            watch.Stop();

            return watch.ElapsedMilliseconds;
        }
        //---------------------Dapper---------------------------//
        public long DapperSingle()
        {
            SqlConnection conn = new SqlConnection(appSettings.SqlConnection);
            Stopwatch watch = new Stopwatch();
           
            watch.Start();
            conn.Open();
            var EmployeeDapper = conn.Query<Employee>(" SELECT * FROM [Employee] AS [e] WHERE[e].[Active] = CAST(1 AS bit)");
            conn.Close();
            watch.Stop();

            return watch.ElapsedMilliseconds;
        }
        public long DapperJoin()
        {
            SqlConnection conn = new SqlConnection(appSettings.SqlConnection);
            Stopwatch watch = new Stopwatch();
            
            watch.Start();
            conn.Open();
            var EmployeeDapper = conn.Query<Employee>("select  * from [dbo].[Employee] E " +
                "INNER JOIN [dbo].[Department] D on E.DepartmentId=D.Id " +
                "LEFT JOIN [dbo].[EmployeeAllowance] EA ON EA.EmployeeId=E.Id " +
                "LEFT JOIN [dbo].[Allowance] A ON A.Id=EA.AllowanceId " +
                "Order by E.Id");
            conn.Close();
            watch.Stop();

            return watch.ElapsedMilliseconds;
        }
        public long DapperBulk()
        {
            SqlConnection conn = new SqlConnection(appSettings.SqlConnection);
            Stopwatch watch = new Stopwatch();

            watch.Start();
            conn.Open();
            var Address = conn.Query<Address>(" SELECT * FROM Address");
            conn.Close();
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
        //---------------------ADO.Net--------------------------//
        public long AdoSingle()
        {
            SqlConnection conn = new SqlConnection(appSettings.SqlConnection);
            Stopwatch watch = new Stopwatch();
            
            watch.Start();
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM [Employee] AS [e] WHERE[e].[Active] = CAST(1 AS bit)", conn);
            //adapter.SelectCommand.Parameters.Add(new SqlParameter("@ID", 1));
            DataTable table = new DataTable();
            adapter.Fill(table);

            conn.Close();
            watch.Stop();

            return watch.ElapsedMilliseconds;
        }
        public long AdoJoin()
        {
            SqlConnection conn = new SqlConnection(appSettings.SqlConnection);
            Stopwatch watch = new Stopwatch();

            watch.Start();
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select  * from [dbo].[Employee] E " +
                "INNER JOIN [dbo].[Department] D on E.DepartmentId=D.Id " +
                "LEFT JOIN [dbo].[EmployeeAllowance] EA ON EA.EmployeeId=E.Id " +
                "LEFT JOIN [dbo].[Allowance] A ON A.Id=EA.AllowanceId " +
                "Order by E.Id", conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            conn.Close();
            watch.Stop();

            return watch.ElapsedMilliseconds;
        }
        public long AdoBulk()
        {
            SqlConnection conn = new SqlConnection(appSettings.SqlConnection);
            Stopwatch watch = new Stopwatch();

            watch.Start();
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM [Address]", conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            conn.Close();
            watch.Stop();

            return watch.ElapsedMilliseconds;
        }

        //---------------------Entity Framework With Stored Procedure-----------------//
        public long EfSingleSp()
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();
            var EmployeeEf = Context.Employee
                    .FromSqlRaw("EXEC dbo.GET_EMPLOYEES")
                    .ToList();
            watch.Stop();

            return watch.ElapsedMilliseconds;
        }
        public long EfJoinSp()
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();
            var EmployeeEf = Context.CombinedView
                .FromSqlRaw("EXEC dbo.[GET_EMPLOYEE_DETAILS]")
                .ToList();
            watch.Stop();

            return watch.ElapsedMilliseconds;
        }
        public long EfBulkSp()
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();
            var AddressEf = Context.Address
                    .FromSqlRaw("EXEC dbo.[GET_ADDRESS]")
                    .ToList();
            watch.Stop();

            return watch.ElapsedMilliseconds;
        }
    }
}
