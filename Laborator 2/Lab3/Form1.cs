using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Lab3
{
    public partial class Form1 : Form
    {

        string getConectionString()
        {
            return "Data source=DESKTOP-KTGGBHC\\SQLEXPRESS; Initial Catalog=GymSupplements; Integrated Security=true;";

        }

        //SQL connection
        SqlConnection connection;

        //Data Adapter and Data Set
        private SqlDataAdapter da = new SqlDataAdapter();
        private DataSet ds = new DataSet();

        //Name of tables - generic
        private string childTableName = ConfigurationManager.AppSettings["ChildTableName"];
        private string parentTableName = ConfigurationManager.AppSettings["ParentTableName"];

        //Columns of the child table
        private string columnNamesInsertParameters = ConfigurationManager.AppSettings["ColumnNamesInsertParameters"];

        //A list in which we will keep the name of the columns -> and we create the labels
        private List<string> columnNames = new List<string>(ConfigurationManager.AppSettings["ChildLabelNames"].Split(','));

        //A list in which we will keep the parameters -> shown as strings in the created text boxes
        private List<string> paramsNames = new List<string>(ConfigurationManager.AppSettings["ColumnNamesInsertParameters"].Split(','));

        //Example of a child -> hardcoded parameters in App.config
        private List<string> columnInitiate = new List<string>(ConfigurationManager.AppSettings["ChildTextBoxContent"].Split(','));

        //The number of the columns (we need to know how many text boxes do we need)
        private int nr = Convert.ToInt32(ConfigurationManager.AppSettings["ChildNumberOfColumns"]);

        //This will apear in the right side of the gui (and will be different for every scenario)
        private TextBox[] textBoxes;
        private Label[] labels;

        public Form1()
        {
            InitializeComponent();
            PopulatePanel();
            //Add handlers for every data grid view

            //Every time we click parent data grid view -> different children will be selected, acording to parent id
            dataGridViewParent.SelectionChanged += new EventHandler(LoadChildren);
            //Every time we click child data grid view -> in the right panel, text boxes will be updated with the child selected
            dataGridViewChild.SelectionChanged += new EventHandler(LoadInformation);
            
            //Get sql connection
            connection = new SqlConnection(getConectionString());
            LoadParent();
        }

        private void PopulatePanel()
        {
            //This function will create #nr text boxes and #nr labels, depending on the given scenario from App.config
            textBoxes = new TextBox[nr];
            labels = new Label[nr];

            for (int i = 0; i < nr; i++)
            {
                textBoxes[i] = new TextBox();
                textBoxes[i].Text = columnInitiate[i];
                labels[i] = new Label();
                labels[i].Text = columnNames[i];
            }

            for (int i = 0; i < nr; i++)
            {
                flowLayoutPanel1.Controls.Add(textBoxes[i]);
                flowLayoutPanel1.Controls.Add(labels[i]);
            }
        }

        private void LoadChildren(object sender, EventArgs e)
        {
            LoadChildren();
        }

        private void LoadChildren()
        {
            //Create the relation between tables -> get the parent id and "select from child where parent id = ..."
            int parentId = (int)dataGridViewParent.CurrentRow.Cells[0].Value;
            string select = ConfigurationManager.AppSettings["SelectChild"];

            //Execute the sql command
            SqlCommand cmd = new SqlCommand(select, connection);
            cmd.Parameters.AddWithValue("@id", parentId);

            //Populate the child table using Data Adapter and Data Set
            SqlDataAdapter daChild = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();

            daChild.Fill(dataSet);
            dataGridViewChild.DataSource = dataSet.Tables[0];
        }

        private void LoadInformation(object sender, EventArgs e)
        {
            LoadInformation();
        }

        private void LoadInformation()
        {
            for (int i = 0; i < nr; i++)
                textBoxes[i].Text = Convert.ToString(dataGridViewChild.CurrentRow.Cells[i + 1].Value);
        }

        private void LoadParent()
        {
            //This function will populate the parent table

            string select = ConfigurationManager.AppSettings["SelectParent"];
            da.SelectCommand = new SqlCommand(select, connection);
            ds.Clear();
            da.Fill(ds);
            dataGridViewParent.DataSource = ds.Tables[0];
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            //This function let user to see all the children (doesn't consider the parent id)

            string select = ConfigurationManager.AppSettings["SelectQuery"];
            SqlCommand cmd = new SqlCommand(select, connection);
            SqlDataAdapter daChild = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();

            daChild.Fill(dataSet);
            dataGridViewChild.DataSource = dataSet.Tables[0];
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Parameters will be taken from the text boxes from the right side 

                SqlCommand cmd = new SqlCommand("insert into " + childTableName + " ( " + ConfigurationManager.AppSettings["ChildLabelNames"] + " ) values ( " + columnNamesInsertParameters + " )", connection);
                for (int i = 0; i < nr; i++)
                {
                    cmd.Parameters.AddWithValue(paramsNames[i], textBoxes[i].Text);
                }
                SqlDataAdapter daChild = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                connection.Open();
                daChild.Fill(dataSet);
                connection.Close();
                MessageBox.Show("Data added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                connection.Close();
            }

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Parameters will be taken from the text boxes from the right side 

                string delete = ConfigurationManager.AppSettings["DeleteChild"];
                SqlCommand cmd = new SqlCommand(delete, connection);
                cmd.Parameters.AddWithValue("@id", (int)dataGridViewChild.CurrentRow.Cells[0].Value);
                SqlDataAdapter daChild = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                connection.Open();
                cmd.ExecuteNonQuery();
                daChild.Fill(dataSet);
                connection.Close();
                MessageBox.Show("Data deleted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                connection.Close();
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Parameters will be taken from the text boxes from the right side 

                string update = ConfigurationManager.AppSettings["UpdateQuery"];
                SqlCommand cmd = new SqlCommand(update, connection);
                for (int i = 0; i < nr; i++)
                {
                    cmd.Parameters.AddWithValue(paramsNames[i], textBoxes[i].Text);
                }
                cmd.Parameters.AddWithValue("@id", (int)dataGridViewChild.CurrentRow.Cells[0].Value);
                SqlDataAdapter daChild = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                connection.Open();
                daChild.Fill(dataSet);
                connection.Close();
                MessageBox.Show("Data updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                connection.Close();
            }
        }
    }
}
    