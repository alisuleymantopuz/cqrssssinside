using System;
using cqrssssinside.domain.Employees;
using cqrssssinside.domain.infrastructure.Data;
using CSharpFunctionalExtensions;

namespace cqrssssinside.domain.appServices.Employees
{
    public class EditEmployeeInfoCommand : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public long EmployeeId { get; internal set; }

        public EditEmployeeInfoCommand(long employeeid, string firstname, string lastname, string address)
        {
            this.EmployeeId = employeeid;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Address = address;
        }
    }

    public sealed class EditEmployeeInfoCommandHandler : ICommandHandler<EditEmployeeInfoCommand>
    {
        private readonly StoreDBContext _storeDbContext;

        public EditEmployeeInfoCommandHandler(StoreDBContext storeDBContext)
        {
            this._storeDbContext = storeDBContext;
        }

        public Result Handle(EditEmployeeInfoCommand command)
        {
            var employee = this._storeDbContext.Find<Employee>(command.EmployeeId);
            if (employee == null)
                return Result.Fail($"No employee found for Id:{command.EmployeeId} ");

            employee.FirstName = command.FirstName;
            employee.LastName = command.LastName;
            employee.Address = command.Address;
            _storeDbContext.Employees.Update(employee);
            _storeDbContext.SaveChanges();

            return Result.Ok();
        }
    }

}
