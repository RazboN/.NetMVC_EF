using System.ComponentModel;

namespace MVC_EF_Deneme.Models
{
    public class KargoDetay : Kargo
    {
        public KargoDetay() { }
        
        [DisplayName("Ağırlık")]
        public int kargoAgirlik { get; set; }

        [DisplayName("Gönderen Adres")]
        public string gonderenAdres { get; set; }
    }
}
