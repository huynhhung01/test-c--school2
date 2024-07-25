using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using test1.DTO;
namespace test1
{
    public class SV
    {
        public SV(){
            this.SV_HPs = new HashSet<SV_HP>();

         }

        [Key]
        [Required]
        public int IdSV { get; set; }
        public string NameSV { get; set; }
        public string LSH {  get; set; } 
        public bool Gender { get; set; }
        public Double DBT { get; set; }
        public Double DGK { get; set; }
        public Double DCK { get; set; }

        public DateTime NgayThi { get; set; }

        public virtual ICollection<SV_HP> SV_HPs { get; set; }




    }
}
