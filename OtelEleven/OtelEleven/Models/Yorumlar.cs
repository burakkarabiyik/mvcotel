using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelEleven.Models
{
    public class Yorumlar
    {
        [Key]
        public int Id { get; set; } 
        public string kullaniciadi { get; set; }
        
        public string yorum { get; set; }
        public Uyeler Uye { get; set; }

    }
}
