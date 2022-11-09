using System.ComponentModel.DataAnnotations;

namespace WebCegMVC1.Models
{
    public class modellMunkatars
    {
        public int id { get; set; }

        [Display(Name ="A munkatárs neve")]
        public string nev { get; set; }

        [Display(Name = "A munkatárs lakóhelye")]
        public string varos { get; set; }

        [Display(Name = "Milyen területen?")]
        public string beosztas { get; set; }

        [Display(Name = "Idegen nyelvismeret")]
        public string nyelvtudas { get; set; }

    }
}
