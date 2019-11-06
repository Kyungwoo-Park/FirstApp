using System.Collections.Generic;
using FirstApp.Models;

namespace FirstApp.Data.Repositories
{
    public interface ITeacherRepository
    {
        IEnumerable<Teacher> GetAllTeachers();
        Teacher GetTeacher(int id);
    }
}