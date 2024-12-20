using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.modules.EmployeeEntity;

[Keyless]
[Table("Employees_samples")]
public partial class EmployeesSample
{
    [Column("EmployeeID")]
    public int? EmployeeId { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Salary { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string Grade { get; set; }
}
