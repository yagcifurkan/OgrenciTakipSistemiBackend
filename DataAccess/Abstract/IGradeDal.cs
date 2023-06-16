using Core.DataAccess;
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
    public interface IGradeDal : IEntityRepository<Grade>
    {
        List<GradeDetailDto> GetGradeDetails(Expression<Func<GradeDetailDto, bool>> filter = null);
    }
}
