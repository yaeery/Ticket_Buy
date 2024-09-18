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
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form14_Load(object sender, EventArgs e)
        {
            sqlConnection1.ConnectionString = EnteryForm.SQL_C;
            string[] str = new string[11];
            listView2.Items.Clear();
            sqlConnection1.Open();
            SqlCommand sqlCommand_Cl = new SqlCommand("select Билет.ID_билета,ДатаПродажи,НомерПоезда,Дата,Время,Вагон,Место,Откуда,Куда,ВремяВПути,Название from ПроданныеБилеты join Билет on Билет.ID_билета = ПроданныеБилеты.ID_билета join Тариф on Билет.ID_тарифа = Тариф.ID_тарифа join Поезд on Билет.НомерПоезда = Поезд.Номер_поезда where ID_пассажира = '"+Form8.Id_Client+"'and Дата >= '"+DateTime.Now.ToString()+"'", sqlConnection1);
            SqlDataReader Type = sqlCommand_Cl.ExecuteReader();
            while (Type.Read())
            {
                str[0] = Type[0].ToString();
                str[1] = Type[1].ToString();
                str[2] = Type[2].ToString();
                str[3] = Type[3].ToString();
                str[4] = Type[4].ToString();
                str[5] = Type[5].ToString();
                str[6] = Type[6].ToString();
                str[7] = Type[7].ToString();
                str[8] = Type[8].ToString();
                str[9] = Type[9].ToString();
                str[10] = Type[10].ToString();
                listView2.Items.Add(new ListViewItem(str));
            }
            Type.Close();
            sqlConnection1.Close();
            if(listView2.Items.Count != 0)
            {
                label1.Text = "Выберете те билеты, которые хотите сдать";
                button2.Visible = true;
            }
            else
            {
                label1.Text = "У вас нет предстоящих поездок";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            MainFormForClient mainFormForClient = new MainFormForClient();
            mainFormForClient.Show();
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView2.CheckedItems.Count == 0)
            {
                MessageBox.Show("Вы не выбрали ни один билет", "Ошибка выбора", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                for (int i = 0; i < listView2.CheckedItems.Count; i++)
                {
                    int x = Convert.ToInt32(listView2.CheckedItems[i].Text);
                    sqlConnection1.Open();
                    SqlCommand sqlCommand_Cl2 = new SqlCommand("Delete from ПроданныеБилеты where ID_билета = '" + Convert.ToInt32(listView2.CheckedItems[i].Text)+ "'", sqlConnection1);
                    sqlCommand_Cl2.ExecuteNonQuery();
                    sqlConnection1.Close();
                    MessageBox.Show("Вы сдали билет под номером " + Convert.ToInt32(listView2.CheckedItems[i].Text) + "", "Покупка", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                string[] str = new string[11];
                listView2.Items.Clear();
                sqlConnection1.Open();
                SqlCommand sqlCommand_Cl = new SqlCommand("select Билет.ID_билета,ДатаПродажи,НомерПоезда,Дата,Время,Вагон,Место,Откуда,Куда,ВремяВПути,Название from ПроданныеБилеты join Билет on Билет.ID_билета = ПроданныеБилеты.ID_билета join Тариф on Билет.ID_тарифа = Тариф.ID_тарифа join Поезд on Билет.НомерПоезда = Поезд.Номер_поезда where ID_пассажира = '" + Form8.Id_Client + "'", sqlConnection1);
                SqlDataReader Type = sqlCommand_Cl.ExecuteReader();
                while (Type.Read())
                {
                    str[0] = Type[0].ToString();
                    str[1] = Type[1].ToString();
                    str[2] = Type[2].ToString();
                    str[3] = Type[3].ToString();
                    str[4] = Type[4].ToString();
                    str[5] = Type[5].ToString();
                    str[6] = Type[6].ToString();
                    str[7] = Type[7].ToString();
                    str[8] = Type[8].ToString();
                    str[9] = Type[9].ToString();
                    str[10] = Type[10].ToString();
                    listView2.Items.Add(new ListViewItem(str));
                }
                Type.Close();
                sqlConnection1.Close();
                if (listView2.Items.Count != 0)
                {
                    label1.Text = "Выберете те билеты, которые хотите сдать";
                    button2.Visible = true;
                }
                else
                {
                    label1.Text = "У вас нет предстоящих поездок";
                }
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
