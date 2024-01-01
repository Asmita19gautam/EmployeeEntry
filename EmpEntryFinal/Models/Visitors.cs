using System.ComponentModel.DataAnnotations;

namespace EmpEntryFinal.Models
{
    public class Visitors
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Reason { get; set; }
        public string RepresentingCompany { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public Employee? Employee { get; set; }
        public int? EmployeeId { get; set; }
        public bool IsParking { get; set; }


    }
}
