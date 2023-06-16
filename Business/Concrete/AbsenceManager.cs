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
    public class AbsenceManager : IAbsenceService
    {
        IAbsenceDal _absenceDal;

        public AbsenceManager(IAbsenceDal absenceDal)
        {
            _absenceDal = absenceDal;
        }

        public IResult Add(Absence absence)
        {
            _absenceDal.Add(absence);

            return new SuccessResult();
        }

        public IResult Update(Absence absence)
        {
            _absenceDal.Update(absence);

            return new SuccessResult();
        }

        public IResult Delete(Absence absence)
        {
            _absenceDal.Delete(absence);

            return new SuccessResult();
        }

        public IDataResult<Absence> GetById(int id)
        {
            return new SuccessDataResult<Absence>(_absenceDal.Get(a => a.Id == id));
        }

        public IDataResult<List<Absence>> GetAll()
        {
            return new SuccessDataResult<List<Absence>>(_absenceDal.GetAll());
        }

        public IDataResult<List<AbsenceDetailDto>> GetAbsenceDetailsByStudentId(int studentId)
        {
            return new SuccessDataResult<List<AbsenceDetailDto>>(_absenceDal.GetAbsenceDetails(a => a.StudentId == studentId));
        }
    }
}
