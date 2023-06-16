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
    public class GradeManager : IGradeService
    {
        IGradeDal _gradeDal;

        public GradeManager(IGradeDal gradeDal)
        {
            _gradeDal = gradeDal;
        }

        public IResult Add(Grade grade)
        {
            _gradeDal.Add(grade);

            return new SuccessResult();
        }

        public IResult Update(Grade grade)
        {
            _gradeDal.Update(grade);

            return new SuccessResult();
        }

        public IResult Delete(Grade grade)
        {
            _gradeDal.Delete(grade);

            return new SuccessResult();
        }

        public IDataResult<Grade> GetById(int id)
        {
            return new SuccessDataResult<Grade>(_gradeDal.Get(g => g.Id == id));
        }

        public IDataResult<List<Grade>> GetAll()
        {
            return new SuccessDataResult<List<Grade>>(_gradeDal.GetAll());
        }

        public IDataResult<List<GradeDetailDto>> GetGradeDetailsByStudentId(int studentId)
        {
            return new SuccessDataResult<List<GradeDetailDto>>(_gradeDal.GetGradeDetails(a => a.StudentId == studentId));
        }
    }
}
