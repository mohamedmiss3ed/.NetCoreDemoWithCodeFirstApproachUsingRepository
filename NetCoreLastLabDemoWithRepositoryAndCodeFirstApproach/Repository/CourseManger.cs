using NetCoreLastLabDemoWithRepositoryAndCodeFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLastLabDemoWithRepositoryAndCodeFirstApproach.Repository
{
    public class CourseManger:Repository<Course>
    {
        public CourseManger(StudentManagmentSystemDB db) : base(db)
        {

        }

    }
}
