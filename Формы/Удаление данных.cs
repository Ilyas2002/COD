using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SqlServerTestApp
{
    public partial class Удаление_данных : Form
    {
        public Удаление_данных()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void Удаление_данных_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.OpenNewForm<Удаление_Фирмы>();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.OpenNewForm<Удаление_Договора>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.OpenNewForm<Удаление_Данных_о_клиенте>();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.OpenNewForm<Удаление_Страхового_Агента>();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.OpenNewForm<Удаление_Типа_Страхования>();
        }
    }
}
