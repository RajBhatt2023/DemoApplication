namespace Dummy.WebApplication.Models
{
    public class DealerProfileRequestM
    {

        public string? DealerName { get; set; }
        public string? ContactPerson { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Message { get; set; }
        // Staff Information
        public List<StaffInformation> StaffInformationList { get; set; }

        // Department Information
        //public List<string> DepartmentList { get; set; }

       
    }

    public class StaffInformation
    {
        public string? StaffRole { get; set; }
        public string? StaffName { get; set; }
        public string? StaffEmail { get; set; }
        public string? department { get; set; }
    }
}
