using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курс_БД
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11("Администратор");
            form11.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11("Диспетчер");
            form11.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            EnteryForm enteryForm = new EnteryForm();
            enteryForm.Show();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
    }
}
