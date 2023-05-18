namespace EntityFrameworkTest
{
    internal class Student
    {
        public int Studentid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string studying { get; set; }
        public Student()
        {
            if(Firstname == null)
            {
                Firstname = "";
            }
            if (Lastname == null)
            {
                Lastname = "";
            }
            if (studying == null)
            {
                studying = "";
            }
        }

    }
}