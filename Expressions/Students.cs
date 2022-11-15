using Bogus;

namespace Expressions
{
    public class Students
    {
        public static IEnumerable<Student> GetStudents()
        {
            var faker = new Faker<Student>();

            faker.RuleFor(x => x.FullName, x => x.Name.FullName())
                 .RuleFor(x => x.Country, x => x.Address.CountryCode())
                 .RuleFor(x => x.Graduated, x => x.Random.Bool())
                 .RuleFor(x => x.StartedAt, x => x.Date.Past());

            return faker.Generate(1_000_000);
        }
    }
}