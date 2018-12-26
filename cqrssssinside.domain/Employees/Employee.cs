namespace cqrssssinside.domain.Employees
{
    public class Employee:Entity
    {
        public Employee()
        {
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public Department Department { get; set; }
    }
}
