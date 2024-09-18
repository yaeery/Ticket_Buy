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
    public partial class Form6 : Form
    { 
        public Form6(int x)
        {
            InitializeComponent();
            if (x == 0)
            {
                textBox1.Visible = true;
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                textBox4.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
            }
            else if (x == 1)
            {
                checkedListBox1.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            sqlConnection1.ConnectionString = EnteryForm.SQL_C;
            textBox1.Text = null;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            textBox4.Text = null;
            sqlConnection1.Open();
            SqlCommand sqlCommand_Cl = new SqlCommand("select Название from Тариф where Активность = 'T' ", sqlConnection1);
            SqlDataReader Type = sqlCommand_Cl.ExecuteReader();
            while (Type.Read())
            {
                checkedListBox1.Items.Add(Type[0].ToString());
            }
            Type.Close();

            sqlConnection1.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool CheckCorrect = false;
            string message = "";
            if ((textBox1.Text == null)||(textBox1.Text == ""))
            {
                CheckCorrect = true;
                message += "Некоректное название";
                message += "\n";
            }
            else if ((textBox1.Text != null) && (textBox1.Text.Length > 0))
            {
                string x = textBox1.Text;
                string v = x.Trim();
                if (v == "")
                {
                    CheckCorrect = true;
                    message += "Некоректное название";
                    message += "\n";
                    textBox1.Text = null;
                }
            }
            //-----------------------------------------------------------------------
            if ((textBox4.Text == null) || ((textBox4.Text != null) && (!Int64.TryParse(textBox4.Text, out Int64 num2))))

            {
                CheckCorrect = true;
                message += "Некоректное значение процента";
                message += "\n";
            }

            //---------------------------------------------------------------------------
            if (dateTimePicker1.Value < new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day))
            {
                CheckCorrect = true;
                message += "Некоректная дата начала";
                message += "\n";
            }
            //---------------------------------------------------------------------------
            if (dateTimePicker2.Value <= dateTimePicker1.Value)
            {
                CheckCorrect = true;
                message += "Некоректная дата конца";
                message += "\n";
            }
            //---------------------------------------------------------------------------
            if (CheckCorrect == true)
            {
                MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }
            else
            {
                try
                {
                    sqlConnection1.Open();
                    SqlCommand sqlCommand_Cl2 = new SqlCommand("INSERT INTO Тариф VALUES ((SELECT COUNT(*) + 1 From Тариф),'" + textBox1.Text + "', '" + dateTimePicker1.Value.ToString()+ "', '" + dateTimePicker2.Value.ToString() + "', '" + textBox4.Text + "', 'T')", sqlConnection1);
                    sqlCommand_Cl2.ExecuteNonQuery();
                    sqlConnection1.Close();
                    MessageBox.Show("Тариф успешно добален", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Попробуйте снова!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                }
                textBox1.Text = null;
                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker2.Value = DateTime.Now;
                textBox4.Text = null;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Не выбран ни один тариф!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            {

            string where_string = " where ";
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
            where_string += " Название = '";
            where_string += checkedListBox1.CheckedItems[i];
            MessageBox.Show("Тариф "+ checkedListBox1.CheckedItems[i].ToString() + " удален ", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (i != checkedListBox1.CheckedItems.Count - 1)
            {
               where_string += "' or ";
            }
            }
            where_string += " '";
            sqlConnection1.Open();
            SqlCommand sqlCommand_Cl2 = new SqlCommand(" Update Тариф set Активность = 'F' "+ where_string, sqlConnection1);
            sqlCommand_Cl2.ExecuteNonQuery();
            sqlConnection1.Close();
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
            checkedListBox1.Items.RemoveAt(checkedListBox1.CheckedIndices[i]);
            i--;
            }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
