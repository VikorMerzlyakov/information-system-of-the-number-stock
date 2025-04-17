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
    // Класс формы для назначения уборки номеров
    public partial class Cliner : Form
    {
        // Конструктор формы
        public Cliner()
        {
            InitializeComponent();
        }

        // Обработчик события нажатия кнопки для назначения уборки
        private void button1_Click(object sender, EventArgs e)
        {
            // Проверка заполненности обязательных полей
            if (dayBox.Text != "" && monthBox.Text != "" && yearBox.Text != "" && numBox.Text != "" && comboBox1.Text != "")
            {
                string cline;
                // Определение типа уборки на основе выбранного значения в comboBox1
                if (comboBox1.Text == "Генеральная уборка")
                {
                    cline = "Генеральная_уборка";
                }
                else
                {
                    cline = "Стандартная_уборка";
                }
                // Попытка добавить запись о уборке в базу данных
                if (Admin.AddCline(Convert.ToInt32(dayBox.Text), Convert.ToInt32(monthBox.Text), Convert.ToInt32(yearBox.Text), Convert.ToInt32(numBox.Text), cline))
                {
                    // Отображение сообщения о успешном назначении уборки
                    MessageBox.Show("Уборка номера успешно назначена!", "Поздравляю!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // ManagerClass.GetClient(); // Возможный вызов метода для получения клиента, закомментирован
                }
                else
                {
                    // Отображение сообщения о неудачном назначении уборки
                    MessageBox.Show("Уборка не была назначена!");
                }
            }
            else
            {
                // Отображение сообщения о необходимости заполнения всех обязательных полей
                MessageBox.Show("Заполните все обязательные поля!");
            }
        }
    }
}
