using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace OtoServisSatis.Entities
{
    public class Servis:IEntity
    {
        public int  Id { get; set; }
        public DateTime ServiseGelisTarii { get; set; }
        public string AracSurumu { get; set; } 
        public decimal ServisUcreti { get; set; }
        public DateTime ServistenCikisTarii { get; set; }
        public string? YapilanIslemler { get; set; }
        public bool GarantiKapasamaindaMi { get; set; }
        [StringLength(15)]
        public string AracPlaka { get; set; }
        [StringLength(50)]
        public string AracMarka {get; set; }
        [StringLength(50)]
        public string Model { get; set; }
        [StringLength(50)]
        public string? KasaTipi { get; set; }
        [StringLength(50)]
        public string? SaseTipi { get; set; }
        public string Notlar { get; set; }


    }
}
