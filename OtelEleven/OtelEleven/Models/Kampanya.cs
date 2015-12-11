using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelEleven.Models
{
    class Kampanya
    {
        [Key]
        public int Id { get; set; }
        public string Ad { get; set; }
        public Oda oda { get; set; }
        public int Indirim  { get; set; }
        public DateTime Baslangic { get; set; }
        public DateTime Bitis { get; set; }
    }
}
