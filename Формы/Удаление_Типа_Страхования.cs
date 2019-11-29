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
    public partial class Удаление_Типа_Страхования : Form
    {
        public Удаление_Типа_Страхования()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.OpenNewForm<Удаление_данных>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            string cb1 = ((IdentityItem)comboBox1.SelectedItem)?.Name;
            string query = "Delete from [Аренда] WHERE [id] = " + cb1;
            int? count = DBConnectionService.SendCommandToSqlServer(query);
            MessageBox.Show("Выбранная вами аренда была успешно удалена!");
            this.Close();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = @"SELECT
            [Title]

            FROM [dbo].[Insurance_type]";
            var list = DBConnectionService.SendQueryToSqlServer(query);
            FormExtentions.ClearAndAddColumnsInDataGridView(dataGridView1, "Title");
            foreach (var row in list)
            {
                dataGridView1.Rows.Add(row[0]);
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            string query = "select [Code_in],[Title],[App] from dbo.[Insurance_type]";
            var list = DBConnectionService.SendQueryToSqlServer(query)?.Select(row => new IdentityItem(row[0], row[1])).ToArray();
            comboBox1.Items.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = (comboBox1.SelectedItem as IdentityItem)?.Id;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
