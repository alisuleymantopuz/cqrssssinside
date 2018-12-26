using System.Collections.Generic;
using cqrssssinside.departments.Models;
using cqrssssinside.domain.appServices.Departments;
using cqrssssinside.domain.appServices.Utils;
using cqrssssinside.domain.dto;
using cqrssssinside.web.common.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace cqrssssinside.departments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : BaseController
    {
        private readonly Messages _messages;

        public DepartmentsController(Messages messages)
        {
            _messages = messages;
        }

        // GET api/values
        [HttpGet]
        [Route("GetDepartments")]
        public IActionResult GetDepartments()
        {
            List<DepartmentInfo> list = _messages.Dispatch(new GetDepartmentsQuery());

            return Ok(list);
        }

        // POST api/values
        [HttpPost("Register")]
        public IActionResult Register([FromBody]RegisterDepartmentModel registerDepartmentModel)
        {
            var registerDepartmentCommand = new RegisterDepartmentCommand(registerDepartmentModel.Name, registerDepartmentModel.Description);

            var result = this._messages.Dispatch(registerDepartmentCommand);

            return FromResult(result);
        }

        // DELETE api/values/5
        [HttpDelete("Unregister/{id}")]
        public IActionResult Unregister(long id)
        {
            var unregisterDepartmentCommand = new UnregisterDepartmentCommand(id);

            var result = this._messages.Dispatch(unregisterDepartmentCommand);

            return FromResult(result);
        }
    }
}
