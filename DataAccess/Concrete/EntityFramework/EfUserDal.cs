using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, StudentTrackingSystemContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new StudentTrackingSystemContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };

                return result.ToList();
            }
        }

        public UserDetailDto GetUserDetail(string userEmail)
        {
            using (var context = new StudentTrackingSystemContext())
            {
                var teacherResult = (from u in context.Users
                              join t in context.Teachers
                                on u.Id equals t.UserId
                              where u.Email == userEmail

                              select new UserDetailDto
                              {
                                  Id = u.Id,
                                  TeacherId = t.Id,
                                  FirstName = u.FirstName,
                                  LastName = u.LastName,
                                  Email = u.Email
                              }).FirstOrDefault();

                var studentResult = (from u in context.Users
                              join s in context.Students               
                                on u.Id equals s.UserId
                              where u.Email == userEmail

                              select new UserDetailDto
                              {
                                  Id = u.Id,
                                  StudentId = s.Id,
                                  FirstName = u.FirstName,
                                  LastName = u.LastName,
                                  Email = u.Email
                              }).FirstOrDefault();

                if (teacherResult == null)
                {
                    return studentResult;
                } else
                {
                    return teacherResult;
                }
            }
        }
    }
}
