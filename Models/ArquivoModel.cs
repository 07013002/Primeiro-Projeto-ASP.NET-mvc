using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProcessoSeleticov2.Models
{
    [Table("arquivo")]
    public class ArquivoModel
    {
        [Column("Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Column("Descricao")]
        [Display(Name = "Descricao")]
        public string? Descricao { get; set; }

        [Column("Dados")]
        [Display(Name = "Dados")]
        public byte[]? Dados { get; set; }

        [Column("ContentType")]
        [Display(Name = "ContentType")]
        public string? ContentType { get; set; }
    }
}
