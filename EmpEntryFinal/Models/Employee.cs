using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpEntryFinal.Models
{
    public class Employee
    {
            public int Id { get; set; }
        
            public string Name { get; set; }
            public string Address { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string StartTime { get; set; }
            public string EndTime { get; set; }

            public Designation? Designation { get; set; }
            public Department? Department { get; set; }
            public int? DesignationId { get; set; }
            public int? DepartmentId { get; set; }
            [NotMapped]
            public IFormFile ProfilePic { get; set; }
            public string? ProfilePath { get; set; }
       
    }

}

