using System;

public class Explorer
{
    private string _name;
    private string _specialty;
    private int _experienceLevel;

    // Constructor for creating a new explorer
    public Explorer(string name, string specialty)
    {
        _name = name;
        _specialty = specialty;
        _experienceLevel = 1;
    }

    // Constructor for restoring a saved explorer
    public Explorer(string name, string specialty, int experienceLevel)
    {
        _name = name;
        _specialty = specialty;
        _experienceLevel = Math.Max(1, experienceLevel);
    }

    public string GetName()
    {
        return _name;
    }

    public string GetSpecialty()
    {
        return _specialty;
    }

    public int GetExperienceLevel()
    {
        return _experienceLevel;
    }

    public void GainExperience()
    {
        _experienceLevel++;
    }

    public void DisplayProfile()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("             EXPLORER PROFILE");
        Console.WriteLine("========================================");
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine($"Specialty: {_specialty}");
        Console.WriteLine($"Experience Level: {_experienceLevel}");
    }
}