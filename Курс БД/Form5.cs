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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    button1.Visible = false;
        //    button2.Visible = false;
        //    button14.Visible = false;
        //    button15.Visible = false;
        //    dataGridView1.Columns.Clear();

        //    SqlCommand my_command = new SqlCommand();
        //    my_command.Connection = sqlConnection1;
        //    my_command.CommandType = System.Data.CommandType.Text;
        //    my_command.CommandText = "select ВремяПрибытия, Откуда,Название, Куда, Номер_поезда,Время_стоянки, Дата_отправления,Статус,ТИП, ВремяОтправления from Поезд LEFT OUTER join Остановка on Поезд.Номер_поезда = Остановка.НомерПоезда LEFT OUTER join Станция on Остановка.ID_станции = Станция.ID_станции LEFT OUTER join Расписание on Расписание.НомерПоезда = Поезд.Номер_поезда order by  Дата_отправления, Остановка.ВремяПрибытия";
        //    sqlConnection1.Open();
        //    var temp = new DataTable();
        //    temp.Load(my_command.ExecuteReader());
        //    dataGridView1.DataSource = temp;
        //    sqlConnection1.Close();
        //}



        private void Form5_Load(object sender, EventArgs e)
        {
            sqlConnection1.ConnectionString = EnteryForm.SQL_C;
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            sqlConnection1.Open();
            SqlCommand sqlCommand_Cl = new SqlCommand("SELECT Номер_поезда FROM Поезд", sqlConnection1);
            SqlDataReader Type = sqlCommand_Cl.ExecuteReader();
            comboBox1.Items.Add("Все");
            while (Type.Read())
            {
                comboBox1.Items.Add(Type[0].ToString());
            }
            Type.Close();
            sqlConnection1.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button14.Visible = true;
            button15.Visible = false;

            label2.Visible = true;
            comboBox1.Visible = true;
            button16.Visible = true;
            button17.Visible = false;
            button18.Visible = false;
            button19.Visible = false;

            label3.Visible = false;
            textBox1.Visible = false;
            button20.Visible = false;
            label4.Visible = false;
            button21.Visible = false;
            label5.Visible = false;
            button22.Visible = false;
            button23.Visible = false;
            button24.Visible = false;
            button25.Visible = false;

            dataGridView1.Columns.Clear();

            SqlCommand my_command = new SqlCommand();
            my_command.Connection = sqlConnection1;
            my_command.CommandType = System.Data.CommandType.Text;
            my_command.CommandText = "SELECT ID_билета as 'Id билета', НомерПоезда AS 'Номер поезда', Дата, Время, Название as 'Id тарифа',Цена,Вагон,Место,Билет.Активность FROM Билет JOIN Тариф ON Билет.ID_тарифа = Тариф.ID_тарифа";
            sqlConnection1.Open();
            var temp = new DataTable();
            temp.Load(my_command.ExecuteReader());
            dataGridView1.DataSource = temp;
            sqlConnection1.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 AddTarife = new Form6(0);
            AddTarife.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 AddTarife = new Form6(1);
            AddTarife.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            dataGridView1.Columns.Clear();

            label2.Visible = false;
            comboBox1.Visible = false;
            button16.Visible = false;
            button17.Visible = false;
            button18.Visible = false;
            button19.Visible = false;

            label3.Visible = false;
            textBox1.Visible = false;
            button20.Visible = false;
            label4.Visible = false;
            button21.Visible = false;
            label5.Visible = false;
            button22.Visible = false;
            button23.Visible = false;
            button24.Visible = false;
            button25.Visible = false;

            SqlCommand my_command = new SqlCommand();
            my_command.Connection = sqlConnection1;
            my_command.CommandType = System.Data.CommandType.Text;
            my_command.CommandText = "select Логин,Пароль,Тип, Id_Клиента as 'Id клиента' from ЛогинПароли";
            sqlConnection1.Open();
            var temp = new DataTable();
            temp.Load(my_command.ExecuteReader());
            dataGridView1.DataSource = temp;
            sqlConnection1.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            dataGridView1.Columns.Clear();

            label2.Visible = false;
            comboBox1.Visible = false;
            button16.Visible = false;
            button17.Visible = false;
            button18.Visible = false;
            button19.Visible = false;

            label3.Visible = true;
            textBox1.Visible = true;
            button20.Visible = true;
            label4.Visible = false;
            button21.Visible = false;
            label5.Visible = false;
            button22.Visible = false;
            button23.Visible = false;
            button24.Visible = true;
            button25.Visible = false;

            SqlCommand my_command = new SqlCommand();
            my_command.Connection = sqlConnection1;
            my_command.CommandType = System.Data.CommandType.Text;
            my_command.CommandText = "Select Название, Адрес from Станция";
            sqlConnection1.Open();
            var temp = new DataTable();
            temp.Load(my_command.ExecuteReader());
            dataGridView1.DataSource = temp;
            sqlConnection1.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button14.Visible = false;
            button15.Visible = false;

            label2.Visible = true;
            comboBox1.Visible = true;
            button16.Visible = false;
            button17.Visible = true;
            button18.Visible = false;
            button19.Visible = false;

            label3.Visible = false;
            textBox1.Visible = false;
            button20.Visible = false;
            label4.Visible = false;
            button21.Visible = false;
            label5.Visible = false;
            button22.Visible = false;
            button23.Visible = false;
            button24.Visible = false;
            button25.Visible = false;

            dataGridView1.Columns.Clear();

            SqlCommand my_command = new SqlCommand();
            my_command.Connection = sqlConnection1;
            my_command.CommandType = System.Data.CommandType.Text;
            my_command.CommandText = "Select НомерПоезда AS 'Номер поезда', Название as 'Id станции',ВремяПрибытия as 'Время прибытия', (case Время_стоянки when '00:00:00' then '-'else  cast(Время_стоянки as varchar(10)) end) as 'Время стоянки' from Остановка join Станция  on Станция.ID_станции = Остановка.ID_станции ORDER BY [Номер поезда],[Время прибытия]";
            sqlConnection1.Open();
            var temp = new DataTable();
            temp.Load(my_command.ExecuteReader());
            sqlConnection1.Close();
            for (int j = 0; j < temp.Rows.Count; j++)
            {
                if (temp.Rows[j].ItemArray[3].ToString() == "00:00:00")
                {
                    temp.Rows[j].ItemArray[3] = null;
                }
            }
            dataGridView1.DataSource = temp;

        }

        private void button10_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            dataGridView1.Columns.Clear();

            label2.Visible = false;
            comboBox1.Visible = false;
            button16.Visible = false;
            button17.Visible = false;
            button18.Visible = false;
            button19.Visible = false;

            label3.Visible = false;
            textBox1.Visible = true;
            button20.Visible = false;
            label4.Visible = false;
            button21.Visible = false;
            label5.Visible = true;
            button22.Visible = true;
            button23.Visible = false;
            button24.Visible = false;
            button25.Visible = false;

            SqlCommand my_command = new SqlCommand();
            my_command.Connection = sqlConnection1;
            my_command.CommandType = System.Data.CommandType.Text;
            my_command.CommandText = "select ФИО, ДатаРождения AS 'Дата рождения',Телефон, email from Пассажир";
            sqlConnection1.Open();
            var temp = new DataTable();
            temp.Load(my_command.ExecuteReader());
            dataGridView1.DataSource = temp;
            sqlConnection1.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            dataGridView1.Columns.Clear();

            label2.Visible = false;
            comboBox1.Visible = false;
            button16.Visible = false;
            button17.Visible = false;
            button18.Visible = false;
            button19.Visible = false;

            label3.Visible = false;
            textBox1.Visible = true;
            button20.Visible = false;
            label4.Visible = false;
            button21.Visible = false;
            label5.Visible = true;
            button22.Visible = false;
            button23.Visible = true;
            button24.Visible = false;
            button25.Visible = false;

            SqlCommand my_command = new SqlCommand();
            my_command.Connection = sqlConnection1;
            my_command.CommandType = System.Data.CommandType.Text;
            my_command.CommandText = "select ФИО as 'Пассажира', ПроданныеБилеты.ID_билета,НомерПоезда as 'Номер поезда',Дата AS 'Дата отправления',Время,Вагон,Место,Название, ДатаПродажи as 'Дата продажи' from ПроданныеБилеты join Пассажир on ПроданныеБилеты.ID_пассажира = Пассажир.ID_пассажира join Билет on Билет.ID_билета = ПроданныеБилеты.ID_билета join Тариф on Билет.ID_тарифа = Тариф.ID_тарифа";
            sqlConnection1.Open();
            var temp = new DataTable();
            temp.Load(my_command.ExecuteReader());
            dataGridView1.DataSource = temp;
            sqlConnection1.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            dataGridView1.Columns.Clear();

            label2.Visible = true;
            comboBox1.Visible = true;
            button16.Visible = false;
            button17.Visible = false;
            button18.Visible = false;
            button19.Visible = true;

            label3.Visible = false;
            textBox1.Visible = false;
            button20.Visible = false;
            label4.Visible = false;
            button21.Visible = false;
            label5.Visible = false;
            button22.Visible = false;
            button23.Visible = false;
            button24.Visible = false;
            button25.Visible = true;

            SqlCommand my_command = new SqlCommand();
            my_command.Connection = sqlConnection1;
            my_command.CommandType = System.Data.CommandType.Text;
            my_command.CommandText = "select Номер_поезда AS 'Номер поезда',Откуда,Куда,ВремяВПути as 'Время в пути', ВремяОтправления AS 'Время отправления', Тип as 'Тип поезда' from Поезд";
            sqlConnection1.Open();
            var temp = new DataTable();
            temp.Load(my_command.ExecuteReader());
            dataGridView1.DataSource = temp;
            sqlConnection1.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button14.Visible = false;
            button15.Visible = true;

            label2.Visible = true;
            comboBox1.Visible = true;
            button16.Visible = false;
            button17.Visible = false;
            button18.Visible = true;
            button19.Visible = false;

            label3.Visible = false;
            textBox1.Visible = false;
            button20.Visible = false;
            label4.Visible = false;
            button21.Visible = false;
            label5.Visible = false;
            button22.Visible = false;
            button23.Visible = false;
            button24.Visible = false;
            button25.Visible = false;

            dataGridView1.Columns.Clear();

            SqlCommand my_command = new SqlCommand();
            my_command.Connection = sqlConnection1;
            my_command.CommandType = System.Data.CommandType.Text;
            my_command.CommandText = "select НомерПоезда AS 'Номер поезда',Дата_отправления as 'Дата отправления',Статус, Название AS 'Название станции',Платформа from Расписание join Станция ON Расписание.ID_станции = Станция.ID_станции";
            sqlConnection1.Open();
            var temp = new DataTable();
            temp.Load(my_command.ExecuteReader());
            dataGridView1.DataSource = temp;
            sqlConnection1.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button14.Visible = false;
            button15.Visible = false;
            dataGridView1.Columns.Clear();

            label2.Visible = false;
            comboBox1.Visible = false;
            button16.Visible = false;
            button17.Visible = false;
            button18.Visible = false;
            button19.Visible = false;

            label3.Visible = false;
            textBox1.Visible = true;
            button20.Visible = false;
            label4.Visible = true;
            button21.Visible = true;
            label5.Visible = false;
            button22.Visible = false;
            button23.Visible = false;
            button24.Visible = false;
            button25.Visible = false;

            SqlCommand my_command = new SqlCommand();
            my_command.Connection = sqlConnection1;
            my_command.CommandType = System.Data.CommandType.Text;
            my_command.CommandText = "SELECT Название AS Название,ДатаНачалаДействия as 'Дата начала действия',ДатаКонцаДействия as 'Дата конца действия тарифа',ПроцентКЦене as 'Процент к цене',Активность  FROM Тариф";
            sqlConnection1.Open();
            var temp = new DataTable();
            temp.Load(my_command.ExecuteReader());
            dataGridView1.DataSource = temp;
            sqlConnection1.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form13 form13 = new Form13();
            form13.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Form19 form19 = new Form19();
            form19.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form20 form20 = new Form20();
            form20.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                dataGridView1.Columns.Clear();
                SqlCommand my_command = new SqlCommand();
                my_command.Connection = sqlConnection1;
                my_command.CommandType = System.Data.CommandType.Text;
                if (comboBox1.SelectedIndex == 0)
                {
                    my_command.CommandText = "SELECT ID_билета as 'Id билета', НомерПоезда AS 'Номер поезда', Дата, Время, Название as 'Id тарифа',Цена,Вагон,Место,Билет.Активность FROM Билет JOIN Тариф ON Билет.ID_тарифа = Тариф.ID_тарифа order by Дата";
                }
                else
                my_command.CommandText = "SELECT ID_билета as 'Id билета', НомерПоезда AS 'Номер поезда', Дата, Время, Название as 'Id тарифа',Цена,Вагон,Место,Билет.Активность FROM Билет JOIN Тариф ON Билет.ID_тарифа = Тариф.ID_тарифа where НомерПоезда = " + comboBox1.SelectedItem.ToString() + " order by Дата";
                sqlConnection1.Open();
                var temp = new DataTable();
                temp.Load(my_command.ExecuteReader());
                dataGridView1.DataSource = temp;
                sqlConnection1.Close();
            }
            else
            {
                MessageBox.Show("Номер поезда не выбран", "Ошибка выбора", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                dataGridView1.Columns.Clear();
                SqlCommand my_command = new SqlCommand();
                my_command.Connection = sqlConnection1;
                my_command.CommandType = System.Data.CommandType.Text;
                if (comboBox1.SelectedIndex == 0)
                {
                    my_command.CommandText = "Select НомерПоезда AS 'Номер поезда', Название as 'Id станции',ВремяПрибытия as 'Время прибытия', (case Время_стоянки when '00:00:00' then '-'else  cast(Время_стоянки as varchar(10)) end) as 'Время стоянки' from Остановка join Станция  on Станция.ID_станции = Остановка.ID_станции ORDER BY [Номер поезда],[Время прибытия]";
                }
                else
                my_command.CommandText = "Select НомерПоезда AS 'Номер поезда', Название as 'Id станции',ВремяПрибытия as 'Время прибытия', (case Время_стоянки when '00:00:00' then '-'else  cast(Время_стоянки as varchar(10)) end) as 'Время стоянки' from Остановка join Станция  on Станция.ID_станции = Остановка.ID_станции where НомерПоезда = '" + comboBox1.SelectedItem.ToString() + "' ORDER BY [Номер поезда],[Время прибытия]";
                sqlConnection1.Open();
                var temp = new DataTable();
                temp.Load(my_command.ExecuteReader());
                dataGridView1.DataSource = temp;
                sqlConnection1.Close();
            }
            else
            {
                MessageBox.Show("Номер поезда не выбран", "Ошибка выбора", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                dataGridView1.Columns.Clear();
                SqlCommand my_command = new SqlCommand();
                my_command.Connection = sqlConnection1;
                my_command.CommandType = System.Data.CommandType.Text;
                if (comboBox1.SelectedIndex == 0)
                {
                    my_command.CommandText = "select НомерПоезда AS 'Номер поезда',Дата_отправления as 'Дата отправления',Статус, Название AS 'Название станции',Платформа from Расписание join Станция ON Расписание.ID_станции = Станция.ID_станции";
                }
                else
                    my_command.CommandText = "select НомерПоезда AS 'Номер поезда',Дата_отправления as 'Дата отправления',Статус, Название AS 'Название станции',Платформа from Расписание join Станция ON Расписание.ID_станции = Станция.ID_станции where НомерПоезда = '" + comboBox1.SelectedItem.ToString() + "'";
                sqlConnection1.Open();
                var temp = new DataTable();
                temp.Load(my_command.ExecuteReader());
                dataGridView1.DataSource = temp;
                sqlConnection1.Close();
            }
            else
            {
                MessageBox.Show("Номер поезда не выбран", "Ошибка выбора", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                dataGridView1.Columns.Clear();
                SqlCommand my_command = new SqlCommand();
                my_command.Connection = sqlConnection1;
                my_command.CommandType = System.Data.CommandType.Text;
                if (comboBox1.SelectedIndex == 0)
                {
                    my_command.CommandText = "select Номер_поезда AS 'Номер поезда',Откуда,Куда,ВремяВПути as 'Время в пути', ВремяОтправления AS 'Время отправления', Тип as 'Тип поезда' from Поезд";
                }
                else
                    my_command.CommandText = "select Номер_поезда AS 'Номер поезда',Откуда,Куда,ВремяВПути as 'Время в пути', ВремяОтправления AS 'Время отправления', Тип as 'Тип поезда' from Поезд where Номер_поезда = '" + comboBox1.SelectedItem.ToString() + "'";
                sqlConnection1.Open();
                var temp = new DataTable();
                temp.Load(my_command.ExecuteReader());
                dataGridView1.DataSource = temp;
                sqlConnection1.Close();
            }
            else
            {
                MessageBox.Show("Номер поезда не выбран", "Ошибка выбора", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            SqlCommand my_command = new SqlCommand();
            my_command.Connection = sqlConnection1;
            my_command.CommandType = System.Data.CommandType.Text;
            my_command.CommandText = "Select Название, Адрес from Станция where Название like '" + textBox1.Text.ToString() + "%'";
            sqlConnection1.Open();
            var temp = new DataTable();
            temp.Load(my_command.ExecuteReader());
            dataGridView1.DataSource = temp;
            sqlConnection1.Close();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            SqlCommand my_command = new SqlCommand();
            my_command.Connection = sqlConnection1;
            my_command.CommandType = System.Data.CommandType.Text;
            my_command.CommandText = "SELECT Название AS Название,ДатаНачалаДействия as 'Дата начала действия',ДатаКонцаДействия as 'Дата конца действия тарифа',ПроцентКЦене as 'Процент к цене',Активность  FROM Тариф where Название like '" + textBox1.Text.ToString() + "%'";
            sqlConnection1.Open();
            var temp = new DataTable();
            temp.Load(my_command.ExecuteReader());
            dataGridView1.DataSource = temp;
            sqlConnection1.Close();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            SqlCommand my_command = new SqlCommand();
            my_command.Connection = sqlConnection1;
            my_command.CommandType = System.Data.CommandType.Text;
            my_command.CommandText = "select ФИО, ДатаРождения AS 'Дата рождения',Телефон, email from Пассажир where ФИО like '" + textBox1.Text.ToString() + "%'";
            sqlConnection1.Open();
            var temp = new DataTable();
            temp.Load(my_command.ExecuteReader());
            dataGridView1.DataSource = temp;
            sqlConnection1.Close();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            SqlCommand my_command = new SqlCommand();
            my_command.Connection = sqlConnection1;
            my_command.CommandType = System.Data.CommandType.Text;
            my_command.CommandText = "select ФИО as 'Пассажира', ПроданныеБилеты.ID_билета,НомерПоезда as 'Номер поезда',Дата AS 'Дата отправления',Время,Вагон,Место,Название, ДатаПродажи as 'Дата продажи' from ПроданныеБилеты join Пассажир on ПроданныеБилеты.ID_пассажира = Пассажир.ID_пассажира join Билет on Билет.ID_билета = ПроданныеБилеты.ID_билета join Тариф on Билет.ID_тарифа = Тариф.ID_тарифа where ФИО like '" + textBox1.Text.ToString() + "%'";
            sqlConnection1.Open();
            var temp = new DataTable();
            temp.Load(my_command.ExecuteReader());
            dataGridView1.DataSource = temp;
            sqlConnection1.Close();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Form23 form23 = new Form23();
            form23.Show();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Form21 form21 = new Form21();
            form21.Show();
        }
    }
}
