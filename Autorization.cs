using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp12
{

    internal class Autorization
    {
        static public string Role, Familia, User;

        static public void Autorization1(string login, string password)
        {
            try
            {
                DBconection.msCommand.CommandText = @"SELECT name_role FROM nf_role, acount WHERE login = '" + login + "' and pasword = '" + password + "' and acount.id_role = nf_role.id_role;";
                Object result = DBconection.msCommand.ExecuteScalar();
                if (result != null)
                {
                    Role = result.ToString();
                    User = login;
                }
                else 
                {
                    Role = null;
                    Familia = null;
                }
            }
            catch
            {
                Role = User = null;
                MessageBox.Show("Ошибка авторизации!");
            }
            
           
            
        }
        static public string AutorizacionName(string login)
        {
            try
            {
                DBconection.msCommand.CommandText = @"Select Familia FROM acount WHERE login = '" + login + "';";
                Object result = DBconection.msCommand.ExecuteScalar();
                Familia = result.ToString();
                return Familia;
            }
            catch
            {
                return null;
            }

        } 
    }
}
