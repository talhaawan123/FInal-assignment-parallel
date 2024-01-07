using FInal_assignment_parallel.Data;
using FInal_assignment_parallel.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FInal_assignment_parallel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _context.Students.Include(s => s.Addresses).ToList();
            return Ok(students);
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student updatedStudent)
        {
            var existingStudent = _context.Students.Include(s => s.Addresses).FirstOrDefault(s => s.Id == id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            existingStudent.Name = updatedStudent.Name;
            existingStudent.RollNo = updatedStudent.RollNo;
            existingStudent.Class = updatedStudent.Class;
            existingStudent.Addresses = updatedStudent.Addresses;

            _context.SaveChanges();

            return Ok(existingStudent);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
