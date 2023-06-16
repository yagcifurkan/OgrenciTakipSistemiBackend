using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Teacher : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Faculty { get; set; }
        public string Department { get; set; }
    }
}
