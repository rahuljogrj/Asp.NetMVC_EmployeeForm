namespace WebApplication3.Models
{
    public class DesignationModel
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public List<DesignationListModel> lstDesignation{ get; set; }

    }

    public class DesignationListModel
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string MasterType { get; set; }
        public string Status { get; set; }

    }
}
