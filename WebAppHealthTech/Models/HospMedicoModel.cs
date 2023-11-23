using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppHealthTech.Models
{
    [Table("HOSP_MEDICO")]

    public class HospMedicoModel
    {
        [Column("id_medhosp")]
        public int MedicoHospitalId { get; set; }

        [Column("id_medico")]
        public int MedicoId { get; set; }

        [Column("id_hospital")]
        public int HospitalId { get; set; }

        [Column("ds_status")]
        public string Status { get; set; }

        public virtual MedicoModel? MedicoModel { get; set; }
        public virtual HospitalModel? HospitalModel { get; set; }

        public HospMedicoModel()
        {

        }
    }
}
