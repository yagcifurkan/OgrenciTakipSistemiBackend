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
    public interface ITeacherService
    {
        IResult Add(Teacher teacher);
        IResult Update(Teacher teacher);
        IResult Delete(Teacher teacher);
        IDataResult<Teacher> GetById(int id);
        IDataResult<List<Teacher>> GetAll();
    }
}
