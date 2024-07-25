using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using test1.DTO;
using test1;
using static System.Net.Mime.MediaTypeNames;
namespace test.BLL
{
    internal class QLSV_BLL
    {
        public static QLSV_BLL _Instance;
        public static QLSV_BLL Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new QLSV_BLL();
                return _Instance;
            }
            private set { }
        }
        public List<HP> GetListCCbitemHP()
        {
            List<HP> list = new List<HP>();
            ModelDB db = new ModelDB();
            var l = db.HPs.Select(p => new { p.IdHP, p.NameHP }).Distinct().ToList();
            foreach (var i in l)
            {
                HP lsh = new HP();
                lsh.IdHP = i.IdHP;
                lsh.NameHP = i.NameHP;
                list.Add(lsh);
            }
            // list.Add(new LSH_f1 { IdLop = 0,NameLop="All" });
            return list;
        }
        public List<String> GetListCCbitemLSH()
        {
            List<string> list = new List<string>();
            ModelDB db = new ModelDB();
            var l = db.SVs.Select(p => new { p.LSH }).Distinct().ToList();
            foreach (var i in l)
            {
                string s = "";
                s = i.LSH;
                list.Add(s);
            }
            // list.Add(new LSH_f1 { IdLop = 0,NameLop="All" });
            return list;
        }

        public List<SV_f1> GetAllDaGVSV()
        {
            List<SV_f1> list = new List<SV_f1>();
            ModelDB db = new ModelDB();
            int k = 1;
            var l = db.SV_HPs.Select(p => new { p.SVs.IdSV,p.SVs.NameSV,p.SVs.LSH,p.HPs.NameHP,p.SVs.DBT,p.SVs.Gender,p.SVs.DGK,p.SVs.DCK,TongKet = p.SVs.DBT*0.2 + p.SVs.DGK*0.2 +p.SVs.DCK*0.6, p.SVs.NgayThi }).ToList();
            foreach (var i in l)
            {
                SV_f1 sv = new SV_f1();
                sv.STT = i.IdSV ;
                sv.NameSV = i.NameSV;
                sv.DBT = i.DBT;
                sv.DGK = i.DGK;
                sv.DCK = i.DCK;
                sv.DTK = i.TongKet;
                sv.Gender = i.Gender;

                sv.NameHP = i.NameHP;
                sv.NgayThi = i.NgayThi;
                sv.LSH = i.LSH;
                list.Add(sv);
            }

            return list;
        }

        public List<SV_f1> GetAllDaGVSV_ByCBB(string txt)
        {

            if (txt == "All") return GetAllDaGVSV();
            List<SV_f1> list = new List<SV_f1>();
            ModelDB db = new ModelDB();
            var l = db.SV_HPs.Where(p => p.HPs.NameHP.Contains(txt))
                             .Select(p => new { p.SVs.IdSV, p.SVs.NameSV, p.SVs.LSH, p.HPs.NameHP, p.SVs.DBT, p.SVs.DGK, p.SVs.DCK, TongKet = p.SVs.DBT * 0.2 + p.SVs.DGK * 0.2 + p.SVs.DCK * 0.6, p.SVs.NgayThi,p.SVs.Gender })
                             .ToList();

            foreach (var i in l)
            {
                SV_f1 sv = new SV_f1();
                sv.STT = i.IdSV;
                sv.NameSV = i.NameSV;
                sv.DBT = i.DBT;
                sv.DGK = i.DGK;
                sv.DCK = i.DCK;
                sv.DTK = i.TongKet;
                sv.Gender = i.Gender;

                sv.NameHP = i.NameHP;
                sv.NgayThi = i.NgayThi;
                sv.LSH = i.LSH;
                list.Add(sv);
            }

            return list;
        }

        public List<SV_f1> GetAllDaGVSV_ByText(string txt)
        {
            List<SV_f1> list = new List<SV_f1>();
            ModelDB db = new ModelDB();
            var l = db.SV_HPs.Where(p => p.SVs.NameSV.Contains(txt))
                             .Select(p => new { p.SVs.IdSV, p.SVs.NameSV, p.SVs.LSH, p.HPs.NameHP, p.SVs.DBT, p.SVs.DGK, p.SVs.DCK, TongKet = p.SVs.DBT * 0.2 + p.SVs.DGK * 0.2 + p.SVs.DCK * 0.6, p.SVs.NgayThi,p.SVs.Gender })
                             .ToList();
            foreach (var i in l)
            {
                SV_f1 sv = new SV_f1();
                sv.STT = i.IdSV;
                sv.NameSV = i.NameSV;
                sv.DBT = i.DBT;
                sv.DGK = i.DGK;
                sv.DCK = i.DCK;
                sv.DTK = i.TongKet;
                sv.Gender = i.Gender;
                sv.NameHP = i.NameHP;
                sv.NgayThi = i.NgayThi;
                sv.LSH = i.LSH;
                list.Add(sv);
            }

            return list;
        }

        public SV_f1 GetSVBy_IdSV_HP(int id)
        {
            SV_f1 sv = new SV_f1();
            ModelDB db = new ModelDB();
            var i = db.SV_HPs.Where(p => p.IdSV_HP == id)
                            .Select(p => new { p.SVs.IdSV, p.SVs.NameSV, p.SVs.LSH, p.HPs.NameHP,p.SVs.Gender, p.SVs.DBT, p.SVs.DGK, p.SVs.DCK, TongKet = p.SVs.DBT * 0.2 + p.SVs.DGK * 0.2 + p.SVs.DCK * 0.6, p.SVs.NgayThi })
                            .FirstOrDefault();
                            
           

                sv.STT = i.IdSV;
                sv.NameSV = i.NameSV;
                sv.DBT = i.DBT;
                sv.DGK = i.DGK;
                sv.DCK = i.DCK;
                sv.DTK = i.TongKet;
                sv.Gender = i.Gender;

                sv.NameHP = i.NameHP;
                sv.NgayThi = i.NgayThi;
                sv.LSH = i.LSH;

            
            return sv;
        }
        public HP GetHpByText(string text)
        {
            HP hp = new HP();
            ModelDB db = new ModelDB();
            hp = db.HPs.Where(p => p.NameHP.Contains(text)).FirstOrDefault();
            return hp;
        }
        public void UpdateSV(SV sv, int ma)
        {
            ModelDB db = new ModelDB();

            var a = db.SVs.Find(ma);
            a.IdSV = sv.IdSV;
            a.NameSV = sv.NameSV;
            a.Gender = sv.Gender;
            a.DBT = sv.DBT;
            a.DGK = sv.DGK;
            a.DCK = sv.DCK;

            a.LSH = sv.LSH;
            a.NgayThi = sv.NgayThi;

            db.SaveChanges();
        }

        public void UddateSV_HP(SV_HP svhp , int ma)
        {
            ModelDB db = new ModelDB();
            var a = db.SV_HPs.Find(ma);
            a.IdHP = svhp.IdHP;
            a.IdSV_HP = svhp.IdSV_HP;
            a.IdSV = svhp.IdSV;

            db.SaveChanges();

        }

        public void DeleteSV(int ma)
        {
            ModelDB db = new ModelDB();
            SV sv = new SV();
            sv = db.SVs.Where(p => p.IdSV == ma).FirstOrDefault();
            db.SVs.Remove(sv);
            db.SaveChanges();
        }
        public void DeleteSV_HP(int ma)
        {
            ModelDB db = new ModelDB();
            SV_HP svhp = new SV_HP();
            svhp = db.SV_HPs.Where(p => p.IdSV_HP == ma).FirstOrDefault();
            SV sv = new SV();
            sv = db.SVs.Find(svhp.IdSV);
            db.SVs.Remove(sv);
            db.SaveChanges();
        }
        public bool AddNewSV(SV sv, SV_HP svhp)
        {
            ModelDB db = new ModelDB();
            int i = 0;
            var a = db.SVs.Find(sv.IdSV);
            var b = db.SV_HPs.Where(p => p.IdHP == svhp.IdHP && p.IdSV == svhp.IdSV).Select(k=> new {k.IdSV_HP});
            foreach(var l in b)
            {
                i = l.IdSV_HP;
            }
            
            if (a == null && i==0)
            {
                db.SVs.Add(sv);
                db.SV_HPs.Add(svhp);
                db.SaveChanges();
                return true;
            }
            return false;

        }
        public bool check(SV_HP svhp)
        {
            ModelDB db = new ModelDB();

            int i = 0;
            var b = db.SV_HPs.Where(p => p.IdHP == svhp.IdHP && p.IdSV == svhp.IdSV).Select(k => new { k.IdSV_HP });
            foreach (var l in b)
            {
                i = l.IdSV_HP;
            }
            if (i == 0)
            {
                //svhp.IdSV_HP = 10;
                db.SV_HPs.Add(svhp);
                db.SaveChanges();
                return true;
            }
            return false;

        }


    }
}
