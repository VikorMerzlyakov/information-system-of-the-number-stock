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
    public partial class FormManager : Form
    {
        public FormManager()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void FormManager_Load(object sender, EventArgs e)
        {
            ManagerClass.GetClient();
            dataGridView1.DataSource = ManagerClass.dbStatus;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

 
        private void Addbutton_Click(object sender, EventArgs e)
        {
            if(LastBox.Text != "" &&  nameBox.Text != "" && secondBox.Text != "" && passBox.Text != "" && statBox.Text != "")
            {
                string sql = @"SELECT id_client FROM clients WHERE lastname = '" + LastBox.Text + "';";
                DBconection.msCommand.CommandText = sql;
                Object result = DBconection.msCommand.ExecuteScalar();
                if (result != null)
                {
                    MessageBox.Show("У вас есть гость с такими данными", "Дублирование записей!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else 
                {
                    if(ManagerClass.AddClient(LastBox.Text, nameBox.Text, secondBox.Text, Convert.ToInt32(passBox.Text), statBox.Text))
                    {
                        MessageBox.Show("Гость успешно добавлен!","Поздравляю!", MessageBoxButtons.OK,MessageBoxIcon.Information);
                        ManagerClass.GetClient();
                    }
                    else
                    {
                        MessageBox.Show("Гость не был добавлен!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните все обязательные поля!");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LastBox.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            nameBox.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            secondBox.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            passBox.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            statBox.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void Delbutton_Click(object sender, EventArgs e)
        {
            if (LastBox.Text != "" && nameBox.Text != "" && secondBox.Text != "" && passBox.Text != "" && statBox.Text != "")
            {
                string sql = @"SELECT id_client FROM clients WHERE lastname = '" + LastBox.Text + "';";
                DBconection.msCommand.CommandText = sql;
                Object result = DBconection.msCommand.ExecuteScalar();
                if (result == null)
                {
                    MessageBox.Show("У вас нет записи с такими данными", "Отсутствие записи!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (ManagerClass.DeliteClient(Convert.ToInt32(passBox.Text)))
                    {
                        MessageBox.Show("Гость успешно удулен!", "Поздравляю!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ManagerClass.GetClient();
                    }
                    else
                    {
                        MessageBox.Show("Гость не был удален!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите гостя для удаления!");
            }
        }
    }
}
