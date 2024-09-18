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
    public partial class Form13 : Form
    {
        static DateTime dateTime;

        static int x = 0;
        public Form13()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            sqlConnection1.ConnectionString = EnteryForm.SQL_C;
            dateTime = DateTime.Now;
            dateTimePicker1.Value = dateTime;
            sqlConnection1.Open();
            SqlCommand sqlCommand_Cl = new SqlCommand("select Номер_поезда from Поезд ", sqlConnection1);
            SqlDataReader Type = sqlCommand_Cl.ExecuteReader();
            while (Type.Read())
            {
                checkedListBox1.Items.Add(Type[0].ToString());
            }
            Type.Close();

            sqlConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string y = DateTime.Now.ToString();
            if ((checkedListBox1.CheckedItems.Count == 0) || (dateTimePicker1.Value < dateTime))
            {
                MessageBox.Show("Вы не выбрали ни один поезд или попытка создать билеты для прошедшего дня", "Ошибка выбора", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sqlConnection1.Open();
                SqlCommand sqlCommand12 = new SqlCommand("select COUNT (*) from Билет where НомерПоезда = " + checkedListBox1.CheckedItems[0] + " and Дата = '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'", sqlConnection1);
                object Type_1 = sqlCommand12.ExecuteScalar();
                sqlConnection1.Close();
                if (Type_1.ToString() != "0")
                {
                    MessageBox.Show("Вы пытаетесь создать уже существующие билеты на данный поезд и дату", "Расписание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    sqlConnection1.Open();
                    SqlCommand sqlCommand1 = new SqlCommand("dbo.AddBilet", sqlConnection1);
                    sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter Data = new SqlParameter
                    {
                        ParameterName = "@Data",
                        SqlDbType = System.Data.SqlDbType.Date,
                        Size = 10,
                        Value = dateTimePicker1.Value.ToString()
                    };
                    SqlParameter Nomer = new SqlParameter
                    {
                        ParameterName = "@Nomer",
                        SqlDbType = System.Data.SqlDbType.Int,
                        Size = 10,
                        Value = Convert.ToInt32(checkedListBox1.CheckedItems[0])
                    };
                    sqlCommand1.Parameters.Add(Data);
                    sqlCommand1.Parameters.Add(Nomer);
                    sqlCommand1.ExecuteNonQuery();
                    sqlConnection1.Close();
                    MessageBox.Show("Вы добавили билеты для поезда под номером " + Convert.ToInt32(checkedListBox1.CheckedItems[0]) + " на " + dateTimePicker1.Value.ToString("dd-MM-yyyy"), "Расписание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
