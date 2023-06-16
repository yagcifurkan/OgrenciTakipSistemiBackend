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
    public class EfAbsenceDal : EfEntityRepositoryBase<Absence, StudentTrackingSystemContext>, IAbsenceDal
    {
        public List<AbsenceDetailDto> GetAbsenceDetails(Expression<Func<AbsenceDetailDto, bool>> filter = null)
        {
            using (var context = new StudentTrackingSystemContext())
            {
                var result = from a in context.Absences
                             join l in context.Lessons
                                 on a.LessonId equals l.Id
                             select new AbsenceDetailDto
                             {
                                 Id = a.Id,
                                 StudentId = a.StudentId,
                                 LessonName = l.Name,
                                 Date = a.Date,
                                 Status = a.Status
                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
