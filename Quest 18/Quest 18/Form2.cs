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
    public partial class Form2 : MetroFramework.Forms.MetroForm
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter;
        private Button but7;
        private Button but8;
        private Button but6;
        private Button but9;
        public Form2(Button but, Button but1, Button but2, Button but3)
        {
            but7 = but;
            but8 = but1;
            but6 = but2;
            but9 = but3;
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
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            var loginUser = textBox1.Text;
            var passwordUser = textBox2.Text;
            string sql = $"SELECT login, pwd, name FROM admin WHERE login = '{loginUser}' AND pwd = '{passwordUser}'";
            DataTable dataTable = new DataTable();
            mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn);
            mySqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count == 1)
            {
                DataRow dataRow;
                dataRow = dataTable.Rows[0];
                MessageBox.Show(string.Format("Добро пожаловать, {0}!", dataRow.Field<string>("name")));
                but7.Visible = true;
                but8.Visible = true;
                this.Close();
                but6.Text = dataRow.Field<string>("name");
                but6.ForeColor = Color.Black;
                but6.Enabled = false;
                but9.Visible = true;
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!");
            }

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

    }
}

