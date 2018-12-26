using System;
namespace cqrssssinside.domain.dto
{
    public class EmployeeInfo
    {
        public EmployeeInfo()
        {
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public long DepartmentId { get; set; }
    }
}
