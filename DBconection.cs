using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp12
{
    // Класс для управления подключением к базе данных
    internal class DBconection
    {
        // Строка подключения к базе данных
        static string DBconect = "server = localhost; user=root; password=; database=room_reservations";

        // Адаптер данных для взаимодействия с базой данных
        static public MySqlDataAdapter msDataAdapter;

        // Соединение с базой данных
        static MySqlConnection myconnect;

        // Команда для выполнения SQL-запросов
        static public MySqlCommand msCommand;

        // Метод для установления соединения с базой данных
        public static bool ConnectionDB()
        {
            try 
            {
                // Создание объекта подключения к базе данных
                myconnect = new MySqlConnection(DBconect);
                // Открытие соединения
                myconnect.Open();
                // Создание объекта команды для выполнения SQL-запросов
                msCommand = new MySqlCommand();
                // Установка соединения для команды
                msCommand.Connection = myconnect;
                // Создание адаптера данных для взаимодействия с базой данных
                msDataAdapter = new MySqlDataAdapter(msCommand);
                // Возврат true в случае успешного подключения
                return true;
            }
            catch
            {
                // Отображение сообщения об ошибке в случае неудачного подключения
                MessageBox.Show("Ошибка соединения с базой данных!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Возврат false в случае неудачного подключения
                return false;
            }
        }

        // Метод для закрытия соединения с базой данных
        public static void CloseDB()
        {
            myconnect.Close();
        }

        // Метод для получения текущего соединения с базой данных
        public MySqlConnection GetConnection()
        { 
            return myconnect; 
        }
    }
}
