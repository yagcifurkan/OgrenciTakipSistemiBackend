using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IAbsenceDal : IEntityRepository<Absence>
    {
        List<AbsenceDetailDto> GetAbsenceDetails(Expression<Func<AbsenceDetailDto, bool>> filter = null);
    }
}
