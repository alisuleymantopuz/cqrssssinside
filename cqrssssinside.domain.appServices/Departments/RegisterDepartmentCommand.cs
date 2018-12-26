using cqrssssinside.domain.Employees;
using cqrssssinside.domain.infrastructure.Data;
using CSharpFunctionalExtensions;

namespace cqrssssinside.domain.appServices.Departments
{
    public class RegisterDepartmentCommand:ICommand
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public RegisterDepartmentCommand(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
    }

    public sealed class RegisterDepartmentCommandHandler : ICommandHandler<RegisterDepartmentCommand>
    {
        private readonly StoreDBContext _storeDbContext;

        public RegisterDepartmentCommandHandler(StoreDBContext storeDBContext)
        {
            this._storeDbContext = storeDBContext;
        }

        public Result Handle(RegisterDepartmentCommand command)
        {
            _storeDbContext.Departments.Add(new Department { Name=command.Name, Description=command.Description});
            _storeDbContext.SaveChanges();
            return Result.Ok();
                        }
    }
}
