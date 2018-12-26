using System;
using System.Collections.Generic;
using System.Linq;
using cqrssssinside.domain.dto;
using cqrssssinside.domain.infrastructure.Data;

namespace cqrssssinside.domain.appServices.Employees
{
    public class GetDepartmentsQuery:IQuery<List<DepartmentInfo>>
    {
        public GetDepartmentsQuery()
        {
        }
    }

    public sealed class GetDepartmentsQueryHandler : IQueryHandler<GetDepartmentsQuery, List<DepartmentInfo>>
    {
        private readonly StoreDBContext _storeDbContext;

        public GetDepartmentsQueryHandler(StoreDBContext storeDBContext)
        {
            this._storeDbContext = storeDBContext;
        }

      public  List<DepartmentInfo> Handle(GetDepartmentsQuery query)
        {
            var departmentsQuery = this._storeDbContext.Departments.AsQueryable();

            var result = departmentsQuery.Select(x => new DepartmentInfo
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToList();

            return result;
        }
    }
}
