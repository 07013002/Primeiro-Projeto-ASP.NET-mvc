using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProcessoSeleticov2.Models
{
    [Table("processo")]
    public class ProcessosModel
    {
        [Column("Id")]
        [Display(Name ="Id")]
        public int Id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        public string? NomeProcesso { get; set; }
    }
}
