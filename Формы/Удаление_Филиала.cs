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
    public partial class Удаление_Фирмы : Form
    {
        public Удаление_Фирмы()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.OpenNewForm<Удаление_данных>();
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            string query = "select [Branch_code],[City],[Title],[Adress],[Number] from dbo.[Branch_code]";
            var list = DBConnectionService.SendQueryToSqlServer(query)?.Select(row => new IdentityItem(row[0], row[1])).ToArray();
            comboBox1.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = @"SELECT
            [Title]

            FROM [dbo].[Branch]";
            var list = DBConnectionService.SendQueryToSqlServer(query);
            FormExtentions.ClearAndAddColumnsInDataGridView(dataGridView1, "Title");
            foreach (var row in list) 
            {
                dataGridView1.Rows.Add(row[0]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int? id = Convert.ToInt32(((IdentityItem)comboBox1.SelectedItem)?.Id);
            string query = "Delete from dbo.Branch where [Branch_code]=" + id;
            int? result = DBConnectionService.SendCommandToSqlServer(query);
            if (result != null && result > 0)
            {
                MessageBox.Show("done");
                comboBox1.SelectedItem = null;
            }
        }

        private void button2_DragDrop(object sender, DragEventArgs e)
        {

        }
    }
}
