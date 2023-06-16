using Core.Utilities.Results;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStudentService
    {
        IResult Add(Student student);
        IResult Update(Student student);
        IResult Delete(Student student);
        IDataResult<Student> GetById(int id);
        IDataResult<List<Student>> GetAll();

        IDataResult<List<StudentDetailDto>> GetStudentDetails();
        IDataResult<StudentDetailDto> GetStudentDetailById(int id);
    }
}
