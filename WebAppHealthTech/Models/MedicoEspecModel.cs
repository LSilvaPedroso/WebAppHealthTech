using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppHealthTech.Models
{
    [Table("MEDICO_ESPEC")]

    public class MedicoEspecModel
    {
        [Column("id_medico")]
        public int MedicoId { get; set; }

        [Column("id_espeicialidade")]
        public int EspecialidadeId { get; set; }

        [Column("nm_instituicao")]
        public string InstituicaoName { get; set; }

        [Column("dt_inicio")]
        public DateTime DataInicio { get; set; }
        
        [Column("dt_termino")]
        public DateTime? DataTermino { get; set; }

        public virtual EspecialidadeModel? Especialidade { get; set; }
        public virtual MedicoModel? Medico { get; set; }

        public MedicoEspecModel()
        {

        }
    }
}
