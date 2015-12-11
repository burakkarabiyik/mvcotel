using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OtelEleven.Models;

namespace OtelEleven.Models
{
    class Uyeler
    {
        public int Id { get; set; }
        public string kullaniciadi { get; set; }
        public int Tc { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Telefonno { get; set; }
        public virtual List<Yorumlar> yorums { get; set;  }

    }
}
