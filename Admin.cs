using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp12
{
    // Класс Admin наследуется от DBconection и содержит методы для администрирования гостиницы
    internal class Admin : DBconection
    {
        // Статические поля для хранения роли, фамилии, имени пользователя и клиента
        static public string Role, Familia, User, Cline;

        // Таблица для хранения данных администратора
        static public DataTable dbAdmin = new DataTable();

        // Метод для получения календаря бронирований за указанный месяц и год
        static public string AdminCalend(int mount, int year)
        {
            // SQL-запрос для выборки записей из таблицы reservation за указанный месяц и год
            string sql = @"SELECT * FROM reservation WHERE mount = '" + mount + "' and year = '" + year + "';";
            // Создание подключения к базе данных MySQL
            MySqlConnection con = new MySqlConnection("server = localhost; user=root; password=; database=room_reservations");
            // Создание команды SQL
            MySqlCommand cmd = new MySqlCommand(sql, con);

            // Открытие соединения с базой данных
            con.Open();

            // Выполнение команды и получение ридера для чтения данных
            MySqlDataReader reader = cmd.ExecuteReader();
            string text = "";
            // Чтение данных из ридера и формирование строки с информацией о бронировании
            while (reader.Read())
            {
                text += reader.GetString("familia_client") + " "; // Фамилия клиента
                text += reader.GetInt32("checkin_date") + " ";   // Дата заезда
                text += reader.GetInt32("exit_date") + " ";      // Дата выезда
                text += reader.GetInt32("room") + " ";           // Номер комнаты
            }
            // Закрытие соединения с базой данных
            con.Close();
            // Возврат строки с информацией о бронировании
            return text;
        }

        // Метод для добавления записи о клиенте в таблицу reservation
        static public bool AddCline(int day, int month, int year, int num, string combo)
        {
            try
            {
                // SQL-команда для вставки новой записи в таблицу reservation
                DBconection.msCommand.CommandText = @"INSERT INTO reservation (familia_client, checkin_date, exit_date, room, mount, year) VALUES ('" + combo + "','" + day + "','" + day + "','" + (num - 1) + "','" + month + "','" + year + "');";
                // Выполнение команды и получение результата
                Object result = DBconection.msCommand.ExecuteScalar();
                // Возврат true в случае успешного выполнения команды
                return true;
            }
            catch
            {
                // Возврат false в случае возникновения ошибки
                return false;
            }
        }

        // Метод для добавления записи о ремонте в таблицу reservation
        static public bool AddRepair(int start, int end, int mount, int year, int room, string comment)
        {
            try
            {
                // SQL-команда для вставки новой записи о ремонте в таблицу reservation
                DBconection.msCommand.CommandText = @"INSERT INTO reservation (familia_client, checkin_date, exit_date, room, mount, year, comment) VALUES ('Ремонт','" + start + "','" + end + "','" + (room - 1) + "','" + mount + "','" + year + "', '" + comment + "');";
                // Выполнение команды и получение результата
                Object result = DBconection.msCommand.ExecuteScalar();
                // Возврат true в случае успешного выполнения команды
                return true;
            }
            catch
            {
                // Возврат false в случае возникновения ошибки
                return false;
            }
        }

        // Метод для добавления записи о госте в таблицу reservation
        static public bool AddGuest(string familia, string name, string lastname, int passport, int chekIn, int chekOut, int mount, int year, int room, string comment, int price)
        {
            try
            {
                // SQL-команда для вставки новой записи о госте в таблицу reservation
                DBconection.msCommand.CommandText = @"INSERT INTO reservation (familia_client, checkin_date, exit_date, room, mount, year, comment, price) VALUES ('" + familia + "','" + chekIn + "','" + chekOut + "','" + (room - 1) + "','" + mount + "','" + year + "', '" + comment + "', '" + price + "');";
                // Выполнение команды и получение результата
                Object result = DBconection.msCommand.ExecuteScalar();
                // Возврат true в случае успешного выполнения команды
                return true;
            }
            catch
            {
                // Возврат false в случае возникновения ошибки
                return false;
            }
        }
    }
}
