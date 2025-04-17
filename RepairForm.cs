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
    // Форма для назначения ремонта номеров
    public partial class RepairForm : Form
    {
        // Конструктор формы
        public RepairForm()
        {
            InitializeComponent();
        }

        // Обработчик события нажатия кнопки для назначения ремонта
        private void button1_Click(object sender, EventArgs e)
        {
            // Проверка заполненности обязательных полей
            if (room.Text != "" && mount.Text != "" && year.Text != "" && start.Text != "" && end.Text != "")
            {
                // Попытка назначить ремонт номера с использованием метода Admin.AddRepair
                if (Admin.AddRepair(Convert.ToInt32(start.Text), Convert.ToInt32(end.Text), Convert.ToInt32(mount.Text), Convert.ToInt32(year.Text), Convert.ToInt32(room.Text), comment.Text))
                {
                    // Отображение сообщения о успешном назначении ремонта
                    MessageBox.Show("Ремонт номера успешно назначен!", "Поздравляю!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Обновление данных о клиентах
                    ManagerClass.GetClient();
                }
                else
                {
                    // Отображение сообщения о неудачном назначении ремонта
                    MessageBox.Show("Ремонт не был назначен!");
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
