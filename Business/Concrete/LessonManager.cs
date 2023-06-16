using Business.Abstract;
using Business.Constants;
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
    public class LessonManager : ILessonService
    {
        ILessonDal _lessonDal;

        public LessonManager(ILessonDal lessonDal)
        {
            _lessonDal = lessonDal;
        }

        public IResult Add(Lesson lesson)
        {
            _lessonDal.Add(lesson);

            return new SuccessResult();
        }

        public IResult Update(Lesson lesson)
        {
            _lessonDal.Update(lesson);

            return new SuccessResult();
        }

        public IResult Delete(Lesson lesson)
        {
            _lessonDal.Delete(lesson);

            return new SuccessResult();
        }

        public IDataResult<List<Lesson>> GetAll()
        {
            return new SuccessDataResult<List<Lesson>>(_lessonDal.GetAll());
        }

        public IDataResult<Lesson> GetById(int id)
        {
            return new SuccessDataResult<Lesson>(_lessonDal.Get(l => l.Id == id));
        }
    }
}
