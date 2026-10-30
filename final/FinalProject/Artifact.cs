using System;

public abstract class Artifact
{
    private string _name;
    private string _origin;
    private string _description;

    public Artifact(string name, string origin, string description)
    {
        _name = name;
        _origin = origin;
        _description = description;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetOrigin()
    {
        return _origin;
    }

    public string GetDescription()
    {
        return _description;
    }

    public abstract string GetArtifactType();

    public virtual void DisplayArtifact()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("           ARTIFACT RESEARCH");
        Console.WriteLine("========================================");
        Console.WriteLine($"Artifact: {_name}");
        Console.WriteLine($"Origin: {_origin}");
        Console.WriteLine($"Description: {_description}");
        Console.WriteLine($"Classification: {GetArtifactType()}");
    }
}