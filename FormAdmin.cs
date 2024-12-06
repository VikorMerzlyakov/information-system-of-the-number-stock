using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp12
{
    public partial class FormAdmin : Form
    {
        
        int dayInMouth = 30;
        public FormAdmin()
        {
            InitializeComponent();

        }
        private void FormAdmin_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < dayInMouth; i++)
{
                dataGridView1.Columns.Add(Convert.ToString(i), Convert.ToString(i+1));
            }
            //текущее кол-во колонок в DataGridView
            int dgvColsCount = dataGridView1.Columns.Count;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

 



        private void button2_Click(object sender, EventArgs e)
        {
            int month = 0;
            string mounts = comboBox1.SelectedItem.ToString();
            switch (mounts)
            {
                case "Январь":
                    {
                        month = 1;
                        break;
                    }
                case "Февраль":
                    {
                        month = 2;
                        break;
                    }
                case "Март":
                    {
                        month = 3;
                        break;
                    }
                case "Апрель":
                    {
                        month = 4;
                        break;
                    }
                case "Май":
                    {
                        month = 5;
                        break;
                    }
                case "Июнь":
                    {
                        month = 6;
                        break;
                    }
                case "Июль":
                    {
                        month = 7;
                        break;
                    }
                case "Август":
                    {
                        month = 8;
                        break;
                    }
                case "Сентябрь":
                    {
                        month = 9;
                        break;
                    }
                case "Октябрь":
                    {
                        month = 10;
                        break;
                    }
                case "Ноябрь":
                    {
                        month = 11;
                        break;
                    }
                case "Декабрь":
                    {
                        month = 12;
                        break;
                    }
            }

            int year = Convert.ToInt32(comboBox2.SelectedItem.ToString());

            dayInMouth = DateTime.DaysInMonth(year, month);
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(" ", "Номер комнаты");
            for (int i = 0; i < dayInMouth; i++)
            {
                dataGridView1.Columns.Add(Convert.ToString(i), Convert.ToString(i + 1));
            }
            for (int i = 0; i < 10; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = i + 1;
            }

            //текущее кол-во колонок в DataGridView
            int dgvColsCount = dataGridView1.Columns.Count;
            string text = Admin.AdminCalend(month, year);
            string[] words = text.Split(' ');


            for (int i = 0; i <= words.Length; i+=4)
            {
                try
                {
                    int room = Convert.ToInt32(words[i + 3]);
                    int checkin = Convert.ToInt32(words[i + 1]);
                    int exit = Convert.ToInt32(words[i + 2]);
                    if (words[i] == "Генеральная_уборка" ^ words[i] == "Стандартная_уборка")
                    {
                        dataGridView1.Rows[room].Cells[checkin].Style.BackColor = Color.Orange;
                        dataGridView1.Rows[room].Cells[checkin].Value = words[i];
                    }
                    else if (words[i] == "Ремонт")
                    {
                        for (int j = checkin; j <= exit; j++)
                        {

                            dataGridView1.Rows[room].Cells[j].Style.BackColor = Color.Red;
                            dataGridView1.Rows[room].Cells[j].Value = words[i];
                        }
                    }
                    else
                    {
                        for (int j = checkin; j <= exit; j++)
                        {

                            dataGridView1.Rows[room].Cells[j].Style.BackColor = Color.Green;
                            dataGridView1.Rows[room].Cells[j].Value = words[i];
                        }
                        
                    }
                }
                catch { break; }


            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            FreezeBand(dataGridView1.Columns[0]);
        }

        private static void FreezeBand(DataGridViewBand band)
        {
            band.Frozen = true;
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = Color.WhiteSmoke;
            band.DefaultCellStyle = style;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cliner newForm = new Cliner();
            newForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RepairForm newForm = new RepairForm();
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChekInForm newForm = new ChekInForm();
            newForm.Show();
        }
    }
}
