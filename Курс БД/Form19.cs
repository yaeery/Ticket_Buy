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

namespace Курс_БД
{
    public partial class Form19 : Form
    {
        string where_string = "";
        string answer_fn = "";
        static DateTime dateTime;
        public Form19()
        {
            InitializeComponent();
        }
        //private void ZPG()
        //{
        //    SqlCommand my_command = new SqlCommand();
        //    my_command.Connection = sqlConnection1;
        //    my_command.CommandType = System.Data.CommandType.Text;
        //    my_command.CommandText = "select НомерПоезда AS 'Номер поезда',Дата_отправления as 'Дата отправления',Статус, Название AS 'Id станции',Платформа from Расписание join Станция ON Расписание.ID_станции = Станция.ID_станции";
        //    sqlConnection1.Open();
        //    var temp = new DataTable();
        //    temp.Load(my_command.ExecuteReader());
        //    Form5.dataGridView1.DataSource = temp;
        //    sqlConnection1.Close();
        //}

        private void Form19_Load(object sender, EventArgs e)
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
            dateTime = DateTime.Today;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if((dateTimePicker1.Value < dateTime) || (comboBox1.SelectedItem == null))
            {
                MessageBox.Show("Некоректная дата или не выбран поезд", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            { 
                sqlConnection1.Open();
                SqlCommand sqlCommand1 = new SqlCommand("dbo.Add_Train_For_Day", sqlConnection1);
                sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter Train = new SqlParameter
                {
                    ParameterName = "@Train_number",
                    Direction = System.Data.ParameterDirection.Input,
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = Convert.ToInt32(comboBox1.Text.ToString())
                };
                SqlParameter date = new SqlParameter
                {
                    ParameterName = "@date_obv",
                    Direction = System.Data.ParameterDirection.Input,
                    SqlDbType = System.Data.SqlDbType.Date,
                    Value = dateTimePicker1.Value
                };
                SqlParameter Result = new SqlParameter
                {
                    ParameterName = "@result",
                    Direction = System.Data.ParameterDirection.Output,
                    SqlDbType = System.Data.SqlDbType.Int,
                };
                sqlCommand1.Parameters.Add(Train);
                sqlCommand1.Parameters.Add(date);
                sqlCommand1.Parameters.Add(Result);
                sqlCommand1.ExecuteNonQuery();
                string Answer = Result.Value.ToString();
                sqlConnection1.Close();
                if (Answer == "1")
                {
                    MessageBox.Show("Вы добавили поезд в этот день:'" + dateTimePicker1.Value.ToString() + "' ", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Answer == "0")
                {
                    MessageBox.Show("На этот день уже сформировано расписание для данного поезда", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if ((dateTimePicker1.Value < dateTime) || (comboBox1.SelectedItem == null))
            {
                MessageBox.Show("Некоректная дата или не выбран поезд", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sqlConnection1.Open();
                SqlCommand sqlCommand1 = new SqlCommand("dbo.Add_Train_For_Week", sqlConnection1);
                sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter Train = new SqlParameter
                {
                    ParameterName = "@Train_number",
                    Direction = System.Data.ParameterDirection.Input,
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = Convert.ToInt32(comboBox1.Text.ToString())
                };
                SqlParameter date = new SqlParameter
                {
                    ParameterName = "@date_obv",
                    Direction = System.Data.ParameterDirection.Input,
                    SqlDbType = System.Data.SqlDbType.Date,
                    Value = dateTimePicker1.Value
                };
                SqlParameter Result = new SqlParameter
                {
                    ParameterName = "@result",
                    Direction = System.Data.ParameterDirection.Output,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Size = 255
                };
                sqlCommand1.Parameters.Add(Train);
                sqlCommand1.Parameters.Add(date);
                sqlCommand1.Parameters.Add(Result);
                sqlCommand1.ExecuteNonQuery();
                string Answer = Result.Value.ToString();
                sqlConnection1.Close();
                if (Answer == "на")
                {
                    MessageBox.Show("Расписание составлено", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    answer_fn = "Расписание составлено";
                    answer_fn += ", однако ";
                    answer_fn += Answer;
                    answer_fn = answer_fn.Remove(answer_fn.Length - 1);
                    answer_fn += " расписание уже составлено";
                    MessageBox.Show(answer_fn, "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
