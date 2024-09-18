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
    public partial class Form23 : Form
    {
        public Form23()
        {
            InitializeComponent();
        }

        private void Form23_Load(object sender, EventArgs e)
        {
            sqlConnection1.ConnectionString = EnteryForm.SQL_C;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            SqlCommand sqlCommand_Cl2 = new SqlCommand("SELECT COUNT(*) FROM Станция WHERE Название = '" + textBox1.Text.ToString() + "'", sqlConnection1);
            object Nazvanie = sqlCommand_Cl2.ExecuteScalar();
            sqlConnection1.Close();
            if (Convert.ToInt32(Nazvanie) >= 1)
            {
                MessageBox.Show("Станция с таким названием уже существует", "Ошибка создания", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sqlConnection1.Open();
                SqlCommand sqlCommand_Cl22 = new SqlCommand("insert into Станция values ((SELECT COUNT(*) from Станция)+1,'" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "')", sqlConnection1);
                sqlCommand_Cl22.ExecuteNonQuery();
                sqlConnection1.Close();
                MessageBox.Show("Станция добавлена", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
