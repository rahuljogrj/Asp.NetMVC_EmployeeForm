using System.ComponentModel.DataAnnotations;

namespace WebApplication3.modules.EmployeeEntity
{
    public class UserMaster
    {
        [Key]
        public Guid UserID { get; set; } 
        public DateTime CreationDate { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string Emaill { get; set; } 
        public string PhoneNumber { get; set; } 
        public string UserName { get; set; } 
        public string Password { get; set; } 
        public string ConfirmPassword { get; set; } 
        public string Status { get; set; }

    }
}
