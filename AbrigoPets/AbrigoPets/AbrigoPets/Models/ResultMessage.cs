using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbrigoPets.Models
{
    public class ResultMessage
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int NewId { get; set; }
    }
}
