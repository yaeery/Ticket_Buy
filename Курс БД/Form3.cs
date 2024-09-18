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
    public partial class ViewAllTickets : Form
    {
        string where_string = "";
        static DateTime dateTime;

        public ViewAllTickets()
        {
            InitializeComponent();
        }

        private void ViewAllTickets_Load(object sender, EventArgs e)
        {
            sqlConnection1.ConnectionString = EnteryForm.SQL_C;
            listView1.Items[0].Remove();
            sqlConnection1.Open();
            SqlCommand sqlCommand_Cl = new SqlCommand("select Название from Тариф where Активность = 'T' ", sqlConnection1);
            SqlDataReader Type = sqlCommand_Cl.ExecuteReader();
            while (Type.Read())
            {
                checkedListBox4.Items.Add(Type[0].ToString());
            }
            Type.Close();

            sqlConnection1.Close();
            dateTime = DateTime.Today;

            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            sqlConnection1.Open();
            SqlCommand sqlCommand_Cl1 = new SqlCommand("SELECT Номер_поезда FROM Поезд", sqlConnection1);
            SqlDataReader Type2 = sqlCommand_Cl1.ExecuteReader();
            while (Type2.Read())
            {
                comboBox1.Items.Add(Type2[0].ToString());
            }
            Type2.Close();
            sqlConnection1.Close();

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                checkedListBox2.SetItemChecked(i, false);
            }
        }

        private void checkedListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((radioButton1 != null) && (radioButton2 != null))
            {
                MessageBox.Show("Вы не выбрали ни одни из методов поиска билетов", "Ошибка выбора", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (radioButton1 != null)
                {
                    where_string = "";
                    listView1.Items.Clear();
                    if ((checkedListBox1.CheckedItems.Count == 0) || (checkedListBox2.CheckedItems.Count == 0)) //|| (dateTimePicker2.Value <= dateTime))
                    {
                        MessageBox.Show("Вы не выбрали одни или несколько пунков из перечисленных: Откуда, Куда, Указана уже прошедшая дата", "Ошибка выбора", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        where_string += " where";
                        for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                        {
                            where_string += " Поезд.Откуда = '" + checkedListBox1.CheckedItems[i].ToString() + "' and";
                        }
                        for (int i = 0; i < checkedListBox2.CheckedItems.Count; i++)
                        {
                            where_string += " Поезд.Куда = '" + checkedListBox2.CheckedItems[i].ToString() + "' and";
                        }
                        where_string += " Билет.Дата = '" + dateTimePicker2.Value.ToString() + "'";

                        if ((checkedListBox3.CheckedItems.Count != 0))
                        {
                            where_string += "and (";
                            for (int i = 0; i < checkedListBox3.CheckedItems.Count; i++)
                            {

                                where_string += " Поезд.Тип = '" + checkedListBox3.CheckedItems[i].ToString() + "' or ";
                            }
                            where_string = where_string.Remove(where_string.Length - 3);
                            where_string += ")";
                        }
                        if ((checkedListBox4.CheckedItems.Count != 0))
                        {
                            where_string += "and (";
                            for (int i = 0; i < checkedListBox4.CheckedItems.Count; i++)
                            {

                                where_string += "Тариф.Название = '" + checkedListBox4.CheckedItems[i].ToString() + "' or ";
                            }
                            where_string = where_string.Remove(where_string.Length - 3);
                            where_string += ")";
                        }
                        where_string += "  and Билет.Активность = 'T'";
                        string[] str = new string[12];
                        sqlConnection1.Open();
                        SqlCommand sqlCommand_Cl = new SqlCommand("select Билет.ID_билета AS 'Номер билета', Билет.НомерПоезда, Билет.Дата, Билет.Время as 'время отправления',Поезд.Тип,Билет.Вагон, Билет.Место, Поезд.Откуда, Поезд.Куда, ВремяВПути, Тариф.Название as 'Тип места', Цена FROM Билет JOIN Поезд on Билет.НомерПоезда = Поезд.Номер_поезда JOIN Тариф on Билет.ID_тарифа = Тариф.ID_тарифа" + where_string, sqlConnection1);
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
                            str[11] = Type[11].ToString();
                            listView1.Items.Add(new ListViewItem(str));
                        }
                        Type.Close();
                    }
                    sqlConnection1.Close();
                }
                else
                {
                    where_string = "";
                    listView1.Items.Clear();
                    if ((comboBox1.SelectedItem == null))// || (dateTimePicker2.Value <= dateTime))
                    {
                        MessageBox.Show("Вы не выбрали одни или несколько пунков из перечисленных: Номер поезда, Указана уже прошедшая дата", "Ошибка выбора", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        where_string += " where";
                        where_string += " Билет.НомерПоезда ='" + comboBox1.SelectedItem.ToString() + "' and";
                        where_string += " Билет.Дата = '" + dateTimePicker2.Value.ToString() + "'";

                        if ((checkedListBox3.CheckedItems.Count != 0))
                        {
                            where_string += "and (";
                            for (int i = 0; i < checkedListBox3.CheckedItems.Count; i++)
                            {

                                where_string += " Поезд.Тип = '" + checkedListBox3.CheckedItems[i].ToString() + "' or ";
                            }
                            where_string = where_string.Remove(where_string.Length - 3);
                            where_string += ")";
                        }
                        if ((checkedListBox4.CheckedItems.Count != 0))
                        {
                            where_string += "and (";
                            for (int i = 0; i < checkedListBox4.CheckedItems.Count; i++)
                            {

                                where_string += "Тариф.Название = '" + checkedListBox4.CheckedItems[i].ToString() + "' or ";
                            }
                            where_string = where_string.Remove(where_string.Length - 3);
                            where_string += ")";
                        }
                        where_string += "  and Билет.Активность = 'T'";
                        string[] str = new string[12];
                        sqlConnection1.Open();
                        SqlCommand sqlCommand_Cl = new SqlCommand("select Билет.ID_билета AS 'Номер билета', Билет.НомерПоезда, Билет.Дата, Билет.Время as 'время отправления',Поезд.Тип,Билет.Вагон, Билет.Место, Поезд.Откуда, Поезд.Куда, ВремяВПути, Тариф.Название as 'Тип места', Цена FROM Билет JOIN Поезд on Билет.НомерПоезда = Поезд.Номер_поезда JOIN Тариф on Билет.ID_тарифа = Тариф.ID_тарифа" + where_string, sqlConnection1);
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
                            str[11] = Type[11].ToString();
                            listView1.Items.Add(new ListViewItem(str));
                        }
                        Type.Close();
                    }
                    sqlConnection1.Close();
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
                checkedListBox2.SetItemChecked(i, false);
                checkedListBox4.SetItemChecked(i, false);
            }
            for (int i = 0; i < checkedListBox3.Items.Count; i++)
            {
                checkedListBox3.SetItemChecked(i, false);
            }
            dateTimePicker2.Value = DateTime.Today;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
                string[] str = new string[12];
                sqlConnection1.Open();
                SqlCommand sqlCommand_Cl = new SqlCommand("select Билет.ID_билета AS 'Номер билета', Билет.НомерПоезда, Билет.Дата, Билет.Время as 'время отправления',Поезд.Тип,Билет.Вагон, Билет.Место, Поезд.Откуда, Поезд.Куда, ВремяВПути, Тариф.Название as 'Тип места', Цена FROM Билет JOIN Поезд on Билет.НомерПоезда = Поезд.Номер_поезда JOIN Тариф on Билет.ID_тарифа = Тариф.ID_тарифа" + where_string, sqlConnection1);
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
                    str[11] = Type[11].ToString();
                listView1.Items.Add(new ListViewItem(str));
                }
                Type.Close();
            sqlConnection1.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Вы не выбрали ни один билет", "Ошибка выбора", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                for (int i = 0; i < listView1.CheckedItems.Count; i++)
                {
                    int x = Convert.ToInt32(listView1.CheckedItems[i].Text);
                    sqlConnection1.Open();
                    SqlCommand sqlCommand_Cl2 = new SqlCommand("INSERT INTO ПроданныеБилеты VALUES ('"+Form8.Id_Client+"','" + Convert.ToInt32(listView1.CheckedItems[i].Text) +"','"+dateTimePicker2.Value.ToString("dd-MMM-yyyy")+"')", sqlConnection1);
                    sqlCommand_Cl2.ExecuteNonQuery();
                    sqlConnection1.Close();
                    MessageBox.Show("Вы купили билет под номером "+ Convert.ToInt32(listView1.CheckedItems[i].Text) + "", "Покупка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                listView1.Items.Clear();
            }
        }



        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            MainFormForClient mainFormForClient = new MainFormForClient();
            mainFormForClient.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton2 = null;
            label1.Visible = true;
            label2.Visible = true;
            label6.Visible = false;
            checkedListBox1.Visible = true;
            checkedListBox2.Visible = true;
            comboBox1.Visible = false;
            comboBox1.Items.Clear();
            comboBox1.ResetText();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1 = null;
            label1.Visible = false;
            label2.Visible = false;
            label6.Visible = true;
            checkedListBox1.Visible = false;
            checkedListBox2.Visible = false;
            comboBox1.Visible = true;
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            checkedListBox1.SelectedItems.Clear();
            checkedListBox2.SelectedItems.Clear();

            sqlConnection1.Open();
            SqlCommand sqlCommand_Cl1 = new SqlCommand("SELECT Номер_поезда FROM Поезд", sqlConnection1);
            SqlDataReader Type2 = sqlCommand_Cl1.ExecuteReader();
            while (Type2.Read())
            {
                comboBox1.Items.Add(Type2[0].ToString());
            }
            Type2.Close();
            sqlConnection1.Close();

        }
    }
}
