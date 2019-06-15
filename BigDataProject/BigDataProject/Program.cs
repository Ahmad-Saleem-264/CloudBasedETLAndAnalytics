using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BigDataProject
{
    class Program
    {
        static void Main(string[] args)
        {
            new ProcessData().TransferData();
        }

        public static void aaa()
        {
            String connectionStringSource = "Data Source=.;Initial Catalog=Testdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            String connectionStringDestination = "Data Source=.;Initial Catalog=TestDB2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            // Create source connection
            SqlConnection source = new SqlConnection(connectionStringSource);
            // Create destination connection
            SqlConnection destination = new SqlConnection(connectionStringDestination);
            // Clean up destination table. Your destination database must have the 
            // table with schema which you are copying data to. 
            // Before executing this code, you must create a table BulkDataTable 
            // in your database where you are trying to copy data to.
            SqlCommand cmd = new SqlCommand();
            // Open source and destination connections.
            source.Open();
            destination.Open();

            // Select data from Products table
            cmd = new SqlCommand("SELECT * FROM [Table_1]", source);
            // Execute reader
            // SqlDataReader reader = cmd.ExecuteReader();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataTable table2 = new DataTable();

            table2.Columns.Add("Id", typeof(int));
            table2.Columns.Add("dataa", typeof(string));




            foreach (DataRow row in table.Rows)
            {

                table2.Rows.Add((int)row["id"], row["column1"]);
                //   Console.WriteLine(row["column1"].ToString());
                // Console.WriteLine(row["id"].ToString());

            }

            foreach (DataRow row in table2.Rows)
            {

                //table2.Rows.Add((int)row["id"], row["column1"]);
                Console.WriteLine(row["id"].ToString());
                Console.WriteLine(row["dataa"].ToString());
            }


            // Create SqlBulkCopy
            SqlBulkCopy bulkData = new SqlBulkCopy(destination);
            // Set destination table name
            bulkData.DestinationTableName = "dbo.Table2";
            // Write data

            bulkData.WriteToServer(table2);
            // Close objects
            bulkData.Close();
            destination.Close();
            source.Close();
        }

    }
}
