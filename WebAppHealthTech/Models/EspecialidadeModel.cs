using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppHealthTech.Models
{
    [Table("T_ESPCIALIDADE")]
    public class EspecialidadeModel
    {
        [Column("id_espeicialidade")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EspecialidadeId { get; set; }

        [Column("nm_especialidade")]
        public string EspecialidadeName { get; set; }

        [Column("ds_especialidade")]
        public string? Descricao { get; set; }

        public virtual ICollection<MedicoEspecModel>? MedicoEspec { get; set; }

        public EspecialidadeModel()
        {
        }
    }
}
