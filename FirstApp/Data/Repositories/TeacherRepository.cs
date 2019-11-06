using FirstApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApp.Data.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly FirstAppContext _context;

        public TeacherRepository(FirstAppContext context)
        {
            _context = context;
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            var result = _context.Teachers.ToList();

            return result;
        }

        public Teacher GetTeacher(int id)
        {
            var result = _context.Teachers.Find(id);

            return result;
        }
    }
}
