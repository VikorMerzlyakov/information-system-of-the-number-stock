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
    public partial class Cliner : Form
    {
        public Cliner()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dayBox.Text != "" && monthBox.Text != "" && yearBox.Text != "" && numBox.Text != "" && comboBox1.Text != "")
            {
                string cline;
                if (comboBox1.Text == "Генеральная уборка")
                {
                    cline = "Генеральная_уборка";
                }
                else
                {
                    cline = "Стандартная_уборка";
                }
                if (Admin.AddCline(Convert.ToInt32(dayBox.Text), Convert.ToInt32(monthBox.Text), Convert.ToInt32(yearBox.Text), Convert.ToInt32(numBox.Text), cline))
                {
                    MessageBox.Show("Уборка номера успешно назначена!", "Поздравляю!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //ManagerClass.GetClient();
                }
                else
                {
                    MessageBox.Show("Уборка не была назначена!");
                }
                
            }
            else
            {
                MessageBox.Show("Заполните все обязательные поля!");
            }

        }
    }
}
