using System;
using cqrssssinside.domain.Employees;
using cqrssssinside.domain.infrastructure.Data;
using CSharpFunctionalExtensions;

namespace cqrssssinside.domain.appServices.Employees
{
    public class RegisterEmployeeCommand : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public object EmployeeId { get; internal set; }

        public RegisterEmployeeCommand(string firstname, string lastname, string address)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Address = address;
        }
    }

    public sealed class RegisterEmployeeCommandHandler : ICommandHandler<RegisterEmployeeCommand>
    {
        private readonly StoreDBContext _storeDbContext;

        public RegisterEmployeeCommandHandler(StoreDBContext storeDBContext)
        {
            this._storeDbContext = storeDBContext;
        }

        public Result Handle(RegisterEmployeeCommand command)
        {
            this._storeDbContext.Employees.Add(new Employee { 
                FirstName=command.FirstName, 
                Address=command.Address, 
                Department=null, 
                LastName=command.LastName
             });

            this._storeDbContext.SaveChanges();

            return Result.Ok();
        }
    }
}
