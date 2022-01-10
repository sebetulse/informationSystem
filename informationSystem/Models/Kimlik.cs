using System.ComponentModel.DataAnnotations.Schema;

namespace informationSystem.Models
{
    public class Kimlik
    {
        public int ID { get; set; }
        public string? TC_NO { get; set; }
        public string? AD { get; set; }
        public string? SOYAD { get; set; }
        public string? DOGUM_YERI { get; set; }
        public DateTime? DOGUM_TARIHI { get; set; }
        public Kullanici? Kullanici { get; set; }

        public int ILETISIM_ID { get; set; }
        
        [ForeignKey("ILETISIM_ID")]
        public Iletisim? Iletisim { get; set; }
        public Ogrenci? Ogrenci { get; set; }
    }
}

