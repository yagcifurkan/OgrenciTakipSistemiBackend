using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AnnouncementManager : IAnnouncementService
    {
        IAnnouncementDal _announcementDal;

        public AnnouncementManager(IAnnouncementDal announcementDal)
        {
            _announcementDal = announcementDal;
        }

        public IResult Add(Announcement announcement)
        {
            _announcementDal.Add(announcement);

            return new SuccessResult();
        }

        public IResult Update(Announcement announcement)
        {
            _announcementDal.Update(announcement);

            return new SuccessResult();
        }

        public IResult Delete(Announcement announcement)
        {
            _announcementDal.Delete(announcement);

            return new SuccessResult();
        }

        public IDataResult<Announcement> GetById(int id)
        {
            return new SuccessDataResult<Announcement>(_announcementDal.Get(a => a.Id == id));
        }

        public IDataResult<List<Announcement>> GetAll()
        {
            return new SuccessDataResult<List<Announcement>>(_announcementDal.GetAll());
        }
    }
}
