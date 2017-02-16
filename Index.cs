using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotkeys;

namespace WelcomeMessager
{
    public partial class Default : Form
    {
        private Hotkeys.GlobalHotkey ghk;
        private string CosMsg;

        public Default()
        {
            InitializeComponent();
            ghk = new GlobalHotkey(Constants.NOMOD , Keys.Home, this);

        }
         protected override void WndProc(ref Message m)
        {
            if (m.Msg == Hotkeys.Constants.WM_HOTKEY_MSG_ID)
                HandleHotkey();
            base.WndProc(ref m);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ghk.Register();
            
            
        }
        private void HandleHotkey()
        {
            using (SqlConnection connection = new SqlConnection("-{REMOVED FOR SECURITY REASON}-"))
            {

                connection.Open();
                SqlCommand cmdSelect = connection.CreateCommand();
                cmdSelect.CommandText = "SELECT Text FROM Messages WHERE ID = ABS(Checksum(NewID()) % (SELECT MAX(ID) FROM Messages)) + 1 ";
                SqlDataReader DataRead = cmdSelect.ExecuteReader();

                while (DataRead.Read())
                {
                    CosMsg = DataRead["Text"].ToString();
                }
                connection.Close();
            }

            
            SendKeys.SendWait("{ENTER}");
            SendKeys.SendWait("/g "+CosMsg);
            SendKeys.SendWait("{ENTER}");

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Keybinder keybind = new Keybinder();
            keybind.Show();
        }

        private void Index_Leave(object sender, EventArgs e)
        {

        }
         private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ghk.Unregiser())
                MessageBox.Show("Hotkey failed to unregister!");
        }

         private void button1_Click(object sender, EventArgs e)
         {
             Messages Page = new Messages();
             Page.Show();
         }
    }
}
