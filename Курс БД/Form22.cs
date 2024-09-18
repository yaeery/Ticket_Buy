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
    public partial class Form22 : Form
    {
        public Form22()
        {
            InitializeComponent();
        }

        private void Form22_Load(object sender, EventArgs e)
        {
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            bool CheckCorrect = false;
            string message = "";
            //-----------------------------------------------------------------------
            if (dateTimePicker1.Value < Form21.BRIBIV)
            {
                CheckCorrect = true;
                message += "Некоректное время";
                message += "\n";
            }
            if ((comboBox2.SelectedItem != null) &&( (comboBox2.SelectedItem.ToString() == Form21.NACHALO) || (comboBox2.SelectedItem.ToString() == Form21.KONEC)))
            {
                CheckCorrect = true;
                message += "Данная станция уже выбрана";
                message += "\n";
            }
            if (comboBox2.SelectedItem == null)
            {
                CheckCorrect = true;
                message += "Выберете станцию";
                message += "\n";
            }
            for (int i = 0; i < Form21.list.Count; i++)
            {
                if (comboBox2.SelectedItem.ToString() == Form21.list[i][0])
                {
                    CheckCorrect = true;
                    message += "Данная станция уже выбрана";
                    message += "\n";
                    break;
                }
            }
            //--------------------------------------------------------------------------
            if (CheckCorrect == true)
            {
                MessageBox.Show(message, "Ошибка создания", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Form21.list.Add(new List<string>() {comboBox2.SelectedItem.ToString(),dateTimePicker1.Value.ToString("T"),"00:04:00" });
                Form21.MARS.Rows.Clear();
                Form21.MARS.Rows.Add(Form21.NACHALO);
                for (int i = 0; i < Form21.list.Count; i++)
                {
                    Form21.MARS.Rows.Add(Form21.list[i][0]);
                }
                Form21.MARS.Rows.Add(Form21.KONEC);
                MessageBox.Show("Станция успешно добавлена", "успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        
        }
    }
}
