using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Entities
{
    public class Arac:IEntity
    {
        public int Id { get; set; }
        public int MarkaId { get; set; }
        [StringLength(50)]
        public int Renk { get; set; }
        public decimal Fiyati { get; set; }
        [StringLength(50)]
        public string Modeli { get; set; }
        [StringLength(50)]
        public string KasaTipi { get; set; }
        public int ModelYili { get; set;}
        public bool SatistaMi { get; set; }
        public string Notlar { get; set; }
        public virtual Marka Marka { get; set; }
    }
}
