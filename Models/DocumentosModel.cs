using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProcessoSeleticov2.Models
{
    [Table("documento")]
    public class DocumentosModel
    {
        [Column("Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Column("Codigo")]
        [Display(Name = "Codigo")]
        public int Codigo { get; set; }

        [Column("Titulo")]
        [Display(Name = "Titulo")]
        public string? Titulo { get; set; }

        [Column("Processo")]
        [Display(Name = "Processo")]
        public string? Processo { get; set; }

        [Column("Categoria")]
        [Display(Name = "Categoria")]
        public string? Categoria { get; set; }
    }
}
