using System;

public class HistoricalArtifact : Artifact
{
    private string _discoveryDate;
    private string _currentLocation;

    public HistoricalArtifact(
        string name,
        string origin,
        string description,
        string discoveryDate,
        string currentLocation)
        : base(name, origin, description)
    {
        _discoveryDate = discoveryDate;
        _currentLocation = currentLocation;
    }

    public string GetDiscoveryDate()
    {
        return _discoveryDate;
    }

    public string GetCurrentLocation()
    {
        return _currentLocation;
    }

    public override string GetArtifactType()
    {
        return "Historical Artifact";
    }

    public override void DisplayArtifact()
    {
        base.DisplayArtifact();

        Console.WriteLine($"Discovery Date: {_discoveryDate}");
        Console.WriteLine($"Current Location: {_currentLocation}");
    }
}