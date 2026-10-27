public class WritingAssignment : Assignment
{
    private string _title;

    // Constructor
    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    // Returns the writing assignment information
    public string GetWritingInformation()
    {
        return $"{_title} by {GetStudentName()}";
    }
}