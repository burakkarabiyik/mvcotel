using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelEleven.Models
{
    public class Etkinlikler
    {
        public int Id { get; set; }
        public String EtkinlikAdi { get; set; }
        public DateTime Tarih { get; set; }
        public String icerik { get; set; }
        public byte[] Foto { get; set; }

    }
}
