using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigDataProject
{
    class ProcessData
    {


        public void TransferData()
        {



            String connectionStringSource = "Server=tcp:itubigdataproject2.database.windows.net,1433;Initial Catalog=LibrariesAndStack;Persist Security Info=False;User ID=ahmad;Password=HTS@1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=60;";
            //String connectionStringDestination = "Data Source=.;Initial Catalog=TestDB2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            // Create source connection
            SqlConnection source = new SqlConnection(connectionStringSource);
            // Create destination connection
            //SqlConnection destination = new SqlConnection(connectionStringDestination);

            SqlCommand cmd = new SqlCommand();

            source.Open();


            // Select data from Products table
            cmd = new SqlCommand("SELECT distinct(repoid) as repoId FROM [repository_stackSelected]", source);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                Dictionary<DateTime, QuestionUpdateCount> dataDict = new Dictionary<DateTime, QuestionUpdateCount>();
               // Console.WriteLine(row["repoid"].ToString());
                long repoid = (long)row["repoid"];
                String nameQuery = "SELECT top 1 libName FROM [repository_stackSelected] where repoid=" + repoid;
                cmd = new SqlCommand(nameQuery, source);
                var reader = cmd.ExecuteReader();
                reader.Read();
                String libName = reader["libName"].ToString();
               // Console.WriteLine(libName);
                reader.Close();

                String creationDateQuery = "SELECT top 1 GitCreationDate FROM [repository_stackSelected] where repoid=" + repoid;
                cmd = new SqlCommand(creationDateQuery, source);
                reader = cmd.ExecuteReader();
                reader.Read();
                DateTime libCreationDate = DateTime.Parse( reader["GitCreationDate"].ToString());
                // Console.WriteLine(libName);
                reader.Close();



                QuestionUpdateCount questionUpdateCount2 = new QuestionUpdateCount();
                questionUpdateCount2.libName = libName;
                questionUpdateCount2.QuestionCount = 0;
                questionUpdateCount2.repoId = repoid;
                questionUpdateCount2.updateCount = 0;

                dataDict.Add(libCreationDate, questionUpdateCount2);


                String questionCountquery = "select * from repository_stackSelectedCount where libName=@libName";
                cmd = new SqlCommand(questionCountquery, source);

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@libName";
                param.Value = libName;

                // 3. add new parameter to command object
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //Console.WriteLine("{0}, {1}, {2}",
                    //    reader["libName"],
                    //    reader["dayCount"],
                    //     reader["StackQuestionDate"]);
                    
                    DateTime questionDate = DateTime.Parse(reader["StackQuestionDate"].ToString());
                    QuestionUpdateCount questionUpdateCount = new QuestionUpdateCount();
                    questionUpdateCount.libName = reader["libName"].ToString();
                    questionUpdateCount.QuestionCount = (int)reader["dayCount"];
                    questionUpdateCount.repoId = repoid;
                    if(!dataDict.ContainsKey(questionDate))
                    dataDict.Add(questionDate, questionUpdateCount);
                }

                reader.Close();

                string versionsQuery = "select * from version_joinSelectedcount where repoid=" + repoid;
                cmd = new SqlCommand(versionsQuery, source);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //Console.WriteLine("{0}, {1}, {2}",
                    //    reader["versionCreatedDate"],
                    //    reader["totalCount"],
                    //     reader["repoid"]);
                    DateTime updateDate = DateTime.Parse(reader["versionCreatedDate"].ToString());
                    if (dataDict.ContainsKey(updateDate))
                    {
                        QuestionUpdateCount questionUpdateCount = dataDict[updateDate];
                        questionUpdateCount.updateCount = (int)reader["totalCount"];
                    }
                    else
                    {
                        QuestionUpdateCount questionUpdateCount = new QuestionUpdateCount();
                        questionUpdateCount.libName = libName;
                        questionUpdateCount.QuestionCount = 0;
                        questionUpdateCount.repoId = repoid;
                        questionUpdateCount.updateCount = (int)reader["totalCount"];

                        dataDict.Add(updateDate, questionUpdateCount);
                    }

                }


                
                reader.Close();

                DataTable dataTable = new DataTable();

                dataTable.Columns.Add("EventDate", typeof(DateTime));
                dataTable.Columns.Add("libName", typeof(String));
                dataTable.Columns.Add("RepoId", typeof(long));
                dataTable.Columns.Add("QuestionCount", typeof(int));
                dataTable.Columns.Add("updateCount", typeof(int));


                foreach (DateTime date in dataDict.Keys)
                {
                    QuestionUpdateCount count = dataDict[date];
                    dataTable.Rows.Add(date, libName, repoid, count.QuestionCount, count.updateCount);
                }

                foreach (DataRow row1 in dataTable.Rows)
                {
                    //Console.WriteLine(row1["EventDate"]);
                    //Console.WriteLine(row1["libName"]);
                    //Console.WriteLine((long)row1["RepoId"]);
                    //Console.WriteLine(row1["QuestionCount"]);
                    //Console.WriteLine(row1["updateCount"]);

                    Console.WriteLine(row1.Field<DateTime>("Eventdate"));
                    Console.WriteLine(row1.Field<String>("libName"));
                    Console.WriteLine((long)row1.Field<long>("RepoId"));
                    Console.WriteLine(row1.Field<int>("QuestionCount"));
                    Console.WriteLine(row1.Field<int>("updateCount"));

                }

                
                SqlBulkCopy bulkData = new SqlBulkCopy(source);
                
                bulkData.DestinationTableName = "questionUpdateDatesCountSelected";
                // Write data

                bulkData.ColumnMappings.Add("EventDate", "EventDate");
                bulkData.ColumnMappings.Add("libName", "libName");
                bulkData.ColumnMappings.Add("RepoId", "RepoId");
                bulkData.ColumnMappings.Add("QuestionCount", "QuestionCount");
                bulkData.ColumnMappings.Add("updateCount", "updateCount");

                bulkData.WriteToServer(dataTable);
                // Close objects
                bulkData.Close();
                
                


            }
            source.Close();
        }
    }
}
