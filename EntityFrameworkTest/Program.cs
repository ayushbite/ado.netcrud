using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTest
{
   
    class Program
    {
        static void Main(string[] args)
        {
            Adbconfig entity = new Adbconfig();
            Student sobj = new Student();
            sobj.Studentid = 8080;
            sobj.Firstname ="true";
            sobj.Lastname ="false";
            sobj.studying ="hola";

            entity.students?.Add(sobj);
            entity.SaveChanges();

            Console.WriteLine("working");
        }
    }
}
