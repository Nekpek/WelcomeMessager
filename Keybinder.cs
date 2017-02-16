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

    public partial class Keybinder : Form
    {

        public Keybinder()
        {
            InitializeComponent();
            
        }
       
        private void Keybinder_Load(object sender, EventArgs e)
        {
          
            label1.Text = "Hotkeys Not configurable";

        }

        private void configurationsBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

       
        void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
           
        }

      
    }
}
