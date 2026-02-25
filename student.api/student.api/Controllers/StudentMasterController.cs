using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using student.api.Model;

namespace student.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class StudentMasterController : ControllerBase
    {
        private readonly StudentDbContext _context;

        public StudentMasterController(StudentDbContext context)
        {
            _context = context;
        }

        // GET: api/StudentMaster
        [HttpGet]
        public ActionResult GetStudents()
        {
            var students = _context.Students.ToList();
            return Ok(students);
        }

        // GET: api/StudentMaster/5
        [HttpGet("{id}")]
        public ActionResult GetStudent(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
                return NotFound(new { Status = "Error", Message = "Student not found" });

            return Ok(student);
        }

        // POST: api/StudentMaster
        [HttpPost]
        public IActionResult SaveStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

        // PUT: api/StudentMaster/5
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student student)
        {
            var record = _context.Students.Find(id);
            if (record == null)
                return NotFound(new { Status = "Error", Message = "Student record not found" });

            // Update the fields
            record.studentName = student.studentName;
            record.mobileNo = student.mobileNo;
            record.Email = student.Email;
            record.city = student.city;
            record.state = student.state;
            record.pincode = student.pincode;
            record.addressLine1 = student.addressLine1;
            record.addressLine2 = student.addressLine2;

            _context.SaveChanges();
            return Ok(record);
        }

        // DELETE: api/StudentMaster/5
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
                return NotFound(new { Status = "Error", Message = "Student record not found" });

            _context.Students.Remove(student);
            _context.SaveChanges();
            return Ok(new { Status = "Success", Message = "Student deleted" });
        }
    }
}
