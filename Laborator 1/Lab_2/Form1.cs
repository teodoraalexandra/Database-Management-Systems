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
using System.Data.OleDb;
using System.Configuration;

//TO DO FOR WEEK 7:

namespace Lab_2
{
    public partial class Form1 : Form
    {
        //PARENT -> Coach
        //CHILDREN -> Client

        SqlConnection conn;
        SqlDataAdapter dataParent;
        SqlDataAdapter dataChildren;
        DataSet dset;
        String query1;
        String query2;
        String query_save;
        String query_delete;

        BindingSource bsCoach;
        BindingSource bsClient;

        SqlCommandBuilder cmdBldr;
        SqlCommandBuilder command;

        public Form1()
        {
            InitializeComponent();
            fillData();
        }

        private void Form1_Load(Object sender, EventArgs e)
        {
            MessageBox.Show("hei");
            MessageBox.Show(ConfigurationManager.AppSettings["greetings"]);
        }

        string getConectionString()
        {
            return "Data source=DESKTOP-KTGGBHC\\SQLEXPRESS; Initial Catalog=GymSupplements; Integrated Security=true;";

        }

        void fillData()
        {
            MessageBox.Show(ConfigurationManager.AppSettings["greeting"]);

            //SQL CONNECTION
            conn = new SqlConnection(getConectionString());

            //SQL Data Adapter - one for each table
            query1 = "Select * from Coach";
            query2 = "Select * from Client";
            dataParent = new SqlDataAdapter(query1, conn);
            dataChildren = new SqlDataAdapter(query2, conn);

            //SQL Data Set - one for each table
            //Populate the Data Set - data from 2 tables + relation between 2 tables
            dset = new DataSet();
            dataParent.Fill(dset, "Coach");
            dataChildren.Fill(dset, "Client");
            dset.Relations.Add("Antrenament", dset.Tables["Coach"].Columns["CoachId"], dset.Tables["Client"].Columns["CoachId"]);

            //Method1
            //this.dataGridView1.DataSource = dset.Tables["Coach"];
            //this.dataGridView2.DataSource = this.dataGridView1.DataSource;
            //this.dataGridView2.DataMember = "Antrenament";

            //Method2
             bsCoach = new BindingSource();
             bsCoach.DataSource = dset.Tables["Coach"];
             bsClient = new BindingSource(bsCoach, "Antrenament");
             this.dataGridView1.DataSource = bsCoach;
             this.dataGridView2.DataSource = bsClient;

            cmdBldr = new SqlCommandBuilder(dataChildren);
            cmdBldr.GetUpdateCommand();
        }

        private void SAVE_Click(object sender, EventArgs e)
        { 
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                query_save = "insert into Client(FirstName, LastName, Goal, Username, CoachId, City) " +
                    "values ('" + this.fName.Text + "','" + this.lName.Text + "','" + this.goal.Text + "','" + this.username.Text + "','" + this.coachId.Text + "','" + this.city.Text + "') ;";

                command.CommandText = query_save;

                //Execute in SQL
                command.ExecuteNonQuery();
                MessageBox.Show("Save data successfully.");

                //Update in table
                this.dataGridView2.DataSource = bsClient;
                cmdBldr = new SqlCommandBuilder(dataChildren);
                cmdBldr.GetUpdateCommand();

                conn.Close();

                //Refresh the table in application
                this.fillData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void UPDATE_Click(object sender, EventArgs e)
        {
            try
            {
                command = new SqlCommandBuilder(dataChildren);
                dataChildren.Update(dset, "Client");
                MessageBox.Show("Update data successfully.");

                //Refresh the table in application
                this.fillData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void DELETE_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                query_delete = "DELETE FROM Client where ClientId = " + this.clientId.Text;
                command.CommandText = query_delete;

                //Execute in SQL
                command.ExecuteNonQuery();
                MessageBox.Show("Delete data successfully.");

                //Update in table
                this.dataGridView2.DataSource = bsClient;
                cmdBldr = new SqlCommandBuilder(dataChildren);
                cmdBldr.GetUpdateCommand();

                conn.Close();

                //Refresh the table in application
                this.fillData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedId = dataGridView1.Rows[index];
            coachId.Text = selectedId.Cells[0].Value.ToString();

            //Refreshing these fields
            fName.Text = "";
            lName.Text = "";
            goal.Text = "";
            username.Text = "";
            city.Text = "";
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedId = dataGridView2.Rows[index];
            clientId.Text = selectedId.Cells[0].Value.ToString();
        }
    }
}




