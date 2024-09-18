using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Курс_БД
{
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }

        private void Form16_Load(object sender, EventArgs e)
        {
            sqlConnection1.ConnectionString = EnteryForm.SQL_C;
            SqlCommand my_command = new SqlCommand();
            my_command.Connection = sqlConnection1;
            my_command.CommandType = System.Data.CommandType.Text;
            my_command.CommandText = "SELECT Название , Адрес FROM Станция";
            sqlConnection1.Open();
            var temp = new DataTable();
            temp.Load(my_command.ExecuteReader());
            dataGridView1.DataSource = temp;
            sqlConnection1.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            MainFormForClient mainFormForClient = new MainFormForClient();
            mainFormForClient.Show();
        }
    }
}
