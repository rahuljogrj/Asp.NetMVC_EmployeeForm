using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.modules.EmployeeEntity;

[Table("Employee")]
public partial class Employee
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string Email { get; set; }

    public double Salary { get; set; }

    [Required]
    [Column("StatusID")]
    [StringLength(5)]
    [Unicode(false)]
    public string StatusID { get; set; }

    public Guid DesignationID { get; set; }


    [Column(TypeName = "datetime")]
    public DateTime? Creationdate { get; set; }
}
