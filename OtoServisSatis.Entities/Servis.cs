using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace OtoServisSatis.Entities
{
    public class Servis:IEntity
    {
        public int  Id { get; set; }
        [Display(Name = "Servise Geliş Tarihi")]
        public DateTime ServiseGelisTarii { get; set; }
        [Display(Name = "Araç Sorunu"), Required(ErrorMessage = "{0} Boş Bırakılamaz.")]
        public string AracSorunu { get; set; }
        [Display(Name = "Servis Ücreti")]
        public decimal ServisUcreti { get; set; }
        [Display(Name = "Servisten Çıkış Tarihi")]
        public DateTime ServistenCikisTarii { get; set; }
        [Display(Name = "Yapılan İşlemler")]
        public string? YapilanIslemler { get; set; }
        [Display(Name = "Garanti Kapsamında Mı?")]
        public bool GarantiKapasamaindaMi { get; set; }
        [StringLength(15)]
        [Display(Name = "Araç Plaka"), Required(ErrorMessage = "{0} Boş Bırakılamaz.")]
        public string AracPlaka { get; set; }
        [StringLength(50)]
        [Display(Name = "Araç Marka"), Required(ErrorMessage = "{0} Boş Bırakılamaz.")]
        public string AracMarka {get; set; }
        [StringLength(50)]
        public string Model { get; set; }
        [StringLength(50)]
        [Display(Name = "Kasa Tipi")]
        public string? KasaTipi { get; set; }
        [StringLength(50)]
        [Display(Name = "Şase Tipi")]
        public string? SaseTipi { get; set; }
        public string Notlar { get; set; }


    }
}
