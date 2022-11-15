using System.Linq.Expressions;

namespace Expressions
{
    public class FilteredStudents
    {
        public static IEnumerable<Student> FilterStudentsAsUsual(IEnumerable<Student> students)
        {
            students = students.Where(student => student.Graduated);
            students = students.Where(student => student.Country == "US");

            return students;
        }

        public static IEnumerable<Student> FilterStudentsUsingExpressions(IEnumerable<Student> students)
        {
            Expression currentExpression;

            var studentParameter = Expression.Parameter(typeof(Student));

            // Graduated
            var graduatedConstant = Expression.Constant(true);
            var studentGraduated = Expression.Property(studentParameter, "Graduated");

            currentExpression = Expression.Equal(studentGraduated, graduatedConstant);

            // Country
            var countryConstant = Expression.Constant("US");
            var studentCountry = Expression.Property(studentParameter, "Country");

            var countryExpression = Expression.Equal(studentCountry, countryConstant);

            currentExpression = Expression.And(currentExpression, countryExpression);

            var expression = Expression.Lambda<Func<Student, bool>>(currentExpression, tailCall: false, new List<ParameterExpression>() { studentParameter });
            var func = expression.Compile();

            return students.Where(func);
        }
    }
}