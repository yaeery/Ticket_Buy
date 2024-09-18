using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Курс_БД
{
    public partial class Form15 : Form
    {
        string where_string = "";
        public Form15()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            where_string = "";
            where_string += " where ";
            dataGridView1.Columns.Clear();
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                MessageBox.Show("Некоректный диапазон", "Ошибка выбора", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                where_string += " Дата between '" + dateTimePicker1.Value.ToString("dd-MM-yyyy") + "' and '" + dateTimePicker2.Value.ToString("dd-MM-yyyy") + "' ";

                if (comboBox1.SelectedItem == null)
                {
                    where_string += "";
                    SqlCommand my_command = new SqlCommand();
                    my_command.Connection = sqlConnection1;
                    my_command.CommandType = System.Data.CommandType.Text;
                    my_command.CommandText = "select НомерПоезда, COUNT(*) as 'Проданные билеты' from Билет" + where_string + "and Активность = 'F' group by НомерПоезда";
                    sqlConnection1.Open();
                    var temp = new DataTable();
                    temp.Load(my_command.ExecuteReader());
                    dataGridView1.DataSource = temp;
                    sqlConnection1.Close();
                    int x = 0;
                    for (int j = 0; j < temp.Rows.Count; j++)
                    {
                        x += Convert.ToInt32(temp.Rows[j].ItemArray[1]);
                    }
                    label5.Text = x.ToString();
                }
                else
                {
                    where_string += " and";
                    where_string += " НомерПоезда = '" + comboBox1.SelectedItem.ToString() + "' ";
                    SqlCommand my_command = new SqlCommand();
                    my_command.Connection = sqlConnection1;
                    my_command.CommandType = System.Data.CommandType.Text;
                    my_command.CommandText = "select НомерПоезда, COUNT(*) as 'Проданные билеты' from Билет" + where_string + "and Активность = 'F' group by НомерПоезда";
                    sqlConnection1.Open();
                    var temp = new DataTable();
                    temp.Load(my_command.ExecuteReader());
                    dataGridView1.DataSource = temp;
                    sqlConnection1.Close();
                    int x = 0;
                    for (int j = 0; j < temp.Rows.Count; j++)
                    {
                         x += Convert.ToInt32(temp.Rows[j].ItemArray[1]);
                    }
                    label5.Text = x.ToString();
                }
            }
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            sqlConnection1.ConnectionString = EnteryForm.SQL_C;
            sqlConnection1.Open();
            SqlCommand sqlCommand_Cl = new SqlCommand("SELECT Номер_поезда FROM Поезд", sqlConnection1);
            SqlDataReader Type = sqlCommand_Cl.ExecuteReader();
            while (Type.Read())
            {
                comboBox1.Items.Add(Type[0].ToString());
            }
            Type.Close();
            sqlConnection1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
