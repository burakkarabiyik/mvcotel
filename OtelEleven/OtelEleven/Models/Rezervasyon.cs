using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelEleven.Models
{
    public class Rezervasyon
    {
        public int Id { get; set; }
        public DateTime Giris { get; set; }
        public DateTime Cikis { get; set; }
        public string hangikullanici { get; set; }
        public int Odano { get; set; }

    }
}
