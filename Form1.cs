using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp12
{
    public partial class Form1 : Form
    {
        static public string loginActive;
        static public string whois;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DBconection.ConnectionDB();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Autorization.Autorization1(textBox1.Text, textBox2.Text);
                switch (Autorization.Role)
                {
                    case null:
                        {
                            MessageBox.Show("Такого аккаунта не существует!", "Проверте данные и попробуйте снова!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                    case "Админ":
                        {
                            loginActive = textBox1.Text;
                            whois = "Администратор";
                            Autorization.User = textBox1.Text;

                            string familia = Autorization.AutorizacionName(textBox1.Text);
                            Autorization.Familia = familia;
                            MessageBox.Show(familia + ", добро пожаловать в меню администратора!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            FormAdmin admin = new FormAdmin();
                            admin.Show();
                            break;
                        }
                    case "Менеджер":
                        {
                            loginActive = textBox1.Text;
                            whois = "Менеджер";
                            Autorization.User = textBox1.Text;

                            string familia = Autorization.AutorizacionName(textBox1.Text);
                            Autorization.Familia = familia;
                            MessageBox.Show(familia + ", добро пожаловать в меню менеджера!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            FormManager manager = new FormManager();
                            manager.Show();
                            break;
                        }
                }

            }
            else 
            {
                MessageBox.Show("Заполните все обязательные поля!", "Заполнение полей", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
