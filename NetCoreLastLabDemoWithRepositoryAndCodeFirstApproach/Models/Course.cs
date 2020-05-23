using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLastLabDemoWithRepositoryAndCodeFirstApproach.Models
{
    public class Course
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }

        public Department Department { get; set; }
        public List<StudentCourse> Students { get; set; }
    }
}
