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
    public partial class Form4 : Form
    {
        string where_string = "";
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            sqlConnection1.ConnectionString = EnteryForm.SQL_C;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string[] str = new string[9];
            if (textBox1.Text.Length == 0)
            {
                where_string += " where";
                where_string += " Дата_отправления ='" + dateTimePicker1.Value.ToString("dd-MMM-yyyy") + " '";
                if (checkedListBox1.CheckedItems.Count == 2)
                {
                    where_string += " and (";
                    for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                    {
                        where_string += "Поезд.Тип ='" + checkedListBox1.CheckedItems[i].ToString() + "' or ";
                    }
                    where_string = where_string.Remove(where_string.Length - 3);
                    where_string += " )";
                }
                if (checkedListBox1.CheckedItems.Count == 1)
                {
                    where_string += " and ";
                    for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                    {
                        where_string += "Поезд.Тип ='" + checkedListBox1.CheckedItems[i].ToString() + "'";
                    }
                }

            }
            else
            {
                where_string += " where Станция.Название = '" + textBox1.Text.ToString()+"' and";
                where_string += " Дата_отправления ='" + dateTimePicker1.Value.ToString("dd-MMM-yyyy") + " '";
                if (checkedListBox1.CheckedItems.Count == 2)
                {
                    where_string += " and (";
                    for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                    {
                        where_string += "Поезд.Тип ='" + checkedListBox1.CheckedItems[i].ToString() + "' or ";
                    }
                    where_string = where_string.Remove(where_string.Length - 3);
                    where_string += " )";
                }
                if (checkedListBox1.CheckedItems.Count == 1)
                {
                    where_string += " and ";
                    for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                    {
                        where_string += "Поезд.Тип ='" + checkedListBox1.CheckedItems[i].ToString() + "'";
                    }
                }
            }
            if (textBox2.Text.Length != 0)
            {
                where_string += " and Поезд.Номер_поезда = '" + textBox2.Text.ToString() + "'";
            }

            sqlConnection1.Open();
            SqlCommand sqlCommand_Cl = new SqlCommand("select ВремяПрибытия, Откуда,Название, Куда, Номер_поезда,Время_стоянки, Дата_отправления,Статус,ТИП, ВремяОтправления from Поезд LEFT OUTER join Остановка on Поезд.Номер_поезда = Остановка.НомерПоезда LEFT OUTER join Станция on Остановка.ID_станции = Станция.ID_станции LEFT OUTER join Расписание on Расписание.НомерПоезда = Поезд.Номер_поезда" + where_string +"order by  Дата_отправления, Остановка.ВремяПрибытия", sqlConnection1);
            SqlDataReader Type = sqlCommand_Cl.ExecuteReader();
            where_string = "";
            while (Type.Read())
            {
                if (Type[0].ToString() == Type[9].ToString())
                {
                    str[0] = "-";
                }
                else
                {
                    str[0] = Type[0].ToString();
                }
                str[1] = Type[1].ToString();
                str[2] = Type[2].ToString();
                str[3] = Type[3].ToString();
                str[4] = Type[4].ToString();
                str[5] = Type[5].ToString();
                str[6] = Convert.ToDateTime(Type[6].ToString()).ToString("dd-MMM-yyyy");
                str[7] = Type[7].ToString();
                str[8] = Type[8].ToString();
                listView1.Items.Add(new ListViewItem(str));
            }
            Type.Close();
            sqlConnection1.Close();
        }

        private void sqlConnection1_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            MainFormForClient mainFormForClient = new MainFormForClient();
            mainFormForClient.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
