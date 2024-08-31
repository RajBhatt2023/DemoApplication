using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dummy.Domain.Entities
{
    public class EmailEntity
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string? ToEmail { get; set; }
        [MaxLength(100)]
        public string? Subject { get; set; }
        [MaxLength(250)]
        public string? Body { get; set; }
    }
}
