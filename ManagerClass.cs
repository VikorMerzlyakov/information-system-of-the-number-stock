using Mysqlx.Crud;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp12
{
    // Класс ManagerClass для управления данными клиентов, наследующий от DBconection
    internal class ManagerClass : DBconection
    {
        // Таблица для хранения данных о клиентах
        static public DataTable dbStatus = new DataTable();

        // Метод для получения данных о клиентах из базы данных
        static public void GetClient()
        {
            try
            {
                // SQL-запрос для выборки всех данных из таблицы clients
                DBconection.msCommand.CommandText = "Select * From clients;";
                dbStatus.Clear(); // Очистка существующих данных в таблице
                DBconection.msDataAdapter.SelectCommand = DBconection.msCommand; // Установка команды для адаптера данных
                DBconection.msDataAdapter.Fill(dbStatus); // Заполнение таблицы данными из базы данных
            }
            catch
            {
                // Отображение сообщения об ошибке при получении данных
                MessageBox.Show("Ошибка при получении данных!", "Ошибка!Ошибка!Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Метод для добавления нового клиента в базу данных
        static public bool AddClient(string lastname, string name, string secondname, int passport, string status)
        {
            try
            {
                // SQL-запрос для вставки нового клиента в таблицу clients
                DBconection.msCommand.CommandText = "INSERT INTO clients (lastname, name, second_name, passport, statys) VALUES ('" + lastname + "', '" + name + "', '" + secondname + "', '" + passport + "', '" + status + "');";
                // Выполнение команды и проверка количества затронутых строк
                if (DBconection.msCommand.ExecuteNonQuery() > 0)
                {
                    return true; // Возврат true в случае успешного добавления
                }
                else
                {
                    return false; // Возврат false в случае неудачного добавления
                }
            }
            catch
            {
                // Отображение сообщения об ошибке при добавлении данных
                MessageBox.Show("Ошибка при добавлении данных!", "Ошибка!Ошибка!Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Возврат false в случае ошибки
            }
        }

        // Метод для редактирования данных существующего клиента в базе данных
        static public bool EditClient(int id, string lastname, string name, string secondname, int passport, string status)
        {
            try
            {
                // SQL-запрос для обновления данных клиента в таблице clients
                msCommand.CommandText = "UPDATE clients SET lastname= '" + lastname + "',name= '" + name + "',second_name= '" + secondname + "',passport= '" + passport + "',statys= '" + status + "' WHERE id_client= '" + id + "'; ";
                // Выполнение команды и проверка количества затронутых строк
                if (msCommand.ExecuteNonQuery() > 0) { return true; } // Возврат true в случае успешного обновления
                else { return false; } // Возврат false в случае неудачного обновления
            }
            catch
            {
                // Отображение сообщения об ошибке при редактировании данных
                MessageBox.Show("Ошибка при редактировании данных!", "Ошибка!Ошибка!Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Возврат false в случае ошибки
            }
        }

        // Метод для удаления клиента из базы данных по номеру паспорта
        static public bool DeliteClient(int pass)
        {
            try
            {
                // SQL-запрос для удаления клиента из таблицы clients по номеру паспорта
                msCommand.CommandText = "DELETE FROM clients  WHERE passport= '" + pass + "'; ";
                msCommand.ExecuteNonQuery(); // Выполнение команды
                return true; // Возврат true в случае успешного удаления
            }
            catch
            {
                // Отображение сообщения об ошибке при удалении данных
                MessageBox.Show("Ошибка при удалении данных!", "Ошибка!Ошибка!Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Возврат false в случае ошибки
            }
        }
    }
}
