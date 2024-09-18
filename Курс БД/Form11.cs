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
    public partial class Form11 : Form
    {
        private string Type = "";
        public Form11(string Type)
        {
            InitializeComponent();
            this.Type = Type;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool CheckCorrect = false;
            string message = "";
            if ((textBox1.Text == null) || (textBox1.Text == ""))
            {
                CheckCorrect = true;
                message += "Введите логин";
                message += "\n";
            }
            else if ((textBox1.Text != null) && (textBox1.Text.Length > 0))
            {
                string x = textBox2.Text;
                string v = x.Trim();
                if (v == "")
                {
                    CheckCorrect = true;
                    message += "Введите логин";
                    message += "\n";
                    textBox1.Text = null;
                }
            }
            //-----------------------------------------------------------------------
            if ((textBox1.Text == null) || (textBox1.Text == ""))
            {
                CheckCorrect = true;
                message += "Введите пароль";
                message += "\n";
            }
            else if ((textBox1.Text != null) && (textBox1.Text.Length > 0))
            {
                string x = textBox1.Text;
                string v = x.Trim();
                if (v == "")
                {
                    CheckCorrect = true;
                    message += "Введите пароль";
                    message += "\n";
                    textBox1.Text = null;
                }
            }
            sqlConnection1.Open();
            SqlCommand sqlCommand_Cl2;
            sqlCommand_Cl2 = new SqlCommand("Select Id_клиента from ЛогинПароли where Логин= '" + textBox1.Text + "' and Пароль = '" + textBox2.Text + "' and Тип = '"+ Type +"'", sqlConnection1);
            object Type_1 = sqlCommand_Cl2.ExecuteScalar();
            sqlConnection1.Close();
            if (Type_1 != null)
            {
                if(Type == "Администратор")
                {
                    Form5 form5 = new Form5();
                    form5.Show();
                }
                else if (Type == "Диспетчер")
                {
                    Form12 form12 = new Form12();
                    form12.Show();
                }

            }
            else
            {
                textBox2.Text = null;
                textBox1.Text = null;
                message = "Некоректный логин или пароль";
                MessageBox.Show(message, "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBox2.Text = null;
            textBox1.Text = null;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form11_Load(object sender, EventArgs e)
        {
            sqlConnection1.ConnectionString = EnteryForm.SQL_C;
        }
    }
}
