using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.modules.EmployeeEntity;

public partial class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Username { get; set; }

    public string Email { get; set; }

    public long Mobile { get; set; }

    [Required]
    public string Password { get; set; }

    public string ConfirmPassword { get; set; }

    public bool IsActive { get; set; }

    public bool IsRemember { get; set; }
}
