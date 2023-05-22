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
    public partial class Form5 : MetroFramework.Forms.MetroForm
    {
        /*MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter;*/
        private Button but7;
        private Button but8;
        private Button but6;
        private Button but9;
        public Form5(Button but, Button but1, Button but2, Button but3)
        {
            InitializeComponent();
            but7 = but;
            but8 = but1;
            but6 = but2;
            but9 = but3;
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            but9.Visible = false;
            but7.Visible = false;
            but8.Visible = false;
            but6.Text = "Войти как администратор";
            but6.ForeColor = Color.Black;
            but6.Enabled = true;
            this.Close();
        }
    }
}
