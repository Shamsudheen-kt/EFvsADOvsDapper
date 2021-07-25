
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.EntityModel
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        public bool Active { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<EmployeeAllowance> EmployeeAllowance { get; set; }
    }
}
