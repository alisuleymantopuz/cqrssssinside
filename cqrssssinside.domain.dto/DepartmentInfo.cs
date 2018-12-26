using System;
namespace cqrssssinside.domain.dto
{
    public class DepartmentInfo
    {
        public DepartmentInfo()
        {
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
