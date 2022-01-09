using System.ComponentModel.DataAnnotations.Schema;

namespace informationSystem.Models
{
    public class Kullanici
    {
        public int ID { get; set; }
        public string? KULLANICI_ADI { get; set; }
        public string? SIFRE { get; set; }
        public bool TUR { get; set; }
        public int? KIMLIK_ID { get; set; }
        [ForeignKey("KIMLIK_ID")]
        public Kimlik? Kimlik { get; set; }
    }
}



