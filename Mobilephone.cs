using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace mobil
{
    public partial class Mobilephone : Form
    {
        public Mobilephone()
        {
            InitializeComponent();
            DisplayMobile();
        }
        readonly SqlConnection Con = new SqlConnection(connectionString: @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\USER\Documents\Mobile MS.mdf"";Integrated Security=True;Connect Timeout=30");
        private void DisplayMobile()
        {
            try
            {
                Con.Open();
                string Query = "select * from MTBL";
                SqlDataAdapter sda = new SqlDataAdapter(Query,Con);
                SqlCommandBuilder sql = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                Con.Close();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

       

        private void Mobilephone_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || comboBox1.Text == " " || comboBox2.Text == " " || textBox2.Text == " " || textBox3.Text == " ")
                {

                    MessageBox.Show("Missing Info");
                }
                else
                {
                    Con.Open();
                    string query = "insert into MTBL Values('"+textBox1.Text+"','"+comboBox1.Text +"','"+comboBox2.Text+"','"+textBox2.Text+"','"+textBox3.Text+"')";
                    SqlCommand cmd = new SqlCommand(query,Con);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Record Entered Successfully ");
                    DisplayMobile();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            {
                MessageBox.Show("Enter The Mobile Id");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete From MTBL WHERE MId='" + textBox1.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Record Deleted Successfully ");
                    DisplayMobile();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Con.Close();
                }
            }

        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || comboBox1.Text == " " || comboBox2.Text == " " || textBox2.Text == " " || textBox3.Text == " ")
                {

                    MessageBox.Show("Missing Info");
                }
                else
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update MTBL set MName=@CN, Series=@CS, Storage=@S, Price=@P WHERE MId=@Key", Con);
                    cmd.Parameters.AddWithValue("@CN", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@CS", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@S", textBox2.Text);

                    cmd.Parameters.AddWithValue("@P", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Key", textBox1.Text);

                   // string query = "update MTBL set MTD('" + textBox1.Text + "',MName'" + comboBox1.Text + "',Series'" + comboBox2.Text + "',Storage'" + textBox2.Text + "',Price'" + textBox3.Text + "';";
                    //SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Record update Successfully ");
                    DisplayMobile();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
