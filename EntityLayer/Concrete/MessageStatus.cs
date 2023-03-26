using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class MessageStatus
    {
        [Key]
        public int MessageStatusId { get; set; }

        [StringLength(100)]
        public string MessageCategory { get; set; }

        public ICollection<Message> Messages { get; set; }
    }
}
