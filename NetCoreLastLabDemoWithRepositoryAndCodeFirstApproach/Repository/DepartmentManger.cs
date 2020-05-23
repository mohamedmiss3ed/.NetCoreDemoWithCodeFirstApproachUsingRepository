using NetCoreLastLabDemoWithRepositoryAndCodeFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLastLabDemoWithRepositoryAndCodeFirstApproach.Repository
{
    public class DepartmentManger:Repository<Department>
    {
        public DepartmentManger(StudentManagmentSystemDB db):base(db)
        {

        }
  
    }
}
