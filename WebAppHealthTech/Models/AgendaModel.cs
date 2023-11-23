using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppHealthTech.Models
{
    [Table("t_agenda")]
    public class AgendaModel
    {
        [Column("id_agenda")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AgendaId { get; set; }
        
        [Column("id_paciente")]
        public int PacienteId { get; set; }

        [Column("id_medhosp")]
        public int MedicoId { get; set; }
        
        [Column("dt_entrada")]
        public DateTime DataEntrada { get; set; }
        
        [Column("dt_saida")]
        public DateTime? DataSaida { get; set;}
        
        [Column("ds_status")]
        public string? Status { get; set; }

        public AgendaModel(int pacienteId, int medicoId, DateTime dataEntrada, DateTime dataSaida)
        {
            PacienteId = pacienteId;
            MedicoId = medicoId;
            DataEntrada = dataEntrada;
            DataSaida = dataSaida;
        }

        public AgendaModel()
        {
        }
    }
}
