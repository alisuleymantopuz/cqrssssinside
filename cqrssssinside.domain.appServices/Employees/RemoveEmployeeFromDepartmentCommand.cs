using System;
using cqrssssinside.domain.Employees;
using cqrssssinside.domain.infrastructure.Data;
using CSharpFunctionalExtensions;

namespace cqrssssinside.domain.appServices.Employees
{
    public class RemoveFromDepartmentCommand:ICommand
    {
        public long EmployeeId { get; internal set; }

        public RemoveFromDepartmentCommand(long employeeid)
        {
            this.EmployeeId = employeeid;
        }
    }

    public sealed class RemoveFromDepartmentCommandHandler : ICommandHandler<RemoveFromDepartmentCommand>
    {
        private readonly StoreDBContext _storeDbContext;

        public RemoveFromDepartmentCommandHandler(StoreDBContext storeDBContext)
        {
            this._storeDbContext = storeDBContext;
        }

        public Result Handle(RemoveFromDepartmentCommand command)
        {
            var employee = this._storeDbContext.Find<Employee>(command.EmployeeId);
            if (employee == null)
                return Result.Fail($"No employee found for Id:{command.EmployeeId} ");

            employee.Department = null;
            _storeDbContext.Employees.Update(employee);
            _storeDbContext.SaveChanges();

            return Result.Ok();
        }
    }
}
