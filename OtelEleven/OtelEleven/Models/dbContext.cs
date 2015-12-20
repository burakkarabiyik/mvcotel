using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OtelEleven.Models;
namespace OtelEleven.Models
{
    public class dbContext: DbContext
    {
        public virtual DbSet<Yorumlar> yorumlar { get; set; }
        public virtual DbSet<Kampanya> Kampanya { get; set; }
        public virtual DbSet<Rezervasyon> Rezervasyon { get; set; }
        public virtual DbSet<Oda> oda { get; set; }
        public virtual DbSet<Odalar> Resimler { get; set; }
        public virtual DbSet<Slider> Slider { get; set; } 
        public virtual DbSet<Etkinlikler> Etkinlik { get; set; }
    }
}
