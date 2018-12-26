using System.Collections.Generic;
using cqrssssinside.domain.appServices.Employees;
using cqrssssinside.domain.appServices.Utils;
using cqrssssinside.domain.dto;
using cqrssssinside.employees.Models;
using cqrssssinside.web.common.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace cqrssssinside.employees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController
    {
        private readonly Messages _messages;

        public EmployeesController(Messages messages)
        {
            _messages = messages;
        }
        
        // GET api/values
        [HttpGet("GetEmployees")]
        public IActionResult GetEmployees(long? departmentId)
        {
           List<EmployeeInfo> employees = _messages.Dispatch(new GetEmployeesListQuery(departmentId));
           
           return Ok(employees);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpPost("ChangeDepartment")]
        public IActionResult ChangeDepartment([FromBody]ChangeDepartmentModel changeDepartmentModel)
        {
            var changeDepartmentCommand = new ChangeDepartmentCommand(changeDepartmentModel.EmployeeId, changeDepartmentModel.NewDepartmentId);

            var result = _messages.Dispatch(changeDepartmentCommand);

            return FromResult(result);
        }

        [HttpPut("EditEmployeeInfo")]
        public IActionResult EditEmployeeInfo([FromBody] EditEmployeeModel editEmployeeModel)
        {
            var editEmployeeCommand = new EditEmployeeInfoCommand(editEmployeeModel.EmployeeId,editEmployeeModel.FirstName, editEmployeeModel.LastName, editEmployeeModel.Address);

            var result = _messages.Dispatch(editEmployeeCommand);

            return FromResult(result);
        }

        [HttpPost("RegisterEmployee")]
        public IActionResult RegisterEmployee([FromBody] RegisterEmployeeModel registerEmployeeModel)
        {
            var registerEmployeeCommand = new RegisterEmployeeCommand(registerEmployeeModel.FirstName, registerEmployeeModel.LastName, registerEmployeeModel.Address);

            var result = _messages.Dispatch(registerEmployeeCommand);

            return FromResult(result);
        }

        [HttpPost("RemoveEmployeeFromDepartment")]
        public IActionResult RemoveEmployeeFromDepartment([FromBody] RemoveFromDepartmentModel removeFromDepartmentModel)
        {
            var removeFromDepartmentCommand = new RemoveEmployeeFromDepartmentCommand(removeFromDepartmentModel.EmployeeId);

            var result = _messages.Dispatch(removeFromDepartmentCommand);

            return FromResult(result);
        }

        // DELETE api/values/5
        [HttpDelete("Unregister/{id}")]
        public IActionResult Unregister(long id)
        {
            var unregisterEmployeeCommand = new UnregisterEmployeeCommand(id);

            var result = this._messages.Dispatch(unregisterEmployeeCommand);

            return FromResult(result);
        }
    }
}
