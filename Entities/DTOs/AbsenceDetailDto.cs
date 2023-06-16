using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class AbsenceDetailDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string LessonName { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
