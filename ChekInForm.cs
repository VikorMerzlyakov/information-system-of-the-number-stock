using System;
using System.Collections.Generic;
using System.ComponentModel; // Предоставляет классы для реализации поведения компонентов и контролов во время выполнения и разработки
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp12
{
    // Класс формы для заселения гостя
    public partial class ChekInForm : Form
    {
        // Конструктор формы
        public ChekInForm()
        {
            InitializeComponent();
        }

        // Обработчик события нажатия кнопки для расчета стоимости проживания
        private void calculate_Click(object sender, EventArgs e)
        {
            // Проверка заполненности обязательных полей
            if (chekInText.Text != "" && chekOut.Text != "" && status.Text != "")
            {
                double coast;
                int chek_in = Convert.ToInt32(chekInText.Text); // Преобразование текста даты заезда в целое число
                int check_out = Convert.ToInt32(chekOut.Text); // Преобразование текста даты выезда в целое число
                // Расчет стоимости проживания с учетом статуса гостя
                if (status.Text == "Почетный")
                {
                    coast = ((check_out - chek_in) * 1500) * 0.9; // Скидка 10% для почетных гостей
                }
                else
                {
                    coast = ((check_out - chek_in) * 1500); // Полная стоимость для обычных гостей
                }
                price.Text = Convert.ToString(coast); // Установка рассчитанной стоимости в текстовое поле
            }
            else
            {
                // Отображение сообщения об ошибке, если обязательные поля не заполнены
                MessageBox.Show("Введите обязательные данные!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчик события нажатия кнопки для заселения гостя
        private void checkIn_Click(object sender, EventArgs e)
        {
            // Проверка заполненности всех обязательных полей и подтверждения оплаты
            if (familia.Text != "" && name.Text != "" && lastname.Text != "" && passport.Text != "" && chekInText.Text != "" && chekOut.Text != "" && mount.Text != "" && year.Text != "" && status.Text != "" && price.Text != "" && room.Text != "" && radioButton1.Checked)
            {
                // Попытка добавить запись о госте в базу данных
                if (Admin.AddGuest(familia.Text, name.Text, lastname.Text, Convert.ToInt32(passport.Text), Convert.ToInt32(chekInText.Text), Convert.ToInt32(chekOut.Text), Convert.ToInt32(mount.Text), Convert.ToInt32(year.Text), Convert.ToInt32(room.Text), comment.Text, Convert.ToInt32(price.Text)))
                {
                    // Отображение сообщения о успешном заселении гостя
                    MessageBox.Show("Гость успешно заселен!", "Поздравляю!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Отображение сообщения о неудачном заселении гостя
                    MessageBox.Show("Гость не был заселен!");
                }
            }
            else
            {
                // Отображение сообщения о необходимости заполнения всех обязательных полей и подтверждения оплаты
                MessageBox.Show("Заполните все обязательные поля, в том числе подтвердите получение оплаты!");
            }
        }
    }
}
