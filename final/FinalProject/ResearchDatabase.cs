using System;
using System.Collections.Generic;

public class ResearchDatabase
{
    private List<HistoricalSite> _historicalSites;
    private List<Artifact> _artifacts;

    public ResearchDatabase()
    {
        _historicalSites = new List<HistoricalSite>();
        _artifacts = new List<Artifact>();

        LoadSampleData();
    }

    public void AddHistoricalSite(HistoricalSite site)
    {
        _historicalSites.Add(site);
    }

    public void AddArtifact(Artifact artifact)
    {
        _artifacts.Add(artifact);
    }

    public void DisplayHistoricalSites()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("       HISTORICAL SITE DATABASE");
        Console.WriteLine("========================================");

        if (_historicalSites.Count == 0)
        {
            Console.WriteLine("No historical sites available.");
            return;
        }

        foreach (HistoricalSite site in _historicalSites)
        {
            Console.WriteLine();
            site.DisplaySite();
        }
    }

    public void DisplayArtifacts()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("          ARTIFACT DATABASE");
        Console.WriteLine("========================================");

        if (_artifacts.Count == 0)
        {
            Console.WriteLine("No artifacts available.");
            return;
        }

        foreach (Artifact artifact in _artifacts)
        {
            Console.WriteLine();
            artifact.DisplayArtifact();
        }
    }

    public void SearchHistoricalSite(string name)
    {
        bool found = false;

        foreach (HistoricalSite site in _historicalSites)
        {
            if (site.GetName().Equals(
                name, StringComparison.OrdinalIgnoreCase))
            {
                site.DisplaySite();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Historical site not found.");
        }
    }

    public void SearchArtifact(string name)
    {
        bool found = false;

        foreach (Artifact artifact in _artifacts)
        {
            if (artifact.GetName().Equals(
                name, StringComparison.OrdinalIgnoreCase))
            {
                artifact.DisplayArtifact();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Artifact not found.");
        }
    }

    private void LoadSampleData()
    {
        AddHistoricalSite(new HistoricalSite(
            "Petra",
            "Jordan",
            "Nabataean Kingdom",
            "Ancient and Classical Antiquity",
            "An ancient city famous for its rock-cut architecture and water systems."
        ));

        AddHistoricalSite(new HistoricalSite(
            "Machu Picchu",
            "Peru",
            "Inca Empire",
            "15th Century",
            "An Inca archaeological site located high in the Andes Mountains."
        ));

        AddHistoricalSite(new HistoricalSite(
            "Great Pyramid of Giza",
            "Egypt",
            "Ancient Egyptian Civilization",
            "Old Kingdom",
            "A monumental pyramid constructed during the reign of Pharaoh Khufu."
        ));

        AddArtifact(new HistoricalArtifact(
            "Rosetta Stone",
            "Ancient Egypt",
            "An inscribed stone that helped scholars decipher Egyptian hieroglyphs.",
            "1799",
            "British Museum, London"
        ));

        AddArtifact(new LegendaryArtifact(
            "Holy Grail",
            "Medieval European Traditions",
            "A sacred vessel associated with Christian and Arthurian legends.",
            "A legendary object sought by knights in medieval Grail stories.",
            "Medieval Europe"
        ));

        AddArtifact(new FictionalArtifact(
            "Sankara Stones",
            "Fictional Portrayal of India",
            "Sacred stones featured in Indiana Jones and the Temple of Doom.",
            "Indiana Jones and the Temple of Doom (1984)",
            "Supernatural powers depicted in the film."
        ));
    }
}