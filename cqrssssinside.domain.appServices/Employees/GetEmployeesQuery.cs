using System.Collections.Generic;
using System.Linq;
using cqrssssinside.domain.dto;
using cqrssssinside.domain.infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace cqrssssinside.domain.appServices.Employees
{
    public class GetEmployeesListQuery:IQuery<List<EmployeeInfo>>
    {
        public long? DepartmentId { get; set; }

        public GetEmployeesListQuery(long? departmentid)
        {
            this.DepartmentId = departmentid;
        }
    }

    public sealed class GetEmployeesListQueryHandler : IQueryHandler<GetEmployeesListQuery, List<EmployeeInfo>>
    {
        private readonly StoreDBContext _storeDbContext;

        public GetEmployeesListQueryHandler(StoreDBContext storeDBContext)
        {
            this._storeDbContext = storeDBContext;
        }

      public  List<EmployeeInfo> Handle(GetEmployeesListQuery query)
        {
            var employeesQuery = this._storeDbContext.Employees.AsQueryable();

            if (query.DepartmentId.HasValue)
            {
                employeesQuery = employeesQuery.Include(x => x.Department).Where(x => x.Department.Id == query.DepartmentId.Value);
            }

            var result = employeesQuery.Select(x => new EmployeeInfo
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Address = x.Address,
                DepartmentId = x.Department.Id
            }).ToList();

            return result;
        }
    }
}
