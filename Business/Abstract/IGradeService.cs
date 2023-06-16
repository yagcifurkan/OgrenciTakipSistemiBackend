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
    public interface IGradeService
    {
        IResult Add(Grade grade);
        IResult Update(Grade grade);
        IResult Delete(Grade grade);
        IDataResult<Grade> GetById(int id);
        IDataResult<List<Grade>> GetAll();

        IDataResult<List<GradeDetailDto>> GetGradeDetailsByStudentId(int studentId);
    }
}
