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
    public class EfStudentDal : EfEntityRepositoryBase<Student, StudentTrackingSystemContext>, IStudentDal
    {
        public List<StudentDetailDto> GetStudentDetails(Expression<Func<StudentDetailDto, bool>> filter = null)
        {
            using (var context = new StudentTrackingSystemContext())
            {
                var result = from s in context.Students
                             join u in context.Users
                                 on s.UserId equals u.Id
                             select new StudentDetailDto
                             {
                                 Id = s.Id,
                                 UserId = s.UserId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 StudentNumber = s.StudentNumber,
                                 Faculty = s.Faculty,
                                 Department = s.Department
                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
