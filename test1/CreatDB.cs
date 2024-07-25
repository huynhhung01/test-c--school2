using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test1;
using test1.DTO;

namespace test1
{
    public class CreatDB : CreateDatabaseIfNotExists<ModelDB>
    {
        protected override void Seed(ModelDB db)
        {
            HP[] hp1 = new HP[]
            {
                new HP{IdHP="HP1", NameHP="Java"},
                new HP{IdHP="HP2", NameHP="C#"},
                new HP{IdHP="HP3", NameHP="Python"},
            };
           
            SV[] sv1 = new SV[]
            {
                new SV{IdSV=1,NameSV="NVA",LSH="22T_DT1",Gender=true,DBT=8.2,DGK=8,DCK=9,NgayThi=DateTime.Now},
                new SV{IdSV=2,NameSV="NVB",LSH="22T_DT1",Gender=false,DBT=6.3,DGK=6,DCK=8,NgayThi=DateTime.Now},
                new SV{IdSV=3,NameSV="NVC",LSH="22T_DT1",Gender=true,DBT=7.5,DGK=7,DCK=7,NgayThi=DateTime.Now},

            };
         
            db.HPs.AddRange(new HP[]
            {
                new HP{IdHP="HP1", NameHP="Java"},
                new HP{IdHP="HP2", NameHP="C#" },
               // new HP{IdHP="HP3", NameHP="Python"},


            });

            db.SVs.AddRange(new SV[] {
                new SV{IdSV=1,NameSV="NVA",LSH="22T_DT1",Gender=true,DBT=8.2,DGK=8,DCK=7,NgayThi=DateTime.Now},
                new SV{IdSV=2,NameSV="NVB",LSH="22T_DT1",Gender=false,DBT=6.3,DGK=6,DCK=8,NgayThi=DateTime.Now},
                new SV{IdSV=3,NameSV="NVC",LSH="22T_DT1",Gender=true,DBT=7.5,DGK=7,DCK=7,NgayThi=DateTime.Now},


            });

            db.SV_HPs.AddRange(new SV_HP[]
            {
                new SV_HP{IdSV_HP = 1,IdHP="HP1",IdSV=1},
                new SV_HP{IdSV_HP = 2, IdHP="HP1",IdSV=2},
                new SV_HP{IdSV_HP = 3,IdHP="HP2",IdSV=1},
                new SV_HP{IdSV_HP = 4, IdHP="HP2",IdSV=3},
                new SV_HP{IdSV_HP = 5,IdHP="HP2",IdSV=2},


            });

        }
    }
}
