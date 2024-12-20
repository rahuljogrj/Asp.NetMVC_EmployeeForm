using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.modules.EmployeeEntity;

public partial class LoginUser
{
    [Key]
    [Column("UserID")]
    public Guid UserId { get; set; }

    public string FirstName { get; set; }

    public string MiddleName { get; set; }

    public string LastName { get; set; }

    [Required]
    [StringLength(1000)]
    public string UserType { get; set; }

    public DateTime? BirthDate { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }

    public bool IsActive { get; set; }

    public bool IsDarkMode { get; set; }

    [Required]
    [StringLength(200)]
    [Unicode(false)]
    public string Email { get; set; }
}
