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
    public partial class Form12 : Form
    {
        static DateTime dateTime;
        string where_string = "";
        Dictionary<int, List<string>> KeyPair = new Dictionary<int, List<string>>();
        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            sqlConnection1.ConnectionString = EnteryForm.SQL_C;
            dateTime = DateTime.Now;
            dateTimePicker1.Value = dateTime;
            listView2.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            KeyPair.Clear();
            listView2.Items.Clear();
            string[] str = new string[9];
            if (textBox1.Text.Length == 0)
            {
                where_string += " where";
                where_string += " Дата_отправления ='" + dateTimePicker1.Value.ToString("dd-MMM-yyyy") + " '";
            }
            else
            {
                where_string += " where Станция.Название = '" + textBox1.Text.ToString() + "' and";
                where_string += " Дата_отправления ='" + dateTimePicker1.Value.ToString("dd-MMM-yyyy") + " '";
            }
            if (textBox2.Text.Length != 0)
            {
                where_string += "and Поезд.Номер_поезда = '" + textBox2.Text.ToString() + "'";
            }

            sqlConnection1.Open();
            SqlCommand sqlCommand_Cl = new SqlCommand("select ВремяПрибытия, Откуда,Название, Куда, Номер_поезда,Время_стоянки, Дата_отправления,Статус,ТИП, ВремяОтправления from Поезд LEFT OUTER join Остановка on Поезд.Номер_поезда = Остановка.НомерПоезда LEFT OUTER join Станция on Остановка.ID_станции = Станция.ID_станции LEFT OUTER join Расписание on Расписание.НомерПоезда = Поезд.Номер_поезда " + where_string + "order by  Дата_отправления, Остановка.ВремяПрибытия", sqlConnection1);
            SqlDataReader Type = sqlCommand_Cl.ExecuteReader();
            where_string = "";
            int count = 0;
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
                listView2.Items.Add(new ListViewItem(str));
                KeyPair.Add(count, new List<string>() { Type[2].ToString(), Type[4].ToString(), Type[6].ToString() });
                count++;
            }
            Type.Close();
            sqlConnection1.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string y = DateTime.Now.ToString();
            if ((listView2.CheckedItems.Count == 0) || (dateTimePicker1.Value < dateTime) || (dateTimePicker1.Value > dateTime))
            {
                MessageBox.Show("Вы не выбрали ни один поезд или неверная дата ", "Ошибка выбора", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                for (int i = 0; i < listView2.CheckedItems.Count; i++)
                {

                    sqlConnection1.Open();
                    SqlCommand sqlCommand12 = new SqlCommand("update Расписание set Статус = 'Опаздывает' where НомерПоезда = '" + KeyPair[listView2.CheckedIndices[i]][1] + "' and Дата_отправления = '"+ KeyPair[listView2.CheckedIndices[i]][2] + "' ", sqlConnection1);
                    object Type_1 = sqlCommand12.ExecuteNonQuery();
                    sqlConnection1.Close();
                }
            }
            KeyPair.Clear();
            listView2.Items.Clear();
            string[] str = new string[9];
            if (textBox1.Text.Length == 0)
            {
                where_string += " where";
                where_string += " Дата_отправления ='" + dateTimePicker1.Value.ToString("dd-MMM-yyyy") + " '";
            }
            else
            {
                where_string += " where Станция.Название = '" + textBox1.Text.ToString() + "' and";
                where_string += " Дата_отправления ='" + dateTimePicker1.Value.ToString("dd-MMM-yyyy") + " '";
            }
            if (textBox2.Text.Length != 0)
            {
                where_string += "and Поезд.Номер_поезда = '" + textBox2.Text.ToString() + "'";
            }

            sqlConnection1.Open();
            SqlCommand sqlCommand_Cl = new SqlCommand("select ВремяПрибытия, Откуда,Название, Куда, Номер_поезда,Время_стоянки, Дата_отправления,Статус,ТИП, ВремяОтправления from Поезд LEFT OUTER join Остановка on Поезд.Номер_поезда = Остановка.НомерПоезда LEFT OUTER join Станция on Остановка.ID_станции = Станция.ID_станции LEFT OUTER join Расписание on Расписание.НомерПоезда = Поезд.Номер_поезда " + where_string + "order by  Дата_отправления, Остановка.ВремяПрибытия", sqlConnection1);
            SqlDataReader Type = sqlCommand_Cl.ExecuteReader();
            where_string = "";
            int count = 0;
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
                listView2.Items.Add(new ListViewItem(str));
                KeyPair.Add(count, new List<string>() { Type[2].ToString(), Type[4].ToString(), Type[6].ToString() });
                count++;
            }
            Type.Close();
            sqlConnection1.Close();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form17 form17 = new Form17();
            form17.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form15 form15 = new Form15();
            form15.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string y = DateTime.Now.ToString();
            if ((listView2.CheckedItems.Count == 0) || (dateTimePicker1.Value < dateTime) || (dateTimePicker1.Value > dateTime))
            {
                MessageBox.Show("Вы не выбрали ни один поезд или неверная дата ", "Ошибка выбора", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                for (int i = 0; i < listView2.CheckedItems.Count; i++)
                {

                    sqlConnection1.Open();
                    SqlCommand sqlCommand12 = new SqlCommand("update Расписание set Статус = 'По расписанию' where НомерПоезда = '" + KeyPair[listView2.CheckedIndices[i]][1] + "' and Дата_отправления = '" + KeyPair[listView2.CheckedIndices[i]][2] + "' ", sqlConnection1);
                    object Type_1 = sqlCommand12.ExecuteNonQuery();
                    sqlConnection1.Close();
                }
            }
            KeyPair.Clear();
            listView2.Items.Clear();
            string[] str = new string[9];
            if (textBox1.Text.Length == 0)
            {
                where_string += " where";
                where_string += " Дата_отправления ='" + dateTimePicker1.Value.ToString("dd-MMM-yyyy") + " '";
            }
            else
            {
                where_string += " where Станция.Название = '" + textBox1.Text.ToString() + "' and";
                where_string += " Дата_отправления ='" + dateTimePicker1.Value.ToString("dd-MMM-yyyy") + " '";
            }
            if (textBox2.Text.Length != 0)
            {
                where_string += "and Поезд.Номер_поезда = '" + textBox2.Text.ToString() + "'";
            }

            sqlConnection1.Open();
            SqlCommand sqlCommand_Cl = new SqlCommand("select ВремяПрибытия, Откуда,Название, Куда, Номер_поезда,Время_стоянки, Дата_отправления,Статус,ТИП, ВремяОтправления from Поезд LEFT OUTER join Остановка on Поезд.Номер_поезда = Остановка.НомерПоезда LEFT OUTER join Станция on Остановка.ID_станции = Станция.ID_станции LEFT OUTER join Расписание on Расписание.НомерПоезда = Поезд.Номер_поезда " + where_string + "order by  Дата_отправления, Остановка.ВремяПрибытия", sqlConnection1);
            SqlDataReader Type = sqlCommand_Cl.ExecuteReader();
            where_string = "";
            int count = 0;
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
                listView2.Items.Add(new ListViewItem(str));
                KeyPair.Add(count, new List<string>() { Type[2].ToString(), Type[4].ToString(), Type[6].ToString() });
                count++;
            }
            Type.Close();
            sqlConnection1.Close();
        }
    }
}
