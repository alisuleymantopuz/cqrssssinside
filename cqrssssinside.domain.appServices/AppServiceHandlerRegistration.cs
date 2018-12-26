using System;
using System.Collections.Generic;
using cqrssssinside.domain.appServices.Departments;
using cqrssssinside.domain.appServices.Employees;
using cqrssssinside.domain.dto;
using Microsoft.Extensions.DependencyInjection;

namespace cqrssssinside.domain.appServices
{
    public static class AppServiceHandlerRegistration
    {
        public static void AddDepartmentHandlers(this IServiceCollection services)
        {
            #region QueryHandlers
            services.AddTransient<IQueryHandler<GetDepartmentsQuery, List<DepartmentInfo>>, GetDepartmentsQueryHandler>();
            #endregion

            #region CommandHandlers
            services.AddTransient<ICommandHandler<RegisterDepartmentCommand>, RegisterDepartmentCommandHandler>();
            services.AddTransient<ICommandHandler<UnregisterDepartmentCommand>, UnregisterDepartmentCommandHandler>();
            #endregion

        }

        public static void AddEmployeeHandlers(this IServiceCollection services)
        {
            #region QueryHandlers
            services.AddTransient<IQueryHandler<GetEmployeesListQuery, List<EmployeeInfo>>, GetEmployeesListQueryHandler>();
            #endregion

            #region CommandHandlers
            services.AddTransient<ICommandHandler<ChangeDepartmentCommand>, ChangeDepartmentCommandHandler>();
            services.AddTransient<ICommandHandler<EditEmployeeInfoCommand>, EditEmployeeInfoCommandHandler>();
            services.AddTransient<ICommandHandler<RegisterEmployeeCommand>, RegisterEmployeeCommandHandler>();
            services.AddTransient<ICommandHandler<RemoveEmployeeFromDepartmentCommand>, RemoveEmployeeFromDepartmentCommandHandler>();
            services.AddTransient<ICommandHandler<UnregisterEmployeeCommand>, UnregisterEmployeeCommandHandler>();
            #endregion

        }
    }
}
