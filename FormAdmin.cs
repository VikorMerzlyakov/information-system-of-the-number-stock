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
    // Форма администратора для управления бронированием и уборкой номеров
    public partial class FormAdmin : Form
    {
        // Переменная для хранения количества дней в месяце
        int dayInMouth = 30;

        // Конструктор формы
        public FormAdmin()
        {
            InitializeComponent();
        }

        // Обработчик события загрузки формы
        private void FormAdmin_Load(object sender, EventArgs e)
        {
            // Добавление столбцов в DataGridView для каждого дня месяца
            for (int i = 0; i < dayInMouth; i++)
            {
                dataGridView1.Columns.Add(Convert.ToString(i), Convert.ToString(i + 1));
            }
            // Получение текущего количества столбцов в DataGridView
            int dgvColsCount = dataGridView1.Columns.Count;
        }

        // Обработчик события нажатия кнопки для возврата на главную форму
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); // Скрытие текущей формы
            Form1 form = new Form1();
            form.Show(); // Отображение главной формы
        }

        // Обработчик события нажатия кнопки для обновления календаря бронирований
        private void button2_Click(object sender, EventArgs e)
        {
            int month = 0;
            string mounts = comboBox1.SelectedItem.ToString();
            // Определение номера месяца на основе выбранного значения в comboBox1
            switch (mounts)
            {
                case "Январь":
                    month = 1;
                    break;
                case "Февраль":
                    month = 2;
                    break;
                case "Март":
                    month = 3;
                    break;
                case "Апрель":
                    month = 4;
                    break;
                case "Май":
                    month = 5;
                    break;
                case "Июнь":
                    month = 6;
                    break;
                case "Июль":
                    month = 7;
                    break;
                case "Август":
                    month = 8;
                    break;
                case "Сентябрь":
                    month = 9;
                    break;
                case "Октябрь":
                    month = 10;
                    break;
                case "Ноябрь":
                    month = 11;
                    break;
                case "Декабрь":
                    month = 12;
                    break;
            }

            // Получение выбранного года из comboBox2
            int year = Convert.ToInt32(comboBox2.SelectedItem.ToString());

            // Определение количества дней в выбранном месяце
            dayInMouth = DateTime.DaysInMonth(year, month);
            dataGridView1.Columns.Clear(); // Очистка существующих столбцов
            dataGridView1.Columns.Add(" ", "Номер комнаты"); // Добавление столбца для номера комнаты
            // Добавление столбцов для каждого дня месяца
            for (int i = 0; i < dayInMouth; i++)
            {
                dataGridView1.Columns.Add(Convert.ToString(i), Convert.ToString(i + 1));
            }
            // Добавление строк для каждой комнаты (предполагается 10 комнат)
            for (int i = 0; i < 10; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = i + 1;
            }

            // Получение текущего количества столбцов в DataGridView
            int dgvColsCount = dataGridView1.Columns.Count;
            // Получение данных о бронировании из базы данных
            string text = Admin.AdminCalend(month, year);
            string[] words = text.Split(' ');

            // Заполнение DataGridView данными о бронировании
            for (int i = 0; i <= words.Length - 4; i += 4)
            {
                try
                {
                    int room = Convert.ToInt32(words[i + 3]); // Номер комнаты
                    int checkin = Convert.ToInt32(words[i + 1]); // Дата заезда
                    int exit = Convert.ToInt32(words[i + 2]); // Дата выезда
                    if (words[i] == "Генеральная_уборка" || words[i] == "Стандартная_уборка")
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
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Автоматическая установка ширины столбцов
            FreezeBand(dataGridView1.Columns[0]); // Заморозка первого столбца
        }

        // Метод для заморозки столбца в DataGridView
        private static void FreezeBand(DataGridViewBand band)
        {
            band.Frozen = true; // Заморозка столбца
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = Color.WhiteSmoke; // Установка цвета фона
            band.DefaultCellStyle = style; // Применение стиля к столбцу
        }

        // Обработчик события нажатия кнопки для открытия формы назначения уборки
        private void button4_Click(object sender, EventArgs e)
        {
            Cliner newForm = new Cliner();
            newForm.Show(); // Отображение формы назначения уборки
        }

        // Обработчик события нажатия кнопки для открытия формы назначения ремонта
        private void button5_Click(object sender, EventArgs e)
        {
            RepairForm newForm = new RepairForm();
            newForm.Show(); // Отображение формы назначения ремонта
        }

        // Обработчик события нажатия кнопки для открытия формы заселения гостя
        private void button3_Click(object sender, EventArgs e)
        {
            ChekInForm newForm = new ChekInForm();
            newForm.Show(); // Отображение формы заселения гостя
        }
    }
}
