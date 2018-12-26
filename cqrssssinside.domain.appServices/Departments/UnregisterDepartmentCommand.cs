using System;
using cqrssssinside.domain.Employees;
using cqrssssinside.domain.infrastructure.Data;
using CSharpFunctionalExtensions;

namespace cqrssssinside.domain.appServices.Departments
{
    public class UnregisterDepartmentCommand:ICommand
    {
        public long DepartmentId { get; set; }
        public UnregisterDepartmentCommand(long departmentid)
        {
            this.DepartmentId = departmentid;
        }
    }

    public sealed class UnregisterDepartmentCommandHandler : ICommandHandler<UnregisterDepartmentCommand> 
    {
        private readonly StoreDBContext _storeDbContext;

        public UnregisterDepartmentCommandHandler(StoreDBContext storeDBContext)
        {
            this._storeDbContext = storeDBContext;
        }

        public Result Handle(UnregisterDepartmentCommand command)
        {
            var department = this._storeDbContext.Find<Department>(command.DepartmentId);
            if (department == null)
                return Result.Fail($"No department found for Id:{command.DepartmentId} ");

            this._storeDbContext.Departments.Remove(department);
            this._storeDbContext.SaveChanges();

            return Result.Ok();
        
                        }
    }
}
