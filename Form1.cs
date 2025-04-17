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
    // Главная форма приложения для авторизации пользователей
    public partial class Form1 : Form
    {
        // Статические поля для хранения активного логина и роли пользователя
        static public string loginActive;
        static public string whois;

        // Конструктор формы
        public Form1()
        {
            InitializeComponent();
        }

        // Обработчик события загрузки формы
        private void Form1_Load(object sender, EventArgs e)
        {
            // Установление соединения с базой данных
            DBconection.ConnectionDB();
        }

        // Обработчик события нажатия кнопки для авторизации
        private void button1_Click(object sender, EventArgs e)
        {
            // Проверка заполненности обязательных полей
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                // Вызов метода авторизации из класса Autorization
                Autorization.Autorization1(textBox1.Text, textBox2.Text);
                // Проверка роли пользователя после авторизации
                switch (Autorization.Role)
                {
                    case null:
                        {
                            // Отображение сообщения об ошибке, если аккаунт не существует
                            MessageBox.Show("Такого аккаунта не существует!", "Проверьте данные и попробуйте снова!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                    case "Админ":
                        {
                            // Установка значений для активного логина, роли и имени пользователя
                            loginActive = textBox1.Text;
                            whois = "Администратор";
                            Autorization.User = textBox1.Text;

                            // Получение фамилии пользователя
                            string familia = Autorization.AutorizacionName(textBox1.Text);
                            Autorization.Familia = familia;
                            // Отображение приветственного сообщения для администратора
                            MessageBox.Show(familia + ", добро пожаловать в меню администратора!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Скрытие текущей формы и открытие формы администратора
                            this.Hide();
                            FormAdmin admin = new FormAdmin();
                            admin.Show();
                            break;
                        }
                    case "Менеджер":
                        {
                            // Установка значений для активного логина, роли и имени пользователя
                            loginActive = textBox1.Text;
                            whois = "Менеджер";
                            Autorization.User = textBox1.Text;

                            // Получение фамилии пользователя
                            string familia = Autorization.AutorizacionName(textBox1.Text);
                            Autorization.Familia = familia;
                            // Отображение приветственного сообщения для менеджера
                            MessageBox.Show(familia + ", добро пожаловать в меню менеджера!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Скрытие текущей формы и открытие формы менеджера
                            this.Hide();
                            FormManager manager = new FormManager();
                            manager.Show();
                            break;
                        }
                }
            }
            else 
            {
                // Отображение сообщения о необходимости заполнения всех обязательных полей
                MessageBox.Show("Заполните все обязательные поля!", "Заполнение полей", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
