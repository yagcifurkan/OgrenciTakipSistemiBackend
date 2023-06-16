using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class GradeDetailDto : IDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string LessonName { get; set; }
        public int? MidtermExam { get; set; }
        public int? FinalExam { get; set; }
    }
}
