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
    public partial class Form8 : Form
    {
        public static int Id_Client = -1;
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            sqlConnection1.ConnectionString = EnteryForm.SQL_C;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form7 form7 = new Form7();
            form7.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool CheckCorrect = false;
            string message = "";
            if ((textBox2.Text == null) || (textBox2.Text == ""))
            {
                CheckCorrect = true;
                message += "Некоректный логин";
                message += "\n";
            }
            else if ((textBox2.Text != null) && (textBox2.Text.Length > 0))
            {
                string x = textBox2.Text;
                string v = x.Trim();
                if (v == "")
                {
                    CheckCorrect = true;
                    message += "Некоректный логин";
                    message += "\n";
                    textBox2.Text = null;
                }
            }
            //-----------------------------------------------------------------------
            if ((textBox1.Text == null) || (textBox1.Text == ""))
            {
                CheckCorrect = true;
                message += "Некоректный пароль";
                message += "\n";
            }
            else if ((textBox1.Text != null) && (textBox1.Text.Length > 0))
            {
                string x = textBox1.Text;
                string v = x.Trim();
                if (v == "")
                {
                    CheckCorrect = true;
                    message += "Некоректный пароль";
                    message += "\n";
                    textBox1.Text = null;
                }
            }
            sqlConnection1.Open();
            SqlCommand sqlCommand_Cl2;
            sqlCommand_Cl2 = new SqlCommand("Select Id_клиента from ЛогинПароли where Логин= '" + textBox2.Text + "' and Пароль = '" + textBox1.Text + "' and Тип = 'Клиент'", sqlConnection1);
            object Type_1 = sqlCommand_Cl2.ExecuteScalar();
            sqlConnection1.Close();
            if (Type_1 != null)
            {
                Id_Client = Convert.ToInt32(Type_1.ToString());
                MainFormForClient mainFormForClient = new MainFormForClient();
                mainFormForClient.Show();
                this.Hide();

            }
            else
            {
                textBox2.Text = null;
                textBox1.Text = null;
                if(message=="")
                {
                    message += "Неверный логин или пароль";
                }
                MessageBox.Show(message, "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBox2.Text = null;
            textBox1.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();
            form10.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
