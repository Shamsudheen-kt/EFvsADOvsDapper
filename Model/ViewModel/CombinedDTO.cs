using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModel
{
    public class CombinedView
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Active { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int? AllowanceId { get; set; }
        public string AllowanceName { get; set; }
    }
}
