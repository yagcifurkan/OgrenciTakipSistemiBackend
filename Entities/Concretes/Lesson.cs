﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Lesson : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
