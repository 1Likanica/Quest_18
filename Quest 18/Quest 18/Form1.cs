using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;

namespace Quest_18
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter;
        public Form1()
        {
            InitializeComponent();

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection("server=127.0.0.1;uid=root;pwd=root;database=Quest 18");
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;

            DataTable dataTable = new DataTable();
            mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(string.Format("SELECT dannie.nazvanie AS 'Название', cell_bileta_day_rub AS 'Цена билета днём', count_people_day AS 'Колво людей днём', cell_bileta_night_rub AS 'Цена билета ночью', count_people_night AS 'Колво людей ночью', viruchka.viruchka_day_rub AS 'Выручка за день', viruchka.viruchka_night_rub AS 'Выручка за ночь', count_rabochih_day AS 'Кoлвo рабочих дней', full_viruchka.full_viruchka_rub AS 'Выручка за месяц' FROM dannie JOIN full_viruchka USING (nazvanie) JOIN viruchka USING (nazvanie)", dataGridView1.Text), conn);
            try
            {
                mySqlDataAdapter.Fill(dataTable);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.DataSource = dataTable;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            if (checkBox1.Checked == false)
            {
                mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(string.Format("SELECT dannie.nazvanie AS 'Название', cell_bileta_day_rub AS 'Цена билета днём', count_people_day AS 'Колво людей днём', cell_bileta_night_rub AS 'Цена билета ночью', count_people_night AS 'Колво людей ночью', viruchka.viruchka_day_rub AS 'Выручка за день', viruchka.viruchka_night_rub AS 'Выручка за ночь', count_rabochih_day AS 'Кoлвo рабочих дней', full_viruchka.full_viruchka_rub AS 'Выручка за месяц' FROM dannie JOIN full_viruchka USING (nazvanie) JOIN viruchka USING (nazvanie)", dataGridView1.Text), conn);
                try
                {
                    mySqlDataAdapter.Fill(dataTable);
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else
            {
                mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(string.Format("SELECT dannie.nazvanie AS 'Название', cell_bileta_day_rub AS 'Цена билета днём', count_people_day AS 'Колво людей днём', cell_bileta_night_rub AS 'Цена билета ночью', count_people_night AS 'Колво людей ночью', viruchka.viruchka_day_rub AS 'Выручка за день', viruchka.viruchka_night_rub AS 'Выручка за ночь', count_rabochih_day AS 'Кoлвo рабочих дней', full_viruchka.full_viruchka_rub AS 'Выручка за месяц' FROM dannie JOIN full_viruchka USING (nazvanie) JOIN viruchka USING (nazvanie) ORDER BY cell_bileta_night_rub", dataGridView1.Text), conn);
                try
                {
                    mySqlDataAdapter.Fill(dataTable);
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.DataSource = dataTable;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(string.Format("SELECT nazvanie AS 'Название', viruchka_day_rub AS 'Выручка днём' FROM viruchka", dataGridView1.Text), conn);
            try
            {
                mySqlDataAdapter.Fill(dataTable);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.DataSource = dataTable;
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(string.Format("SELECT nazvanie AS 'Название', viruchka_night_rub AS 'Выручка ночью' FROM viruchka", dataGridView1.Text), conn);
            try
            {
                mySqlDataAdapter.Fill(dataTable);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.DataSource = dataTable;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(string.Format("SELECT nazvanie AS 'Название' , full_viruchka_rub AS 'Выручкa за месяц' FROM full_viruchka", dataGridView1.Text), conn);
            try
            {
                mySqlDataAdapter.Fill(dataTable);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.DataSource = dataTable;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(string.Format("SELECT nazvanie AS 'Название', count_rabochih_day AS 'Кoлво рабочих дней', full_viruchka_rub AS 'Выручка за мeсяц'  FROM expensive_disc", dataGridView1.Text), conn);
            try
            {
                mySqlDataAdapter.Fill(dataTable);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.DataSource = dataTable;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2(this.button7, this.button8, this.button6, this.button9);
            newForm.Show();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form3 newForm = new Form3(this.dataGridView1);
            newForm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form4 newForm = new Form4(this.dataGridView1);
            newForm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form5 newForm = new Form5(this.button7, this.button8, this.button6, this.button9);
            newForm.Show();
        }
    }
   
}
