using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppHealthTech.Models
{
    [Table("t_paciente")]
    public class PacienteModel
    {
        [Column("id_paciente")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int PacienteId { get; set; }
        
        [Column("nm_paciente")]
        public string PacienteName { get; set; }
        
        [Column("nr_cpf")]
        public long Cpf{ get; set; }
        
        [Column("ds_email")]
        public string PacienteEmail { get; set; }
        
        [Column("sec_senha")]
        public string PacienteSenha { get; set; }

        public PacienteModel(int pacienteId, string pacienteName, int cpf, string pacienteEmail, string pacienteSenha)
        {
            PacienteId = pacienteId;
            PacienteName = pacienteName;
            Cpf = cpf;
            PacienteEmail = pacienteEmail;
            PacienteSenha = pacienteSenha;
        }

        public PacienteModel(string pacienteName, int cpf, string pacienteEmail, string pacienteSenha)
        {
            PacienteName = pacienteName;
            Cpf = cpf;
            PacienteEmail = pacienteEmail;
            PacienteSenha = pacienteSenha;
        }

        public PacienteModel()
        {
        }
    }
}
