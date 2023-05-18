using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DrapperTest
{

    class Student
    {
        public int Studentid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public string Studying { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string constr = @"Server=tcp:ayushlearnserver.database.windows.net,1433;Initial Catalog=ayushlearndb;Persist Security Info=False;User ID=ayush;Password=EFFE@12345;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection sqlconnection = new SqlConnection(constr);
            string sqlcommand = "select * from Student";

            var res = sqlconnection.Query<Student>(sqlcommand);
            foreach (var item in res)
            {
                Console.WriteLine("id is "+ item.Studentid);
                Console.WriteLine("studying is "+item.Studying);

            }
            Console.ReadLine();
        }
    }
}
