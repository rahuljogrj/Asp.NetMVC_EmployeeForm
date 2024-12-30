using System.ComponentModel.DataAnnotations;

namespace WebApplication3.modules.EmployeeEntity
{
    public class MasterData
    {
        [Key]
        public Guid MasterID { get; set; }
        public DateTime Creationdate { get; set; }
        public DateTime? LastModificationDate { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string MasterType { get; set; }
        public string Status { get; set; }

    }
}
