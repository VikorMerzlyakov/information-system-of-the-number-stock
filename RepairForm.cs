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
    public partial class RepairForm : Form
    {
        public RepairForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (room.Text != "" && mount.Text != "" && year.Text != "" && start.Text != "" && end.Text != "")
            {

                if (Admin.AddRepair(Convert.ToInt32(start.Text), Convert.ToInt32(end.Text), Convert.ToInt32(mount.Text), Convert.ToInt32(year.Text), Convert.ToInt32(room.Text), comment.Text))
                {
                    MessageBox.Show("Ремонт номера успешно назначен!", "Поздравляю!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ManagerClass.GetClient();
                }
                else
                {
                    MessageBox.Show("Ремонт не был назначен!");
                }

            }
            else
            {
                MessageBox.Show("Заполните все обязательные поля!");
            }
        }
    }
}
