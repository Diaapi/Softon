using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softon.Shared
{
    public class AppModel
    {
        [Key]
        public int Id { get; set; }
        public string? User { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? Url { get; set; }
        public DateTime Date { get; set; }
    }
}
