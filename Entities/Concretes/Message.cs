using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Message : IEntity
    {
        public int Id { get; set; }
        public int SenderUserId { get; set; }
        public int ReciverUserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
