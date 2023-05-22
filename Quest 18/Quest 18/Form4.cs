using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quest_18
{
    public partial class Form4: MetroFramework.Forms.MetroForm
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter;
        private DataGridView DGV1;

        public Form4(DataGridView DGV)
        {
            InitializeComponent();
            button1.Enabled = false;
            DGV1 = DGV;
            

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

            popularNameList();
        }
        private void Form4_Load(object sender, EventArgs e)
        {

        }
        private void popularNameList()
        {
            mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter("SELECT nazvanie FROM dannie;", conn);
            DataTable dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                metroComboBox1.Items.Add(dataRow.Field<string>("nazvanie"));
            }
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroComboBox1.SelectedItem != null)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(string.Format($"DELETE FROM `dannie` WHERE `dannie`.`nazvanie` = '{metroComboBox1.SelectedItem}'"), conn);
            try
            {
                mySqlDataAdapter.Fill(dataTable);
                MessageBox.Show("Успешно!");
                mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(string.Format("SELECT dannie.nazvanie AS 'Название', cell_bileta_day_rub AS 'Цена билета днём', count_people_day AS 'Колво людей днём', cell_bileta_night_rub AS 'Цена билета ночью', count_people_night AS 'Колво людей ночью', viruchka.viruchka_day_rub AS 'Выручка за день', viruchka.viruchka_night_rub AS 'Выручка за ночь', count_rabochih_day AS 'Кoлвo рабочих дней', full_viruchka.full_viruchka_rub AS 'Выручка за месяц' FROM dannie JOIN full_viruchka USING (nazvanie) JOIN viruchka USING (nazvanie)", DGV1.Text), conn);
                try
                {
                    mySqlDataAdapter.Fill(dataTable);
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                DGV1.ColumnHeadersVisible = true;
                DGV1.DataSource = dataTable;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }
    }
}
