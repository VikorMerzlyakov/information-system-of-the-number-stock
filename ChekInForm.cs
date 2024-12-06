using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp12
{
    public partial class ChekInForm : Form
    {
        public ChekInForm()
        {
            InitializeComponent();
        }

        private void calculate_Click(object sender, EventArgs e)
        {
            if (chekInText.Text != "" && chekOut.Text != "" && status.Text != "")
            {
                double coast;
                int chek_in = Convert.ToInt32(chekInText.Text);
                int check_out = Convert.ToInt32(chekOut.Text);
                if (status.Text == "Почетный")
                {
                    coast = ((check_out - chek_in) * 1500) * 0.9;
                }
                else
                {
                    coast = ((check_out - chek_in) * 1500);
                }
                price.Text = Convert.ToString(coast);

            }
            else
            {
                MessageBox.Show("Введите обязательные данные!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkIn_Click(object sender, EventArgs e)
        {
            if (familia.Text != "" && name.Text != "" && lastname.Text != "" && passport.Text != "" && chekInText.Text != "" && chekOut.Text != "" && mount.Text != "" && year.Text != "" && status.Text != "" && price.Text != "" && room.Text != "" && radioButton1.Checked)
            {

                if (Admin.AddGuest(familia.Text, name.Text, lastname.Text, Convert.ToInt32(passport.Text), Convert.ToInt32(chekInText.Text), Convert.ToInt32(chekOut.Text), Convert.ToInt32(mount.Text), Convert.ToInt32(year.Text), Convert.ToInt32(room.Text), comment.Text, Convert.ToInt32(price.Text)))
                {
                    MessageBox.Show("Гость успешно заселен!", "Поздравляю!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else
                {
                    MessageBox.Show("Гость не был заселен!");
                }

            }
            else
            {
                MessageBox.Show("Заполните все обязательные поля, в том числе подтвердите получение оплаты!");
            }
        }
    }
}
