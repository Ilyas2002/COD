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
    public partial class Удаление_Страхового_Агента : Form
    {
        public Удаление_Страхового_Агента()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.OpenNewForm<Удаление_данных>();
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

        private void button2_Click(object sender, EventArgs e)
        {
            string query = @"SELECT
            [FIO]

            FROM [dbo].[Insurance_agent]";
            var list = DBConnectionService.SendQueryToSqlServer(query);
            FormExtentions.ClearAndAddColumnsInDataGridView(dataGridView1, "FIO");
            foreach (var row in list)
            {
                dataGridView1.Rows.Add(row[0]);
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            string query = "select [Agent_cd],[Branch_cd],[Fio],[Pol],[Number_ct] from dbo.[Insurance_agent]";
            var list = DBConnectionService.SendQueryToSqlServer(query)?.Select(row => new IdentityItem(row[0], row[1])).ToArray();
            comboBox1.Items.Clear();
        }
    }
}
