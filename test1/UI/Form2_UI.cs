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
    public partial class Form2_UI : Form
    {
        public int type { get; set; }
        public int ma { get; set; } 
        public Form2_UI()
        {
            InitializeComponent();
        }
        public Form2_UI(int t, int m)
        {
            InitializeComponent();
            type = t;
            ma = m;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        public void SetItemCBB_HP(string txt)
        {
            for (int i = 0; i < comboBox2.Items.Count; i++)

                if (comboBox2.Items[i].ToString() == txt)
                {
                    comboBox2.SelectedIndex = i;
                    break;
                }
        }
        public void SetItemCBB_LSH(string txt)
        {
            for (int i = 0; i < comboBox1.Items.Count; i++)

                if (comboBox1.Items[i].ToString() == txt)
                {
                    comboBox1.SelectedIndex = i;
                    break;
                }
        }
        private void Form2_UI_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(QLSV_BLL.Instance.GetListCCbitemLSH().ToArray());
            comboBox2.Items.AddRange(QLSV_BLL.Instance.GetListCCbitemHP().ToArray());

            // edit sv
            if (type == 2)
            {
                textBox1.ReadOnly = true;
                SV_f1 sv = new SV_f1();
                sv = QLSV_BLL.Instance.GetSVBy_IdSV_HP(ma);

                textBox1.Text = sv.STT.ToString();
                textBox2.Text = sv.NameSV.ToString();
                textBox3.Text = sv.DBT.ToString();
                textBox4.Text = sv.DGK.ToString();
                textBox5.Text = sv.DCK.ToString();

                //  comboBox1.Select(2);
                SetItemCBB_LSH(sv.LSH);
                SetItemCBB_HP(sv.NameHP);

                if (sv.Gender == true)
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
                dateTimePicker1.Value = sv.NgayThi;

            }
            else if (type == 1)
            {
                // add new sv
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string idsv = textBox1.Text;
            string name = textBox2.Text;
            double DBT = double.Parse(textBox3.Text);
            double DGK = double.Parse(textBox4.Text);
            double DCK = double.Parse(textBox5.Text);

            bool gender;
            if (radioButton1.Checked == true) gender = true;
            else gender = false;

            string ngathi = dateTimePicker1.Value.ToString();

            string lsh = comboBox1.SelectedItem.ToString();
            string hp = comboBox2.SelectedItem.ToString();

            SV sv = new SV();

            sv.IdSV = int.Parse(idsv);
            sv.NameSV = name;
            sv.LSH = lsh;
            sv.DBT = DBT;
            sv.DCK = DCK;   
            sv.DGK = DGK;
            sv.NgayThi = dateTimePicker1.Value;
            sv.Gender = gender;

            SV_HP svhp = new SV_HP();
           
            svhp.IdSV = int.Parse(idsv);
            svhp.IdHP = QLSV_BLL.Instance.GetHpByText(hp).IdHP;

            //MessageBox.Show(svhp.IdSV_HP + " " + svhp.IdSV + " " + svhp.IdHP);

           // QLSV_BLL.Instance.UpdateSV(sv, int.Parse(idsv));
            // QLSV_BLL.Instance.UddateSV_HP(svhp,ma);

            if (textBox1.ReadOnly == true)
            {
                // var a = db.DATNs.Find(int.Parse(ma));
                // da.IdDATN = int.Parse(ma);
                // edit sv


                QLSV_BLL.Instance.UpdateSV(sv, int.Parse(idsv));
                svhp.IdSV_HP = ma;
                QLSV_BLL.Instance.UddateSV_HP(svhp, ma);

            }
            else
            {
                /* if (QLSV_BLL.Instance.AddNewSV(sv,svhp)) MessageBox.Show("thêm mới SV thành công");
                 else
                 {
                     MessageBox.Show("Lỗi thêm mới sv");
                 }*/
                //if (QLSV_BLL.Instance.AddNewSV(sv)) MessageBox.Show("đã thêm " + sv.IdSV.ToString());
                // if (QLSV_BLL.Instance.AddNewSV_HP(svhp)) MessageBox.Show("đã thêm SVHP");
                // MessageBox.Show("SVHP : " + svhp.IdSV + " " + svhp.IdHP);
                if (QLSV_BLL.Instance.check(svhp)) MessageBox.Show("thành công");
                else
                {
                    MessageBox.Show("0");
                }

            }

        }
    }
}
