using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        BankContext _context;
        public EmployeeController(BankContext context)
        {
            _context = context;
        }
        [HttpGet]
        public List<Employee> GetAll()
        {
            return _context.Employees.Select(b => new Employee
            {
                Name = b.Name,
                CivilId = b.CivilId,
                Position = b.Position,
                Id = b.Id

            }).ToList();
        }
        [HttpPost("{id}")]

        public IActionResult Add(int id, AddEmployeeRequest employee)
        {


            var Employee = _context.Employees.Find(id);
             _context.Employees.Add(new Employee()
            {
                Name = Employee.Name,
                CivilId = Employee.CivilId,
                Position = Employee.Position,

            });
            _context.SaveChanges();
            return Created();
        }
        [HttpGet("{id}")]
        public ActionResult Details(int id)
        {
            var Employee = _context.Employees.Find(id);
            if (Employee == null)
            {
                return NotFound();
            }
            return Ok(new Employee
            {
                Name = Employee.Name,
                CivilId = Employee.CivilId,
                Position = Employee.Position,
              //  BankBranch = Employee.BankBranch,
            });
        }
        [HttpPatch("{id}")]
        public ActionResult Edit(int id, AddEmployeeRequest req)
        {
            var Employee = _context.Employees.Find(id);
            Employee.Name = req.Name;
            Employee.CivilId = req.CivilId;
            Employee.Position = req.Position;
        
            _context.SaveChanges();
            return Created(nameof(Details), new { Id = Employee.Id });
        }
        //[HttpPost("AddEmployee/{id}")]
        //public IActionResult Add(int id, AddEmployeeRequest req)
        //{
        //    var Employee = new Employee();
        //    Employee.Name = req.Name;
        //    Employee.CivilId = req.CivilId;
        //    Employee.Position = req.Position;

        //    var bankbranch = _context.BankBranches.Find(id);
        //    Employee.BankBranch = bankbranch;
        //    _context.Employees.Add(Employee);   
        //    _context.SaveChanges();
        //    return Created(nameof(Details), new { Id = Employee.Id });
        //}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Employee = _context.Employees.Find(id);
            _context.Employees.Remove(Employee);
            _context.SaveChanges();
            return Ok();
        }
    }
}