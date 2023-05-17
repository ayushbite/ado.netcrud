using System;
using System.Data;
using System.Data.SqlClient;

namespace AdoDataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            String SqlQuery = "";
            int id;
            string fn = "";
            string ln = "";
            string studying = "";
            int val;
           
            SqlConnection SqlConnectionObj;

            SqlCommand sqlCommandObj;

            string ConnectionString = @"Server=tcp:ayushlearnserver.database.windows.net,1433;Initial Catalog=ayushlearndb;Persist Security Info=False;User ID=ayush;Password=EFFE@12345;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            SqlConnectionObj = new SqlConnection(ConnectionString);
            SqlConnectionObj.Open();



            void read()
            {
                SqlConnectionObj = new SqlConnection(ConnectionString);
                SqlConnectionObj.Open();
                SqlQuery = @"select * from Student";
                sqlCommandObj = new SqlCommand(SqlQuery, SqlConnectionObj);

                SqlDataReader readerobj = sqlCommandObj.ExecuteReader();
                while (readerobj.Read())
                {
                    Console.Write("student first name is " + readerobj.GetString(1));
                    Console.Write("Student last name is" + readerobj.GetString(2));
                    Console.Write("student studying is " + readerobj.GetString(3));
                    Console.WriteLine(readerobj.GetString(3));
                    Console.WriteLine();
                }
                

            }
            void write(int aid, string firstname, string lastname, string astudying)
            {
                
                SqlQuery = @"insert into Student values(@id,@firstname,@lastname,@studying)";
                sqlCommandObj = new SqlCommand(SqlQuery, SqlConnectionObj);

                sqlCommandObj.Parameters.AddWithValue("@id", aid);
                sqlCommandObj.Parameters.AddWithValue("@firstname", firstname);
                sqlCommandObj.Parameters.AddWithValue("@lastname", lastname);
                sqlCommandObj.Parameters.AddWithValue("@studying", astudying);
                int rowsaffected = sqlCommandObj.ExecuteNonQuery();
                if (rowsaffected > 0)
                {
                    Console.WriteLine("row is inserted you can view now");
                  /*  read();*/
                }
                else
                {
                    Console.WriteLine("try again");
                }
               

            }
         
            void update(int aid, string firstname, string lastname, string astudying)
            {
              
                SqlQuery = @"UPDATE Student 
                SET Firstname = @firstname, Lastname=@lastname , studying =@studying where Studentid = @id";
                sqlCommandObj = new SqlCommand(SqlQuery, SqlConnectionObj);

                sqlCommandObj.Parameters.AddWithValue("@id", aid);

                /*for scalar*/
                /*  sqlCommandObj.Parameters.Add("@aid", SqlDbType.Int);
                  sqlCommandObj.Parameters["@aid"].Value = aid;*/
                sqlCommandObj.Parameters.AddWithValue("@firstname", firstname);
                sqlCommandObj.Parameters.AddWithValue("@lastname", lastname);
                sqlCommandObj.Parameters.AddWithValue("@studying", astudying);
               
                int rowsaffected = sqlCommandObj.ExecuteNonQuery();
                if (rowsaffected > 0)
                {
                    Console.WriteLine("dataupdated");
                  
                }
                else
                {
                    Console.WriteLine("try again");
                }
               



            }
            void delete(int aid)
            {
                SqlConnectionObj = new SqlConnection(ConnectionString);
                SqlConnectionObj.Open();
                SqlQuery = @"delete from Student where Studentid = @id";
                sqlCommandObj = new SqlCommand(SqlQuery, SqlConnectionObj);
                sqlCommandObj.Parameters.AddWithValue("@id", aid);
                int rowsaffected = sqlCommandObj.ExecuteNonQuery();
                if (rowsaffected > 0)
                {
                    Console.WriteLine("data deleted");
                    read();
                }
                else
                {
                    Console.WriteLine("try again");
                }
                SqlConnectionObj.Close();

            }


            while (true)
            {
                Console.WriteLine("enter 1,2,3,4 for read,write,update and delete");
                val = Convert.ToInt32(Console.ReadLine());

                switch (val)
                {
                    case 1:
                        read();
                        break;
                    case 2:
                        Console.WriteLine("enter id");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter firstname");
                        fn = Console.ReadLine();
                        Console.WriteLine("enter lastname");
                        ln = Console.ReadLine();
                        Console.WriteLine("enter studying");
                        studying = Console.ReadLine();
                        write(id, fn, ln, studying);

                        break;
                    case 3:
                        Console.WriteLine("enter id");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter firstname");
                        fn = Console.ReadLine();
                        Console.WriteLine("enter lastname");
                        ln = Console.ReadLine();
                        Console.WriteLine("enter studying");
                        studying = Console.ReadLine();
                        update(id, fn, ln, studying);
                        break;
                    case 4:
                        Console.WriteLine("enter id");
                        id = Convert.ToInt32(Console.ReadLine());
                        delete(id);
                        break;

                }
            }





        }
    }
}
