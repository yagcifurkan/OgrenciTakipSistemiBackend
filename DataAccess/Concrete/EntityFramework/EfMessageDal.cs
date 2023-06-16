using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
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
    public class EfMessageDal : EfEntityRepositoryBase<Message, StudentTrackingSystemContext>, IMessageDal
    {
        public List<MessageDetailDto> GetMessageDetails(Expression<Func<MessageDetailDto, bool>> filter = null)
        {
            using (var context = new StudentTrackingSystemContext())
            {
                var result = from m in context.Messages
                             join s in context.Users 
                                on m.SenderUserId equals s.Id
                             join r in context.Users
                                 on m.ReciverUserId equals r.Id

                             select new MessageDetailDto
                             {
                                 Id = m.Id,
                                 SenderUserId = m.SenderUserId,
                                 SenderFirstName = s.FirstName,
                                 SenderLastName= s.LastName,
                                 ReciverUserId = m.ReciverUserId,
                                 ReciverFirstName = r.FirstName,
                                 ReciverLastName = r.LastName,
                                 Title = m.Title,
                                 Content = m.Content
                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
