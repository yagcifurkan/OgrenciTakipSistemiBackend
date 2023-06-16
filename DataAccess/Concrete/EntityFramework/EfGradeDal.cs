using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfGradeDal : EfEntityRepositoryBase<Grade, StudentTrackingSystemContext>, IGradeDal
    {
        public List<GradeDetailDto> GetGradeDetails(Expression<Func<GradeDetailDto, bool>> filter = null)
        {
            using (var context = new StudentTrackingSystemContext())
            {
                var result = from g in context.Grades
                             join l in context.Lessons
                                 on g.LessonId equals l.Id
                             select new GradeDetailDto
                             {
                                 Id = g.Id,
                                 StudentId = g.StudentId,
                                 LessonName = l.Name,
                                 MidtermExam = g.MidtermExam,
                                 FinalExam = g.FinalExam,
                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
