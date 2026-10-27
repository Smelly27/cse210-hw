public class Assignment
{
    private string _studentName;
    private string _topic;

    // Constructor
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // Returns the student's name and assignment topic
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }

    // Allows derived classes to access the student's name
    public string GetStudentName()
    {
        return _studentName;
    }
}