using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoAPI_Rider.Models;

namespace DemoAPI_Rider.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentCustom : ControllerBase
    {
        private readonly SchoolContext _context;

        public StudentCustom(SchoolContext context)
        {
            _context = context;
        }

        // GET: api/StudentCustom/SearchStudents?firstName=Juan&lastName=Perez&email=juan@example.com
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> SearchStudents(
            [FromQuery] string? firstName = null,
            [FromQuery] string? lastName = null,
            [FromQuery] string? email = null)
        {
            var query = _context.Students
                .Include(s => s.Grade)
                .Where(s => s.Active == 1);

            if (!string.IsNullOrEmpty(firstName))
            {
                query = query.Where(s => s.FirstName.Contains(firstName));
            }

            if (!string.IsNullOrEmpty(lastName))
            {
                query = query.Where(s => s.LastName.Contains(lastName));
            }

            if (!string.IsNullOrEmpty(email))
            {
                query = query.Where(s => s.Email.Contains(email));
            }

            var students = await query.OrderByDescending(s => s.LastName).ToListAsync();

            return students;
        }
    }
}
