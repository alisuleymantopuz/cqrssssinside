using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using cqrssssinside.domain.dto;
using cqrssssinside.domain.infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace cqrssssinside.domain.appServices.Employees
{
    public class GetEmployeeQuery : IQuery<EmployeeInfo>
    {
        public long EmployeeId { get; set; }

        public GetEmployeeQuery(long employeeId)
        {
            this.EmployeeId = employeeId;
        }
    }

    public sealed class GetEmployeeQueryHandler : IQueryHandler<GetEmployeeQuery, EmployeeInfo>
    {
        private readonly StoreDBContext _storeDbContext;

        public GetEmployeeQueryHandler(StoreDBContext storeDBContext)
        {
            this._storeDbContext = storeDBContext;
        }

        public EmployeeInfo Handle(GetEmployeeQuery query)
        {
            var employee = this._storeDbContext.Employees.Find(query.EmployeeId);

            var result = Mapper.Map<EmployeeInfo>(employee);

            return result;
        }
    }
}
