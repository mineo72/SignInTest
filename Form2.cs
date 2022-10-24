using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp16
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = "server=localhost;user=root;database=dotnet;port=3306;password=Got22259";
            MySqlConnection conn = new(connStr);
            conn.Open();
            string takenCheck = "SELECT`AUTO_INCREMENT` FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dotnet' AND TABLE_NAME = 'info';";
            MySqlCommand cmd = new(takenCheck, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            int id = rdr.GetInt32(0);
            rdr.Close();
            MySqlCommand insComm = new($"INSERT INTO info(infoName, infoPlace, infoUserId) VALUES('{textBox1.Text}', '{textBox2.Text}', {id})", conn);
            insComm.ExecuteNonQuery();
            MessageBox.Show("Signed Up!");
            conn.Close();
            Form2 form = new Form2();
            form.Close();
        }
    }
}
