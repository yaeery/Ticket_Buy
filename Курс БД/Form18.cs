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
    public partial class Form18 : Form
    {
        public Form18()
        {
            InitializeComponent();
        }

        private void Form18_Load(object sender, EventArgs e)
        {
            sqlConnection1.ConnectionString = EnteryForm.SQL_C;
            SqlCommand my_command = new SqlCommand();
            my_command.Connection = sqlConnection1;
            my_command.CommandType = System.Data.CommandType.Text;
            my_command.CommandText = "select ПроданныеБилеты.ID_билета,НомерПоезда as 'Номер поезда', Откуда,Куда,ВремяВПути AS 'Время В Пути', Дата AS 'Дата отправления',Время,Вагон,Место,Название, ДатаПродажи as 'Дата продажи',Цена from ПроданныеБилеты join Пассажир on ПроданныеБилеты.ID_пассажира = Пассажир.ID_пассажира join Билет on Билет.ID_билета = ПроданныеБилеты.ID_билета join Тариф on Билет.ID_тарифа = Тариф.ID_тарифа join Поезд on Билет.НомерПоезда = Поезд.Номер_поезда where ПроданныеБилеты.ID_пассажира = '" + Form8.Id_Client+ "'";
            sqlConnection1.Open();
            var temp = new DataTable();
            temp.Load(my_command.ExecuteReader());
            dataGridView1.DataSource = temp;
            sqlConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            MainFormForClient mainFormForClient = new MainFormForClient();
            mainFormForClient.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
