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
    public partial class Form21 : Form
    {
        public static List<List<string>> list = new List<List<string>>();

        public static DateTime BRIBIV;
        public static string NACHALO;
        public static string KONEC;

        public static DataGridView MARS;
        public Form21()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton2.Checked = false;
            button1.Enabled = true;
            list.Clear();
            dataGridView1.Rows.Clear();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            button1.Enabled = false;
            list.Clear();
            dataGridView1.Rows.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool CheckCorrect = false;
            string message = "";
            if ((textBox1.Text == null) || (textBox1.Text == ""))
            {
                CheckCorrect = true;
                message += "Некоректный номер поезда";
                message += "\n";
            }
            else if ((textBox1.Text != null) && (textBox1.Text.Length > 0))
            {
                string x = textBox1.Text;
                string v = x.Trim();
                if (v == "")
                {
                    CheckCorrect = true;
                    message += "Некоректный номер поезда";
                    message += "\n";
                    textBox1.Text = null;
                }
            }
            //-----------------------------------------------------------------------
            if (comboBox2.SelectedItem == null)
            {
                CheckCorrect = true;
                message += "Выберете начальную станцию";
                message += "\n";
            }
            if (comboBox3.SelectedItem == null)
            {
                CheckCorrect = true;
                message += "Выберете кончную станцию станцию";
                message += "\n";
            }
            if ((comboBox2.SelectedItem != null) && (comboBox3.SelectedItem != null) && (comboBox2.SelectedItem.ToString() == comboBox3.SelectedItem.ToString()))
            {
                CheckCorrect = true;
                message += "Начальные и конечные станции не должны совподать";
                message += "\n";
                comboBox3.SelectedItem = null;
            }

            //--------------------------------------------------------------------------
            if (!(dateTimePicker2.Value < dateTimePicker1.Value))
            {
                CheckCorrect = true;
                message += "Время отправления должно быть раньше чем прибытие";
                message += "\n";
            }
            if ((radioButton1.Checked == false) && (radioButton2.Checked == false))
            {
                CheckCorrect = true;
                message += "Не указан тип поезда";
                message += "\n";
            }
            if (CheckCorrect == true)
            {
                MessageBox.Show(message, "Ошибка создания", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                NACHALO = comboBox2.SelectedItem.ToString();
                KONEC = comboBox3.SelectedItem.ToString();
                if (list.Count == 0)
                {
                    BRIBIV = dateTimePicker2.Value;
                }
                else
                {
                    BRIBIV = (Convert.ToDateTime(list[list.Count - 1][1])).AddMinutes(4);
                }
                Form22 form22 = new Form22();
                form22.Show();
            }
        }

        private void Form21_Load(object sender, EventArgs e)
        {
            MARS = dataGridView1;
            radioButton2.Checked = true;
            sqlConnection1.ConnectionString = EnteryForm.SQL_C;
            this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            sqlConnection1.Open();
            SqlCommand sqlCommand_C2 = new SqlCommand("SELECT Название FROM Станция", sqlConnection1);
            SqlDataReader Type2 = sqlCommand_C2.ExecuteReader();
            while (Type2.Read())
            {
                comboBox2.Items.Add(Type2[0].ToString());
            }
            Type2.Close();
            sqlConnection1.Close();
           //----------------------------------
            this.comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            sqlConnection1.Open();
            SqlCommand sqlCommand_C3 = new SqlCommand("SELECT Название FROM Станция", sqlConnection1);
            SqlDataReader Type3 = sqlCommand_C3.ExecuteReader();
            while (Type3.Read())
            {
                comboBox3.Items.Add(Type3[0].ToString());
            }
            Type3.Close();
            sqlConnection1.Close();

            DataGridViewTextBoxColumn newColumn = new DataGridViewTextBoxColumn();
            newColumn.HeaderText = "Маршрут"; // Заголовок
            newColumn.Name = "newColumn"; // Название столбца
            newColumn.ValueType = typeof(string); // Тип данных в столбце

            dataGridView1.Columns.Add(newColumn); // Добавляем столбец к DataGridView
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool CheckCorrect = false;
            string message = "";
            if ((textBox1.Text == null) || (textBox1.Text == "") || ((!Int64.TryParse(textBox1.Text, out Int64 num))))
            {
                CheckCorrect = true;
                message += "Некоректный номер поезда";
                message += "\n";
            }
            else if ((textBox1.Text != null) && (textBox1.Text.Length > 0))
            {
                string x = textBox1.Text;
                string v = x.Trim();
                if (v == "")
                {
                    CheckCorrect = true;
                    message += "Некоректный номер поезда";
                    message += "\n";
                    textBox1.Text = null;
                }
            }
            //-----------------------------------------------------------------------
            if (comboBox2.SelectedItem == null)
            {
                CheckCorrect = true;
                message += "Выберете начальную станцию";
                message += "\n";
            }
            if (comboBox3.SelectedItem == null)
            {
                CheckCorrect = true;
                message += "Выберете кончную станцию станцию";
                message += "\n";
            }
            if ((comboBox2.SelectedItem != null) && (comboBox3.SelectedItem != null) && (comboBox2.SelectedItem.ToString() == comboBox3.SelectedItem.ToString()))
            {
                CheckCorrect = true;
                message += "Начальные и конечные станции не должны совподать";
                message += "\n";
                comboBox3.SelectedItem = null;
            }

            //--------------------------------------------------------------------------
            if (!(dateTimePicker2.Value < dateTimePicker1.Value))
            {
                CheckCorrect = true;
                message += "Время отправления должно быть раньше чем прибытие";
                message += "\n";
            }
            if ((radioButton1.Checked == false) &&(radioButton2.Checked == false))
            {
                CheckCorrect = true;
                message += "Не указан тип поезда";
                message += "\n";
            }
            if (CheckCorrect == true)
            {
                MessageBox.Show(message, "Ошибка создания", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    string radio = "";
                    if (radioButton1.Checked == true)
                        radio = "Пассажирский";
                    else
                        radio = "Экспресс";
                    TimeSpan datatime = (dateTimePicker1.Value.Subtract(dateTimePicker2.Value));
                    sqlConnection1.Open();
                    SqlCommand sqlCommand_Cl2 = new SqlCommand("insert into Поезд values ('"+ textBox1.Text.ToString() + "','"+comboBox2.SelectedItem.ToString()+ "','" + comboBox3.SelectedItem.ToString() + "','"+ (dateTimePicker1.Value.Subtract(dateTimePicker2.Value)).ToString("T") +"','"+ dateTimePicker2.Value.ToString("T") + "','"+ radio + "')", sqlConnection1);
                    sqlCommand_Cl2.ExecuteNonQuery();
                    sqlConnection1.Close();
                    list.Insert(0,new List<string>() {comboBox2.SelectedItem.ToString(), dateTimePicker2.Value.ToString("T"), "00:00:00"});
                    list.Add(new List<string>() { comboBox3.SelectedItem.ToString(), dateTimePicker1.Value.ToString("T"), "00:00:00" });
                    sqlConnection1.Open();
                    for (int i = 0; i < list.Count; i++)
                    {
                        SqlCommand sqlCommand_Cl23 = new SqlCommand("insert into Остановка values ('"+textBox1.Text.ToString()+"',(select ID_станции from Станция where Название = '"+list[i][0]+ "'), '" + list[i][1] + "','" + list[i][2] + "')", sqlConnection1);
                        sqlCommand_Cl23.ExecuteNonQuery();
                    }
                    sqlConnection1.Close();
                    list.Clear();
                    MessageBox.Show("Поезд успешно добавлен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception E)
                {
                    
                    string b = E.Message;
                    MessageBox.Show("Номер поезда уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sqlConnection1.Close();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
