using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient; 

namespace BulkCopy2
{
    public partial class Form1 : Form
    {
        private string connectionString = "Server=localhost;Integrated Security=True;Database=Northwind";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create source connection
            SqlConnection source = new SqlConnection(connectionString);
            // Create destination connection
            SqlConnection destination = new SqlConnection(connectionString);
           
            SqlCommand cmd = new SqlCommand("DELETE FROM BulkDataTable", destination);
           
            source.Open();
            destination.Open();
            cmd.ExecuteNonQuery();
           
            cmd = new SqlCommand("SELECT * FROM Products", source);
           
            SqlDataReader reader = cmd.ExecuteReader();
            // Create SqlBulkCopy
            SqlBulkCopy bulkData = new SqlBulkCopy(destination);
            // Set destination table name
            bulkData.DestinationTableName = "BulkDataTable";
            // Write data
            bulkData.WriteToServer(reader);
            // Close objects
            bulkData.Close();
            destination.Close();
            source.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}