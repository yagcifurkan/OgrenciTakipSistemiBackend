using Core.Utilities.Results;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAnnouncementService
    {
        IResult Add(Announcement announcement);
        IResult Update(Announcement announcement);
        IResult Delete(Announcement announcement);
        IDataResult<Announcement> GetById(int id);
        IDataResult<List<Announcement>> GetAll();
    }
}
