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
    public interface IAbsenceService
    {
        IResult Add(Absence absence);
        IResult Update(Absence absence);
        IResult Delete(Absence absence);
        IDataResult<Absence> GetById(int id);
        IDataResult<List<Absence>> GetAll();

        IDataResult<List<AbsenceDetailDto>> GetAbsenceDetailsByStudentId(int studentId);
    }
}
