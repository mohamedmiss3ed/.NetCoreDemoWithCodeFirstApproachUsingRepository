using Microsoft.EntityFrameworkCore;
using NetCoreLastLabDemoWithRepositoryAndCodeFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLastLabDemoWithRepositoryAndCodeFirstApproach.Repository
{
    public class StudentManger : Repository<Student>
    {

        public StudentManger(StudentManagmentSystemDB db):base(db)
        {
            
        }
        public List<Student> GetAllStudent()
        {
            return GetAll().AsQueryable().Include(S => S.Department).ToList();
        }

        public Student GetStudentById(int id)
        {
            return GetById(id);
        }

       


    }
}
