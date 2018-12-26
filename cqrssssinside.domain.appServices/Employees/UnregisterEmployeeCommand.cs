using System;
using cqrssssinside.domain.Employees;
using cqrssssinside.domain.infrastructure.Data;
using CSharpFunctionalExtensions;

namespace cqrssssinside.domain.appServices.Employees
{
    public class UnregisterEmployeeCommand : ICommand
    {
        public long EmployeeId { get; internal set; }

        public UnregisterEmployeeCommand(long employeeid)
        {
            this.EmployeeId = employeeid;
        }
    }

    public class UnregisterEmployeeCommandHandler : ICommandHandler<UnregisterEmployeeCommand>
    {
        private readonly StoreDBContext _storeDbContext;

        public UnregisterEmployeeCommandHandler(StoreDBContext storeDBContext)
        {
            this._storeDbContext = storeDBContext;
        }

        public Result Handle(UnregisterEmployeeCommand command)
        {
            var employee = this._storeDbContext.Find<Employee>(command.EmployeeId);
            if (employee == null)
                return Result.Fail($"No employee found for Id:{command.EmployeeId} ");

            _storeDbContext.Employees.Remove(employee);
            _storeDbContext.SaveChanges();

            return Result.Ok();
        }
    }
}
