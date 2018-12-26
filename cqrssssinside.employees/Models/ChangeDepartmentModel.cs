using System;
namespace cqrssssinside.employees.Models
{
    public class ChangeDepartmentModel
    {
        public ChangeDepartmentModel()
        {
        }

        public long EmployeeId { get; set; }
        public long NewDepartmentId { get; set; }
    }
}
