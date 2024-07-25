using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1.DTO
{
    public class SV_HP
    {
        [Key]
        [Required]
        
        public int IdSV_HP { get; set; }
        public int IdSV { get; set; }
        [ForeignKey(nameof(IdSV))]
        public virtual SV SVs { get; set; }
        public string IdHP { get; set; }

        [ForeignKey(nameof(IdHP))]
        public virtual HP HPs { get; set; }

    }
}
