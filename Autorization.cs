using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates; // Используется пространство имен для работы с X509-сертификатами
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp12
{
    // Класс Autorization для выполнения операций аутентификации и получения информации о пользователе
    internal class Autorization
    {
        // Статические поля для хранения роли, фамилии и имени пользователя
        static public string Role, Familia, User;

        // Метод для аутентификации пользователя по логину и паролю
        static public void Autorization1(string login, string password)
        {
            try
            {
                // SQL-команда для выборки роли пользователя из таблиц nf_role и acount по логину и паролю
                DBconection.msCommand.CommandText = @"SELECT name_role FROM nf_role, acount WHERE login = '" + login + "' and pasword = '" + password + "' and acount.id_role = nf_role.id_role;";
                // Выполнение команды и получение результата
                Object result = DBconection.msCommand.ExecuteScalar();
                // Проверка наличия результата
                if (result != null)
                {
                    Role = result.ToString(); // Установка роли пользователя
                    User = login;             // Установка имени пользователя
                }
                else 
                {
                    Role = null;              // Обнуление роли
                    Familia = null;           // Обнуление фамилии
                }
            }
            catch
            {
                Role = User = null;           // Обнуление роли и имени пользователя в случае ошибки
                MessageBox.Show("Ошибка авторизации!"); // Отображение сообщения об ошибке
            }
        }

        // Метод для получения фамилии пользователя по логину
        static public string AutorizacionName(string login)
        {
            try
            {
                // SQL-команда для выборки фамилии пользователя из таблицы acount по логину
                DBconection.msCommand.CommandText = @"Select Familia FROM acount WHERE login = '" + login + "';";
                // Выполнение команды и получение результата
                Object result = DBconection.msCommand.ExecuteScalar();
                // Установка фамилии пользователя
                Familia = result.ToString();
                // Возврат фамилии пользователя
                return Familia;
            }
            catch
            {
                // Возврат null в случае возникновения ошибки
                return null;
            }
        } 
    }
}
