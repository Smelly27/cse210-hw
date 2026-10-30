using System;

public class LegendaryArtifact : Artifact
{
    private string _legend;
    private string _associatedCulture;

    public LegendaryArtifact(
        string name,
        string origin,
        string description,
        string legend,
        string associatedCulture)
        : base(name, origin, description)
    {
        _legend = legend;
        _associatedCulture = associatedCulture;
    }

    public string GetLegend()
    {
        return _legend;
    }

    public string GetAssociatedCulture()
    {
        return _associatedCulture;
    }

    public override string GetArtifactType()
    {
        return "Legendary Artifact";
    }

    public override void DisplayArtifact()
    {
        base.DisplayArtifact();

        Console.WriteLine($"Associated Culture: {_associatedCulture}");
        Console.WriteLine($"Legend: {_legend}");
    }
}