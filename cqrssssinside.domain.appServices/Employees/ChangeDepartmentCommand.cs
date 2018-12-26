using cqrssssinside.domain.Employees;
using cqrssssinside.domain.infrastructure.Data;
using CSharpFunctionalExtensions;

namespace cqrssssinside.domain.appServices.Employees
{
    public class ChangeDepartmentCommand:ICommand
    {
        public long EmployeeId { get; set; }
        public long NewDepartmentId { get; set; }

        public ChangeDepartmentCommand(long employeeeId, long newDepartmentId)
        {
            this.EmployeeId = employeeeId;
            this.NewDepartmentId = newDepartmentId;
        }
    }

    public sealed class ChangeDepartmentCommandHandler : ICommandHandler<ChangeDepartmentCommand>
    {
        private readonly StoreDBContext _storeDbContext;

        public ChangeDepartmentCommandHandler(StoreDBContext storeDBContext)
        {
            this._storeDbContext = storeDBContext;
        }

        public Result Handle(ChangeDepartmentCommand command)
        {
            var employee = this._storeDbContext.Find<Employee>(command.EmployeeId);
            if (employee == null)
                return Result.Fail($"No employee found for Id:{command.EmployeeId} ");

            var department = this._storeDbContext.Find<Department>(command.NewDepartmentId);
            if (department == null)
                return Result.Fail($"No department found for Id:{command.NewDepartmentId} ");


            employee.Department = department;
            _storeDbContext.Employees.Update(employee);
            _storeDbContext.SaveChanges();
            return Result.Ok();
        }
    }
}
