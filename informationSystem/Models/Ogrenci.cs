using System.ComponentModel.DataAnnotations.Schema;

namespace informationSystem.Models
{
    public class Ogrenci
    {
        public int ID { get; set; }
        public string? OGR_NO { get; set; }
        public int? KIMLIK_ID { get; set; }
        public int? MUFREDAT_ID { get; set; }
       
        [ForeignKey("KIMLIK_ID")]
        public Kimlik? Kimlik { get; set; }
    }
}




