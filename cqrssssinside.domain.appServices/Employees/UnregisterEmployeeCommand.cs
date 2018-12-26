using System;
using cqrssssinside.domain.Employees;
using cqrssssinside.domain.infrastructure.Data;
using CSharpFunctionalExtensions;

namespace cqrssssinside.domain.appServices.Employees
{
    public class UnregisterCommand:ICommand
    {
        public long EmployeeId { get; internal set; }

        public UnregisterCommand(long employeeid)
        {
            this.EmployeeId = employeeid;
        }
    }

    public class UnregisterCommandHandler : ICommandHandler<UnregisterCommand>
    {
        private readonly StoreDBContext _storeDbContext;

        public UnregisterCommandHandler(StoreDBContext storeDBContext)
        {
            this._storeDbContext = storeDBContext;
        }

        public Result Handle(UnregisterCommand command)
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
