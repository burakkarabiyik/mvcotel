﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelEleven.Models
{
    public class Oda
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int kackisi { get; set; }
        [Key]
        public int OdaNo { get; set; }
        public bool Vip { get; set; }
        public bool Dolumu { get; set; }
        public int Ucret { get; set; }
    }
}
