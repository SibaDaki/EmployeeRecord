using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRecords.DbEntities;
using EmployeeRecords.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeRecords.Controllers 
{
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/employee")]

    public class EmployeeController : Controller
    {

        EmployeeContext context;



        public EmployeeController(EmployeeContext context)
        {
            this.context = context;
        }

        // GET: api/employee>
        [HttpGet ("{id}")]
        public IActionResult GetEmployee()
        {
            IEnumerable<EmployeeViewModel> model = context.Set<Employee>().ToList().Select(s => new EmployeeViewModel
            {

                EmployeeId = s.EmployeeId,
                PersonId = s.PersonId,
                EmployeeNo = s.EmployeeNo,
                EmployeeDate = s.EmployeeDate,
                TerminatedDate = s.TerminatedDate
                //Id = s.EmployeeId;
                //Name = $"{s.FirstName} {s.LastName}",
                //MobileNo = s.MobileNo,
                //Email = s.Email
            });
            return View("Index", model);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(long? id)
        {
            EmployeeViewModel model = new EmployeeViewModel();
            if (id.HasValue)
            {
                Employee employee = context.Set<Employee>().SingleOrDefault(c => c.EmployeeId == id.Value);
                if (employee != null)
                {
                    model.EmployeeId = employee.EmployeeId;
                    model.PersonId = employee.PersonId;
                    model.EmployeeNo = employee.EmployeeNo;
                    model.EmployeeDate = employee.EmployeeDate;
                    model.TerminatedDate = employee.TerminatedDate;
                }
            }
            return PartialView("~/Views/Employee/AddEmployee.cshtml", model);
        }

        [HttpPost]
        public ActionResult PostEmployee(long? id, EmployeeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    Employee employee = isNew ? new Employee
                    {
                       // AddedDate = DateTime.UtcNow
                    } : context.Set<Employee>().SingleOrDefault(s => s.EmployeeId == id.Value);
                    model.PersonId = employee.PersonId;
                    model.EmployeeNo = employee.EmployeeNo;
                    model.EmployeeDate = employee.EmployeeDate;
                    model.TerminatedDate = employee.TerminatedDate;
                    if (isNew)
                    {
                        context.Add(employee);
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        [HttpGet("{id}")]
        public IActionResult DeleteEmployee(long id)
        {
            Employee employee = context.Set<Employee>().SingleOrDefault(c => c.EmployeeId == id);
            EmployeeViewModel model = new EmployeeViewModel
            {
                //PersonId = PersonId;
            };
            return PartialView("~/Views/Employee/DeleteEmployee.cshtml", model);
        }
        [HttpPost("{id}")]
        public IActionResult DeleteEmployee(long id, FormCollection form)
        {
            Employee employee = context.Set<Employee>().SingleOrDefault(c => c.EmployeeId == id);
            context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
    //public IEnumerable<string> Get()
    //{
    //    return new string[] { "value1", "value2" };
    //}

    // GET api/<controller>/5
    //[HttpGet("{id}")]
    //    public string Get(int id)
    //    {
    //        return "value";
    //    }

    //    // POST api/<controller>
    //    [HttpPost]
    //    public void Post([FromBody]string value)
    //    {
    //    }

    //    // PUT api/<controller>/5
    //    [HttpPut("{id}")]
    //    public void Put(int id, [FromBody]string value)
    //    {
    //    }

    //    // DELETE api/<controller>/5
    //    [HttpDelete("{id}")]
    //    public void Delete(int id)
    //    {
    //    }
   // }
}
