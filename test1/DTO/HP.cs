using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using test1;
using test1.DTO;

namespace test1
{
    public class HP
    {
        public HP()
        {
            this.SV_HPs = new HashSet<SV_HP>();
        }
        [Key]
        [Required]
        public string IdHP { get; set; }
        public string NameHP { get; set; }

        public virtual ICollection<SV_HP> SV_HPs { get; set; }

        public override string ToString()
        {
            return NameHP;
        }
    }
}
