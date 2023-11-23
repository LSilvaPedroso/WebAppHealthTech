using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppHealthTech.Models
{
    [Table("t_hospital")]
    public class HospitalModel
    {
        [Column("id_hospital")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HospitalId { get; set; }

        [Column("nm_hospital")]
        public string HospitalName { get; set; }

        [Column("ds_endereco")]
        public string HospitalEndereco { get; set; }

        [Column("nr_cnpj")]
        public long Cnpj { get; set; }

        [Column("ds_cep")]
        public int Cep { get; set; }

        [Column("ds_cidade")]
        public string Cidade { get; set; }

        [Column("ds_estado")]
        public string Estado { get; set; }

        [Column("ds_latitude")]
        public decimal latitude { get; set; }

        [Column("ds_longitude")]
        public decimal longitude { get; set; }
        
        [NotMapped]
        public decimal quilometros { get; set; }
        public virtual ICollection<HospMedicoModel>? HospMedico { get; set; }

        public HospitalModel()
        {
        }
    }
}
