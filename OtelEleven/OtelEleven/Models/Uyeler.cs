using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OtelEleven.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OtelEleven.Models
{
    public class Uyeler
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Key]
        public  string kullaniciadi { get; set; }
        public long Tc { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public long Telefonno { get; set; }
        public List<Yorumlar> yorums { get; set;  }

    }
}
