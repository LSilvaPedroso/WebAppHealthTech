using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppHealthTech.Models
{
    [Table("t_medico")]
    public class MedicoModel
    {
        [Column("id_medico")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicoId { get; set; }
        
        [Column("nm_medico")]
        public string MedicoName { get; set; }
        
        [Column("nr_crm")]
        public int Crm { get; set; }
        
        [Column("dt_nascimento")]
        public DateTime DataNascimento { get; set; }
        
        [Column("dt_contratacao")]
        public DateTime DataContratacao { get; set; }
        
        [NotMapped]
        public HospitalModel Hospital { get; set; }

        public virtual ICollection<HospMedicoModel>? HospMedico { get; set; }
        public virtual ICollection<MedicoEspecModel>? MedicoEspec { get; set; }

        public MedicoModel()
        {
        }

    }
}
 
