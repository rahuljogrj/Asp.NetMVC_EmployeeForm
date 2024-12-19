using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models.DBEntities
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }
        public double Salary { get; set; }
        public string StatusID { get; set; }

      
    }
}
