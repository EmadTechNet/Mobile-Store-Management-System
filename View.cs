using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;//what do


namespace mobil
{
    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
        }
        readonly SqlConnection Con = new SqlConnection(connectionString: @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\USER\Documents\Mobile MS.mdf"";Integrated Security=True;Connect Timeout=30");

        private void FetchCus()
        {
            try
            {
                Con.Open();
                string query = "select * from CTBL WHERE CId='" + textBox1.Text + "'";
                SqlCommand sql = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(sql);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    label4.Text = dr["CId"].ToString();
                    label6.Text = dr["CName"].ToString();
                    label8.Text = dr["Gender"].ToString();
                    label10.Text = dr["Adderss"].ToString();
                    label12.Text = dr["PurchasedMobile"].ToString();
                    label14.Text = dr["Bill"].ToString();
                    label4.Visible = true;
                    label6.Visible = true;
                    label8.Visible = true;
                    label10.Visible = true;
                    label12.Visible = true;
                    label14.Visible = true;


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
        //private void FetchCus()
        //{
        //    try
        //    {
        //        if (string.IsNullOrWhiteSpace(textBox1.Text))
        //        {
        //            MessageBox.Show("Please enter a Customer Id first.");
        //            return;
        //        }

        //        Con.Open();
        //        SqlCommand sql = new SqlCommand("SELECT * FROM CTBL WHERE CId=@Id", Con);
        //        sql.Parameters.AddWithValue("@Id", textBox1.Text);

        //        SqlDataReader dr = sql.ExecuteReader();
        //        if (dr.Read())
        //        {
        //            label4.Text = dr["CId"].ToString();
        //            label6.Text = dr["CName"].ToString();
        //            label8.Text = dr["Gender"].ToString();
        //            label10.Text = dr["Address"].ToString();
        //            label12.Text = dr["PurchasedMobile"].ToString();
        //            label14.Text = dr["Bill"].ToString();

        //            // إظهار الليبلات
        //            label4.Visible = true;
        //            label6.Visible = true;
        //            label8.Visible = true;
        //            label10.Visible = true;
        //            label12.Visible = true;
        //            label14.Visible = true;
        //        }
        //        else
        //        {
        //            MessageBox.Show("No customer found with this Id.");
        //        }
        //        dr.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        Con.Close();
        //    }
        //}

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        

        private void RefereshBtn_Click(object sender, EventArgs e)
        {
            FetchCus(); 
        }

        
    }
}
