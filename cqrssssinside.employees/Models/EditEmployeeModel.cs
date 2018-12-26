using System;
namespace cqrssssinside.employees.Models
{
    public class EditEmployeeModel
    {
        public EditEmployeeModel()
        {
        }
        public long EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}
