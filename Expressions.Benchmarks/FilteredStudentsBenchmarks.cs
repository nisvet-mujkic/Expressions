using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Mathematics;
using BenchmarkDotNet.Order;

namespace Expressions.Benchmarks
{
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn(NumeralSystem.Arabic)]
    public class FilteredStudentsBenchmarks
    {
        private IEnumerable<Student> _students;

        [GlobalSetup]
        public void Setup()
        {
            _students = Students.GetStudents();
        }

        [Benchmark]
        public void FilterStudentsAsUsual()
        {
            var students = FilteredStudents.FilterStudentsAsUsual(_students);
        }

        [Benchmark]
        public void FilterStudentsUsingExpressions()
        {
            var students = FilteredStudents.FilterStudentsUsingExpressions(_students);
        }
    }
}