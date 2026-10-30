using System;

public class FictionalArtifact : Artifact
{
    private string _fictionalSource;
    private string _fictionalAbilities;

    public FictionalArtifact(
        string name,
        string origin,
        string description,
        string fictionalSource,
        string fictionalAbilities)
        : base(name, origin, description)
    {
        _fictionalSource = fictionalSource;
        _fictionalAbilities = fictionalAbilities;
    }

    public string GetFictionalSource()
    {
        return _fictionalSource;
    }

    public string GetFictionalAbilities()
    {
        return _fictionalAbilities;
    }

    public override string GetArtifactType()
    {
        return "Fictional Artifact";
    }

    public override void DisplayArtifact()
    {
        base.DisplayArtifact();

        Console.WriteLine($"Fictional Source: {_fictionalSource}");
        Console.WriteLine($"Fictional Abilities: {_fictionalAbilities}");
    }
}