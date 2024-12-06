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
    internal class Admin : DBconection
    {
        static public string Role, Familia, User, Cline;

        static public DataTable dbAdmin = new DataTable();

        static public string AdminCalend(int mount, int year)
        {
            string sql = @"SELECT * FROM reservation WHERE mount = '" + mount + "' and year = '" + year + "';";
            MySqlConnection con = new MySqlConnection("server = localhost; user=root; password=; database=room_reservations");
            MySqlCommand cmd = new MySqlCommand(sql, con);

            con.Open();

            MySqlDataReader reader = cmd.ExecuteReader();
            string text = "";
            while (reader.Read())
            {
                text += reader.GetString("familia_client") + " ";
                text += reader.GetInt32("checkin_date") + " ";
                text += reader.GetInt32("exit_date") + " ";
                text += reader.GetInt32("room") + " ";
            }
            con.Close();
            return text;

        }


        static public bool AddCline(int day, int month, int year, int num, string combo)
        {
            try
            {
                DBconection.msCommand.CommandText = @"INSERT INTO reservation (familia_client, checkin_date, exit_date, room, mount, year) VALUES ('" + combo + "','" + day + "','" + day + "','" + (num - 1) + "','" + month + "','" + year + "');";
                Object result = DBconection.msCommand.ExecuteScalar();
                return true;
            }
            catch
            {
                return false;
            }
        }

        static public bool AddRepair(int start, int end, int mount, int year, int room, string comment)
        {
            try
            {
                DBconection.msCommand.CommandText = @"INSERT INTO reservation (familia_client, checkin_date, exit_date, room, mount, year, comment) VALUES ('Ремонт','" + start + "','" + end + "','" + (room - 1) + "','" + mount + "','" + year + "', '" + comment + "');";
                Object result = DBconection.msCommand.ExecuteScalar();
                return true;
            }
            catch
            {
                return false;
            }
        }

        static public bool AddGuest(string familia, string name, string lastname, int passport, int chekIn, int chekOut, int mount, int year, int room, string comment, int price)
        {
            try
            {
                DBconection.msCommand.CommandText = @"INSERT INTO reservation (familia_client, checkin_date, exit_date, room, mount, year, comment, price) VALUES ('" + familia + "','" + chekIn + "','" + chekOut + "','" + (room - 1) + "','" + mount + "','" + year + "', '" + comment + "', '" + price + "');";
                Object result = DBconection.msCommand.ExecuteScalar();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
