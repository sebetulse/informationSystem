namespace informationSystem.Models
{
    public class Iletisim
    {
        public int ID { get; set; }
        public string? ADRES { get; set; }
        public string? IL { get; set; }
        public string? ILCE { get; set; }
        public string? EMAIL { get; set; }
        public string? GSM { get; set; }

        public Kimlik? Kimlik { get; set; }
    }
}
