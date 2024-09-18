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
    public partial class Form17 : Form
    {
        string where_string = "";
        public Form17()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form17_Load(object sender, EventArgs e)
        {
            sqlConnection1.ConnectionString = EnteryForm.SQL_C;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                where_string += " Дата_отправления between '" + dateTimePicker1.Value.ToString("dd-MM-yyyy") + "' and '" + dateTimePicker2.Value.ToString("dd-MM-yyyy") + "' ";

                if ((textBox1 == null) || (textBox1.Text == ""))
                {
                    where_string += "";
                    SqlCommand my_command = new SqlCommand();
                    my_command.Connection = sqlConnection1;
                    my_command.CommandType = System.Data.CommandType.Text;
                    my_command.CommandText = "select НомерПоезда as 'Номер поезда ', COUNT(*) as 'число опозданий' from Расписание" + where_string + "and статус = 'опаздывает' group by НомерПоезда,Дата_отправления ";
                    sqlConnection1.Open();
                    var temp = new DataTable();
                    temp.Load(my_command.ExecuteReader());
                    dataGridView1.DataSource = temp;
                    sqlConnection1.Close();
                }
                else
                {
                    where_string += " and";
                    where_string += " НомерПоезда = '" + textBox1.Text.ToString() + "' ";
                    SqlCommand my_command = new SqlCommand();
                    my_command.Connection = sqlConnection1;
                    my_command.CommandType = System.Data.CommandType.Text;
                    my_command.CommandText = "select НомерПоезда as 'Номер поезда ', COUNT(*) as 'число опозданий' from Расписание" + where_string + "and статус = 'опаздывает' group by НомерПоезда,Дата_отправления ";
                    sqlConnection1.Open();
                    var temp = new DataTable();
                    temp.Load(my_command.ExecuteReader());
                    dataGridView1.DataSource = temp;
                    sqlConnection1.Close();
                }
                int i = dataGridView1.Rows.Count - 1;
                label5.Text = i.ToString();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
