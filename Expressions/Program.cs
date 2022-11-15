namespace Expressions
{
    public class Program
    {
        static void Main(string[] args)
        {
            var x = FilteredStudents.FilterStudentsUsingExpressions(Students.GetStudents()).ToList();
        }
    }
}