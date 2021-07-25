using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.EntityModel
{
    public class EmployeeAllowance
    {

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [ForeignKey("Allowance")]
        public int AllowanceId { get; set; }
        public Allowance Allowance { get; set; }

    }
}
