﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Entities
{
    public class Musteri:IEntity
    {
        public int Id { get; set; }
        public int AracId { get; set; }
        [StringLength(50)]
        public string Adi { get; set; }
        [StringLength(50)]
        public string SoyAdi { get; set; }
        [StringLength(11)]
        public string? TcNo { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(500)]
        public string? Adres { get; set; }
        [StringLength(15)]
        public string? Telefon { get; set; }
        public string? Notlar { get; set; }
        public virtual Arac Arac { get; set; }
    }
}
