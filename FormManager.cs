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
    // Форма менеджера для управления клиентами
    public partial class FormManager : Form
    {
        // Конструктор формы
        public FormManager()
        {
            InitializeComponent();
        }

        // Обработчик события нажатия кнопки для возврата на главную форму
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); // Скрытие текущей формы
            Form1 form = new Form1();
            form.Show(); // Отображение главной формы
        }

        // Обработчик события загрузки формы
        private void FormManager_Load(object sender, EventArgs e)
        {
            // Получение данных о клиентах из базы данных
            ManagerClass.GetClient();
            // Установка источника данных для DataGridView
            dataGridView1.DataSource = ManagerClass.dbStatus;
            // Автоматическая установка ширины столбцов в DataGridView
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        // Обработчик события нажатия кнопки для добавления нового клиента
        private void Addbutton_Click(object sender, EventArgs e)
        {
            // Проверка заполненности обязательных полей
            if (LastBox.Text != "" && nameBox.Text != "" && secondBox.Text != "" && passBox.Text != "" && statBox.Text != "")
            {
                // SQL-запрос для проверки наличия клиента с такими данными
                string sql = @"SELECT id_client FROM clients WHERE lastname = '" + LastBox.Text + "';";
                DBconection.msCommand.CommandText = sql;
                Object result = DBconection.msCommand.ExecuteScalar();
                // Проверка результата запроса
                if (result != null)
                {
                    // Отображение сообщения об ошибке, если клиент уже существует
                    MessageBox.Show("У вас есть гость с такими данными", "Дублирование записей!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Попытка добавить нового клиента в базу данных
                    if (ManagerClass.AddClient(LastBox.Text, nameBox.Text, secondBox.Text, Convert.ToInt32(passBox.Text), statBox.Text))
                    {
                        // Отображение сообщения о успешном добавлении клиента
                        MessageBox.Show("Гость успешно добавлен!", "Поздравляю!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Обновление данных в DataGridView
                        ManagerClass.GetClient();
                    }
                    else
                    {
                        // Отображение сообщения о неудачном добавлении клиента
                        MessageBox.Show("Гость не был добавлен!");
                    }
                }
            }
            else
            {
                // Отображение сообщения о необходимости заполнения всех обязательных полей
                MessageBox.Show("Заполните все обязательные поля!");
            }
        }

        // Обработчик события выбора ячейки в DataGridView
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Заполнение текстовых полей данными выбранного клиента
            LastBox.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            nameBox.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            secondBox.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            passBox.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            statBox.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        // Обработчик события нажатия кнопки для удаления клиента
        private void Delbutton_Click(object sender, EventArgs e)
        {
            // Проверка заполненности обязательных полей
            if (LastBox.Text != "" && nameBox.Text != "" && secondBox.Text != "" && passBox.Text != "" && statBox.Text != "")
            {
                // SQL-запрос для проверки наличия клиента с такими данными
                string sql = @"SELECT id_client FROM clients WHERE lastname = '" + LastBox.Text + "';";
                DBconection.msCommand.CommandText = sql;
                Object result = DBconection.msCommand.ExecuteScalar();
                // Проверка результата запроса
                if (result == null)
                {
                    // Отображение сообщения об ошибке, если клиент не существует
                    MessageBox.Show("У вас нет записи с такими данными", "Отсутствие записи!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Попытка удалить клиента из базы данных
                    if (ManagerClass.DeliteClient(Convert.ToInt32(passBox.Text)))
                    {
                        // Отображение сообщения о успешном удалении клиента
                        MessageBox.Show("Гость успешно удален!", "Поздравляю!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Обновление данных в DataGridView
                        ManagerClass.GetClient();
                    }
                    else
                    {
                        // Отображение сообщения о неудачном удалении клиента
                        MessageBox.Show("Гость не был удален!");
                    }
                }
            }
            else
            {
                // Отображение сообщения о необходимости выбора гостя для удаления
                MessageBox.Show("Выберите гостя для удаления!");
            }
        }
    }
}
