using System;
using System.Collections.Generic;

namespace cqrssssinside.domain.Employees
{
    public class Department:Entity
    {
        public Department()
        {
        }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
    