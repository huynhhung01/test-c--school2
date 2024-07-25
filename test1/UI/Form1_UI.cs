using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test.BLL;
using test1.DTO;

namespace test1.UI
{
    public partial class Form1_UI : Form
    {
        public Form1_UI()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetCombox();
            SetDG();
        }
        public void SetCombox()
        {
            /* ModelDB db = new ModelDB();
             var l1 = db.LSHs.Select(p => p.NameLop).Distinct().ToList();*/
            List<HP> lsh = QLSV_BLL.Instance.GetListCCbitemHP();
            lsh.Add(new HP { IdHP = "HP0", NameHP = "All" });
            comboBox1.Items.AddRange(lsh.ToArray());

        }
        public void SetDG()
        {
            
            dataGridView1.DataSource = QLSV_BLL.Instance.GetAllDaGVSV();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string hp = comboBox1.SelectedItem.ToString();

            dataGridView1.DataSource = QLSV_BLL.Instance.GetAllDaGVSV_ByCBB(hp);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                ModelDB db = new ModelDB();

                string namehp = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                string idsv = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                int idSV = int.Parse(idsv);
                // MessageBox.Show(namehp);

                // int id = int.Parse(idsv);
                SV_HP sv_hp = new SV_HP();
                sv_hp = db.SV_HPs.Where(p => p.HPs.NameHP.Contains(namehp) && p.IdSV == idSV).FirstOrDefault();

                MessageBox.Show(sv_hp.IdHP+ " " + sv_hp.IdSV);

                Form2_UI f2 = new Form2_UI(2, sv_hp.IdSV_HP);
                f2.Show();
            }
            else
            {
                MessageBox.Show("bạn chưa chọn hàng");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2_UI f2 = new Form2_UI(1, -1);
            f2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                ModelDB db = new ModelDB();
                string namehp = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                SV_HP sv_hp = new SV_HP();
                string idsv = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                int idSV = int.Parse(idsv);
                sv_hp = db.SV_HPs.Where(p => p.HPs.NameHP.Contains(namehp) && p.IdSV == idSV).FirstOrDefault();

                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                QLSV_BLL.Instance.DeleteSV(int.Parse(id));
                QLSV_BLL.Instance.DeleteSV_HP(sv_hp.IdSV_HP);

                MessageBox.Show("Đã xóa thành công sinh vien : " + id);

                SetDG();
            }
            else
            {
                MessageBox.Show("bạn chưa chọn hàng");
            }

        }
    }
}
