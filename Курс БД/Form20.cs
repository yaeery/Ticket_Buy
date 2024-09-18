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
    public partial class Form20 : Form
    {
        static DateTime dateTime;
        public Form20()
        {
            InitializeComponent();
        }

        private void Form20_Load(object sender, EventArgs e)
        {
            {
                sqlConnection1.ConnectionString = EnteryForm.SQL_C;
                sqlConnection1.Open();
                SqlCommand sqlCommand_Cl = new SqlCommand("select Название from Тариф where Активность = 'F' ", sqlConnection1);
                SqlDataReader Type = sqlCommand_Cl.ExecuteReader();
                while (Type.Read())
                {
                    checkedListBox1.Items.Add(Type[0].ToString());
                }
                Type.Close();
                sqlConnection1.Close();

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Не выбран ни один тариф!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sqlConnection1.Open();
                SqlCommand sqlCommand_Cl2 = new SqlCommand(" select ДатаКонцаДействия from Тариф where Название = '" + checkedListBox1.CheckedItems[0]+"'", sqlConnection1);
                object Type = sqlCommand_Cl2.ExecuteScalar();
                sqlConnection1.Close();
                bool qestion = false;
                if (Convert.ToDateTime(Type.ToString()) < DateTime.Now)
                {
                    var result = MessageBox.Show("Хотители вы продлить дейсвие тарифа на неделю?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // If the no button was pressed ... 
                    if (result == DialogResult.No)
                    {
                        // cancel the closure of the form. 
                        qestion = false;
                    }
                    else
                    {
                        qestion = true;
                    }
                }
                else if ((Convert.ToDateTime(Type.ToString()) > DateTime.Now))
                {
                    string where_string = " where ";
                    for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                    {
                        where_string += " Название = '";
                        where_string += checkedListBox1.CheckedItems[i];
                        MessageBox.Show("Тариф " + checkedListBox1.CheckedItems[i].ToString() + " возвращён в действие ", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (i != checkedListBox1.CheckedItems.Count - 1)
                        {
                            where_string += "' or ";
                        }
                    }
                    where_string += " '";
                    sqlConnection1.Open();
                    SqlCommand sqlCommand_Cl22 = new SqlCommand(" Update Тариф set Активность = 'T' " + where_string, sqlConnection1);
                    sqlCommand_Cl22.ExecuteNonQuery();
                    sqlConnection1.Close();
                    for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                    {
                        checkedListBox1.Items.RemoveAt(checkedListBox1.CheckedIndices[i]);
                        i--;
                    }
                }
                if (qestion == true)
                {
                    sqlConnection1.Open();
                    SqlCommand sqlCommand_Cl22 = new SqlCommand(" Update Тариф set Активность = 'T' , ДатаКонцаДействия = '" + DateTime.Now.AddDays(7) + "' where Название = '" + checkedListBox1.CheckedItems[0] + "' ", sqlConnection1);
                    sqlCommand_Cl22.ExecuteNonQuery();
                    sqlConnection1.Close();
                    MessageBox.Show("Тариф " + checkedListBox1.CheckedItems[0].ToString() + " возвращён в действие и продлён на неделю ", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    checkedListBox1.Items.RemoveAt(checkedListBox1.CheckedIndices[0]);
                }
                else
                {
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        checkedListBox1.SetItemChecked(i, false);
                    }
                }
            }
        }
        

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }
    }
}
