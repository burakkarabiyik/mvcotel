using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelEleven.Models
{
    public class Odalar
    {
        [Key]
        public int Id { get; set; }
        public byte[] Foto1 { get; set; } 

    }
}
