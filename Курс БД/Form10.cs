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
using System.Globalization;

namespace Курс_БД
{
    public partial class Form10 : Form
    {
        public bool CheckLoginPassword(string login)
        {
            sqlConnection1.Open();
            SqlCommand sqlCommand1= new SqlCommand("dbo.CheckLoginPassword", sqlConnection1);
            sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter LoginParam = new SqlParameter
            {
                ParameterName = "@Login",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Size = 10,
                Value = login
            };
            SqlParameter Result = new SqlParameter
            {
                ParameterName = "@RESULT",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.VarChar,
                Size = 10
            };
            sqlCommand1.Parameters.Add(LoginParam);
            sqlCommand1.Parameters.Add(Result);
            sqlCommand1.ExecuteNonQuery();
            string Answer = Result.Value.ToString();
            sqlConnection1.Close();
            if (Answer == "yes")
            {
                return true;
            }
            else
                return false;
        }
        public Form10()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form8 form8 = new Form8();
            form8.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool CheckCorrect = false;
            string message = "";
            if ((textBox1.Text == null) || (textBox1.Text == ""))
            {
                CheckCorrect = true;
                message += "Некоректное ФИО";
                message += "\n";
            }
            else if ((textBox1.Text != null) && (textBox1.Text.Length > 0))
            {
                string x = textBox1.Text;
                string v = x.Trim();
                if (v == "")
                {
                    CheckCorrect = true;
                    message += "Некоректное ФИО";
                    message += "\n";
                    textBox1.Text = null;
                }
            }
            //-----------------------------------------------------------------------
            if ((textBox4.Text == null) || ((textBox4.Text != null) && ((textBox4.Text.Length != 11) || (!Int64.TryParse(textBox4.Text, out Int64 num2)))))
            {
                CheckCorrect = true;
                message += "Некоректный телефон";
                message += "\n";
            }
            //-----------------------------------------------------------------------
            string Mask = "";
            if (dateTimePicker1.Value > DateTime.Now)
            {
                CheckCorrect = true;
                message += "Некоректная дата рождения";
                message += "\n";
            }
            //-----------------------------------------------------------------------
            if ((textBox3.Text == null) || (textBox3.Text == ""))
            {
                CheckCorrect = true;
                message += "Некоректный email";
                message += "\n";
            }
            else if ((textBox3.Text != null) && (textBox3.Text.Length > 0))
            {
                string x = textBox3.Text;
                string v = x.Trim();
                if (v == "")
                {
                    CheckCorrect = true;
                    message += "Некоректный email";
                    message += "\n";
                    textBox3.Text = null;
                }
            }
            //-----------------------------------------------------------------------
            if (CheckCorrect == true)
            {
                MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    if (CheckLoginPassword(textBox6.Text))
                    {
                        sqlConnection1.Open();
                        SqlCommand sqlCommand_Cl2 = new SqlCommand("INSERT INTO Пассажир VALUES ((SELECT COUNT(*) + 1 From Пассажир), '" + textBox1.Text + "','" + dateTimePicker1.Value.ToString() + "','" + textBox4.Text + "','" + textBox3.Text + "')", sqlConnection1);
                        sqlCommand_Cl2.ExecuteNonQuery();
                        sqlConnection1.Close();
                        sqlConnection1.Open();
                        SqlCommand sqlCommand_Cl22 = new SqlCommand("INSERT INTO ЛогинПароли VALUES ('" + textBox6.Text + "','" + textBox5.Text + "','Клиент',(SELECT COUNT(*) From Пассажир))", sqlConnection1);
                        sqlCommand_Cl22.ExecuteNonQuery();
                        sqlConnection1.Close();
                        MessageBox.Show("Успех", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        textBox5.Text = null;
                        textBox6.Text = null;
                        MessageBox.Show("Логин занят", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }  
                }
                catch(Exception er)
                {
                    string s = er.Message;
                    MessageBox.Show("Попробуйте снова!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                textBox1.Text = null;
                dateTimePicker1.Value = DateTime.Now;
                textBox3.Text = null;
                textBox4.Text = null;
                textBox5.Text = null;
                textBox6.Text = null;
            }
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            sqlConnection1.ConnectionString = EnteryForm.SQL_C;
            textBox1.Text = null;
            dateTimePicker1.Value = DateTime.Now;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
        }



        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
