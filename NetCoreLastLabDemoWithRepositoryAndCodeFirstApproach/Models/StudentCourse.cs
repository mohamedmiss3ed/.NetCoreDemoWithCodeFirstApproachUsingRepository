using Microsoft.EntityFrameworkCore;
using NetCoreLastLabDemoWithRepositoryAndCodeFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLastLabDemoWithRepositoryAndCodeFirstApproach.Models
{
    public class StudentCourse
    {

        [ForeignKey("Student")]
     
        [Column(Order = 0)]
        public int StudentId { get; set; }
        [ForeignKey("Course")]
   
        [Column(Order = 1)]
        public int CourseId { get; set; }
        public int Degree { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }
    }
   
}
