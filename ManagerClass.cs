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
    internal class ManagerClass : DBconection
    {
        static public DataTable dbStatus = new DataTable();
        static public void GetClient()
        {
            try
            {
                DBconection.msCommand.CommandText = "Select * From clients;";
                dbStatus.Clear();
                DBconection.msDataAdapter.SelectCommand = DBconection.msCommand;
                DBconection.msDataAdapter.Fill(dbStatus);
            }
            catch
            {
                MessageBox.Show("Ошибка при получении данных!", "Ошибка!Ошибка!Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static public bool AddClient(string lastname, string name, string secondname, int passport, string status)
        {
            try
            {
                DBconection.msCommand.CommandText = "INSERT INTO clients (lastname, name, second_name, passport, statys) VALUES ('" + lastname + "', '" + name + "', '" + secondname + "', '" + passport + "', '" + status + "');";
                if (DBconection.msCommand.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении данных!", "Ошибка!Ошибка!Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        static public bool EditClient(int id, string lastname, string name, string secondname, int passport, string status)
        {
            try
            {
                msCommand.CommandText = "UPDATE clients SET lastname= '" + lastname + "',name= '" + name + "',second_name= '" + secondname + "',passport= '" + passport + "',statys= '" + status + "' WHERE id_client= '" + id + "'; ";
                if (msCommand.ExecuteNonQuery() > 0) { return true; }
                else { return false; }
            }
            catch
            {
                MessageBox.Show("Ошибка при редактировании данных!", "Ошибка!Ошибка!Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        static public bool DeliteClient(int pass)
        {
            try
            {
                msCommand.CommandText = "DELETE FROM clients  WHERE passport= '" + pass + "'; ";
                msCommand.ExecuteNonQuery();
                return true;
            }
            catch
            {
                MessageBox.Show("Ошибка при удалении данных!", "Ошибка!Ошибка!Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false ;

            }
        }
    }
}