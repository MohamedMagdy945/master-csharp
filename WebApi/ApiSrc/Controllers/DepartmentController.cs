using ApiSrc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiSrc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        // Create instance of DbContext to access the database
        AppDbContext dbContext = new AppDbContext();

        // ----------------------------------------------------
        // GET: api/department
        // Returns all departments from database
        // AsNoTracking improves performance for read-only queries
        // ----------------------------------------------------
        [HttpGet]
        public IActionResult ShowAll()
        {
            List<Department> departments =
                dbContext.Departments
                .AsNoTracking() // No change tracking (better for read only)
                .ToList();

            return Ok(departments);
        }

        // ----------------------------------------------------
        // GET: api/department/{id}
        // Find department by id
        // ----------------------------------------------------
        [HttpGet("{Id}")]
        public IActionResult FindById(int Id)
        {
            // Find searches by primary key
            Department dept = dbContext.Departments.Find(Id);

            // Validate if department exists
            if (dept == null)
                return BadRequest("Invalid Id");

            return Ok(dept);
        }

        // ----------------------------------------------------
        // POST: api/department
        // Add new department
        // ----------------------------------------------------
        [HttpPost]
        public IActionResult Add(Department department)
        {
            // Validate request body
            if (department == null)
                return BadRequest("Invalid Data");

            // Add department to DbContext
            dbContext.Departments.Add(department);

            // Save changes to database
            dbContext.SaveChanges();

            return Ok(department);
        }

        // ----------------------------------------------------
        // PUT: api/department/{id}
        // Update existing department
        // ----------------------------------------------------
        [HttpPut("{id}")]
        public IActionResult Update(int id, Department department)
        {
            // Find existing department
            Department oldDept = dbContext.Departments.Find(id);

            if (oldDept == null)
                return NotFound("Department Not Found");

            // Update properties
            oldDept.Name = department.Name;
            oldDept.ManagerName = department.ManagerName;

            // Save changes
            dbContext.SaveChanges();

            return Ok(oldDept);
        }

        // ----------------------------------------------------
        // DELETE: api/department/{id}
        // Delete department
        // ----------------------------------------------------
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Department dept = dbContext.Departments.Find(id);

            if (dept == null)
                return NotFound("Department Not Found");

            dbContext.Departments.Remove(dept);

            dbContext.SaveChanges();

            return Ok("Department Deleted");
        }
    }
}