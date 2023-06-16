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
    public class StudentManager : IStudentService
    {
        IStudentDal _studentDal;

        public StudentManager(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }

        public IResult Add(Student student)
        {
            _studentDal.Add(student);

            return new SuccessResult();
        }

        public IResult Update(Student student)
        {
            _studentDal.Update(student);

            return new SuccessResult();
        }

        public IResult Delete(Student student)
        {
            _studentDal.Delete(student);

            return new SuccessResult();
        }

        public IDataResult<List<Student>> GetAll()
        {
            return new SuccessDataResult<List<Student>>(_studentDal.GetAll());
        }

        public IDataResult<Student> GetById(int id)
        {
            return new SuccessDataResult<Student>(_studentDal.Get(s => s.Id == id));
        }

        public IDataResult<List<StudentDetailDto>> GetStudentDetails()
        {
            return new SuccessDataResult<List<StudentDetailDto>>(_studentDal.GetStudentDetails());
        }

        public IDataResult<StudentDetailDto> GetStudentDetailById(int id)
        {
            return new SuccessDataResult<StudentDetailDto>(_studentDal.GetStudentDetails(s => s.Id == id).SingleOrDefault());
        }
    }
}
