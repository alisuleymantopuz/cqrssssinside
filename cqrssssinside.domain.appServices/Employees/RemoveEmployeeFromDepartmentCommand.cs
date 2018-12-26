using System;
using cqrssssinside.domain.Employees;
using cqrssssinside.domain.infrastructure.Data;
using CSharpFunctionalExtensions;

namespace cqrssssinside.domain.appServices.Employees
{
    public class RemoveEmployeeFromDepartmentCommand : ICommand
    {
        public long EmployeeId { get; internal set; }

        public RemoveEmployeeFromDepartmentCommand(long employeeid)
        {
            this.EmployeeId = employeeid;
        }
    }

    public sealed class RemoveEmployeeFromDepartmentCommandHandler : ICommandHandler<RemoveEmployeeFromDepartmentCommand>
    {
        private readonly StoreDBContext _storeDbContext;

        public RemoveEmployeeFromDepartmentCommandHandler(StoreDBContext storeDBContext)
        {
            this._storeDbContext = storeDBContext;
        }

        public Result Handle(RemoveEmployeeFromDepartmentCommand command)
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
