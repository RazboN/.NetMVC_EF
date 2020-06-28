using System.ComponentModel.DataAnnotations;

namespace MVC_EF_Deneme.Models
{
    public abstract class Kargo
    {
        public Kargo() { }

        [Key]
        public int kargoId { get; set; }
        public string gonderenIsim { get; set; }
        public string aliciIsim { get; set; }
        public string aliciBirim { get; set; }
    }
}
