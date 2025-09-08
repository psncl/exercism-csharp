public class GradeSchool
{
    private readonly Dictionary<string, int> _studentRoster = [];

    public bool Add(string student, int grade) => _studentRoster.TryAdd(student, grade);

    public IEnumerable<string> Roster() =>
        _studentRoster.OrderBy(x => x.Value)
            .ThenBy(x => x.Key)
            .Select(x => x.Key);

    public IEnumerable<string> Grade(int grade) =>
        _studentRoster.Where(x => x.Value == grade)
            .Select(x => x.Key)
            .Order();
}