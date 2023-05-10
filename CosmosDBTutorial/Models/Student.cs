namespace University.Models;

public class Student
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Gender { get; set; }
    public string? Major { get; set; }
    public double? GPA { get; set; }
    public List<string>? ExtracurricularActivities {get; set;}

}
