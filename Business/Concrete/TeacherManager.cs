using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TeacherManager : ITeacherService
    {
        ITeacherDal _teacherDal;

        public TeacherManager(ITeacherDal teacherDal)
        {
            _teacherDal = teacherDal;
        }

        public IResult Add(Teacher teacher)
        {
            _teacherDal.Add(teacher);

            return new SuccessResult();
        }

        public IResult Update(Teacher teacher)
        {
            _teacherDal.Update(teacher);

            return new SuccessResult();
        }

        public IResult Delete(Teacher teacher)
        {
            _teacherDal.Delete(teacher);
            return new SuccessResult();
        }

        public IDataResult<Teacher> GetById(int id)
        {
            return new SuccessDataResult<Teacher>(_teacherDal.Get(t => t.Id == id));
        }

        public IDataResult<List<Teacher>> GetAll()
        {
            return new SuccessDataResult<List<Teacher>>(_teacherDal.GetAll());
        }
    }
}
