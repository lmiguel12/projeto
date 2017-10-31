using System.ComponentModel.DataAnnotations;


namespace FormacaoMCV.Models
{
    public partial class PremioNobelMetadata
    {
        public int PremioNobelId { get; set; }
        [Display(Name = "Year")]
        public int Ano { get; set; }
        [Display(Name = "Category")]
        public int CategoriaId { get; set; }
        [Display(Name = "Title")]
        public string Titulo { get; set; }
        [Display(Name = "Motivation")]
        public string Motivacao { get; set; }
        public virtual Categoria Categoria { get; set; }
    }

    public partial class CategoriaMetadata
    {
        public int CategoriaId { get; set; }
        [Display(Name = "Category")]
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "The category must have [5-100] chars length")]
        public string Nome { get; set; }

    }

}