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

namespace WelcomeMessager
{
    public partial class Messages : Form
    {
        public Messages()
        {
            InitializeComponent();
        }
         private void Messages_Load(object sender, EventArgs e)
        {

            using (SqlConnection connection = new SqlConnection("-{REMOVED FOR SECURITY REASONS}-"))
            {

                connection.Open();
                SqlCommand cmdSelect = connection.CreateCommand();
                cmdSelect.CommandText = "SELECT Text FROM Messages";
                SqlDataReader DataRead = cmdSelect.ExecuteReader();

                while (DataRead.Read())
                {
                    comboBox1.Items.Add(DataRead["Text"]);
                    
                }
                connection.Close();
                textBox1.Text = "Type new Message";
            }
            

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "-{REMOVED, dont want anyone to have the password}-")
            {
                if (checkBox1.Checked)
                {

                    if (comboBox1.SelectedIndex == 0)
                    {
                        using (SqlConnection connection = new SqlConnection("-{REMOVED FOR SECURITY REASONS}-"))
                        {
                            using (SqlCommand command = new SqlCommand())
                            {
                                command.Connection = connection;
                                command.CommandType = CommandType.Text;
                                command.CommandText = "INSERT into Messages (Text) VALUES (@Text)";
                                command.Parameters.AddWithValue("@Text", textBox1.Text);
                                connection.Open();
                                command.ExecuteNonQuery();
                                connection.Close();

                            }
                        }
                    }
                    else
                    {
                        using (SqlConnection connection = new SqlConnection("-{REMOVED FOR SECURITY REASONS}-"))
                        {

                            SqlCommand cmdUpdate = new SqlCommand("UPDATE Messages SET Text = @DataContent WHERE ID=" + comboBox1.SelectedIndex.ToString());
                            cmdUpdate.CommandType = CommandType.Text;
                            cmdUpdate.Connection = connection;
                            cmdUpdate.Parameters.AddWithValue("@DataContent", textBox1.Text);
                            connection.Open();
                            cmdUpdate.ExecuteNonQuery();
                            connection.Close();
                        }

                    }

                    this.Close();
                }
                else
                { MessageBox.Show("You have to agree to not have added any slurs or offending content"); }
            }
            else
            { MessageBox.Show("Wrong Password"); }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.Text;

            if (comboBox1.SelectedIndex == 0)
            { button1.Text = "Add new Message";}
            else { button1.Text = "Update Message";}

            
        }

       
    }
}
