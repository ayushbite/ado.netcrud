using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulkcopyado.net
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dtobj = new DataTable();
            dtobj.Columns.Add("StudentId");
            dtobj.Columns.Add("Firstname");
            dtobj.Columns.Add("LastName");
            dtobj.Columns.Add("studying");


            //adding row items

            dtobj.Rows.Add(500,"Ayush","yadav","btech");
            dtobj.Rows.Add(501, "Ayush", "yadav", "btech");
            dtobj.Rows.Add(502, "Ayush", "yadav", "btech");
            dtobj.Rows.Add(503, "Ayush", "yadav", "btech");
            dtobj.Rows.Add(504, "Ayush", "yadav", "btech");

            //adding connection string
            string connnstr = @"Server=tcp:ayushlearnserver.database.windows.net,1433;Initial Catalog=ayushlearndb;Persist Security Info=False;User ID=ayush;Password=EFFE@12345;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using (SqlConnection sqconnectionobj = new SqlConnection(connnstr))
            {
                sqconnectionobj.Open();
                using (SqlBulkCopy sbcobj = new SqlBulkCopy(sqconnectionobj))
                {
                    sbcobj.DestinationTableName = "Student";

                    //optioanl mapping 
                    /*sbcobj.ColumnMappings.Add("id","Studentid");
                    sbcobj.ColumnMappings.Add("firstname", "Firstname");
                    sbcobj.ColumnMappings.Add("lastname", "LastName");
                    sbcobj.ColumnMappings.Add("studying", "studying");*/

                    sbcobj.WriteToServer(dtobj);
                    Console.WriteLine("written to server");

                }

            }
            Console.ReadLine();

        }
    }
}
