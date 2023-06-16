using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class MessageDetailDto : IDto
    {
        public int Id { get; set; }
        public int SenderUserId { get; set; }
        public string SenderFirstName { get; set; }
        public string SenderLastName { get; set; }
        public int ReciverUserId { get; set; }
        public string ReciverFirstName { get; set; }
        public string ReciverLastName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
