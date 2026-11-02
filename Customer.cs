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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
            DisplayCustomer();
        }

        readonly SqlConnection Con = new SqlConnection(connectionString: @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\USER\Documents\Mobile MS.mdf"";Integrated Security=True;Connect Timeout=30");
        private void DisplayCustomer()
        {

            try
            {
                Con.Open();
                string Query = "select * from CTBL";
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                SqlCommandBuilder sql = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                Con.Close();

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
        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox5.Text == " " || comboBox2.Text == " " || textBox2.Text == " " || textBox3.Text == " " || textBox4.Text == " ")
                {

                    MessageBox.Show("Missing Info");
                }
                else
                {
                    Con.Open();
                    string query = "insert into CTBL Values('" + textBox1.Text + "','" + textBox5.Text + "','" + comboBox2.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Record Entered Successfully ");
                    DisplayCustomer();

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

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox5.Text = "";
            comboBox2.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
      
        private void UpdateBtn_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox5.Text == " " || comboBox2.Text == " " || textBox2.Text == " " || textBox3.Text == " " || textBox4.Text == " ")
                {

                    MessageBox.Show("Missing Info");
                }
                else
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM CTBL WHERE CId=@Id", Con);
                    cmd.Parameters.AddWithValue("@Id", textBox1.Text);

                    // SqlCommand cmd = new SqlCommand("update CTBL set CName=@CN, Gender=@G, Address=@A,PurchasedMobil=@PM,Bill=@B WHERE CId=@Key", Con);
                    cmd.Parameters.AddWithValue("@CN", textBox5.Text);
                    cmd.Parameters.AddWithValue("@G", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@A", textBox2.Text);

                    cmd.Parameters.AddWithValue("@PM", textBox3.Text);
                    cmd.Parameters.AddWithValue("@B", textBox4.Text);


                    cmd.Parameters.AddWithValue("@Key", textBox1.Text);

                    // string query = "update MTBL set MTD('" + textBox1.Text + "',MName'" + comboBox1.Text + "',Series'" + comboBox2.Text + "',Storage'" + textBox2.Text + "',Price'" + textBox3.Text + "';";
                    //SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Record update Successfully ");
                    DisplayCustomer();

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
    


        private void DelBtn_Click_1(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter The Customer Id");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete From CTBL WHERE CId='" + textBox1.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Record Deleted Successfully ");
                    DisplayCustomer();
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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox5.Text = row.Cells[1].Value.ToString();
                comboBox2.Text = row.Cells[2].Value.ToString();
                textBox2.Text = row.Cells[3].Value.ToString();
                textBox3.Text = row.Cells[4].Value.ToString();
                textBox4.Text = row.Cells[5].Value.ToString();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }





        //private void dataGridView1_DoubleClick(object sender, EventArgs e)
        ///{
        ////    {
        ////        textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        ////        textBox5.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        ////        comboBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        ////        textBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        ////        textBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        ////        textBox4.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        ////    }

        //}




    }
}
