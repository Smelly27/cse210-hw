using System;
using System.Collections.Generic;

public class ScriptureBank
{
    private List<Scripture> _scriptures;
    private Random _random;

    // Constructor creates our scripture collection
    public ScriptureBank()
    {
        _scriptures = new List<Scripture>();
        _random = new Random();

        // Doctrine and Covenants 50:44
        _scriptures.Add(new Scripture(
            new Reference("Doctrine and Covenants", 50, 44),
            "Wherefore, I am in your midst, and I am the good shepherd, and the stone of Israel. He that buildeth upon this rock shall never fall.",
            "Even when you cannot see Him, Christ is near and provides a foundation that will not fail."
        ));

        // Doctrine and Covenants 84:88
        _scriptures.Add(new Scripture(
            new Reference("Doctrine and Covenants", 84, 88),
            "And whoso receiveth you, there I will be also, for I will go before your face. I will be on your right hand and on your left, and my Spirit shall be in your hearts, and mine angels round about you, to bear you up.",
            "You are never truly walking alone."
        ));

        // Doctrine and Covenants 78:18
        _scriptures.Add(new Scripture(
            new Reference("Doctrine and Covenants", 78, 18),
            "And ye cannot bear all things now; nevertheless, be of good cheer, for I will lead you along. The kingdom is yours and the blessings thereof are yours, and the riches of eternity are yours.",
            "You do not need to understand everything to keep moving forward."
        ));

        // Ether 12:4
        _scriptures.Add(new Scripture(
            new Reference("Ether", 12, 4),
            "Wherefore, whoso believeth in God might with surety hope for a better world, yea, even a place at the right hand of God, which hope cometh of faith, maketh an anchor to the souls of men, which would make them sure and steadfast, always abounding in good works, being led to glorify God.",
            "Hope can become an anchor during life's storms."
        ));

        // 2 Nephi 4:34
        _scriptures.Add(new Scripture(
            new Reference("2 Nephi", 4, 34),
            "O Lord, I have trusted in thee, and I will trust in thee forever. I will not put my trust in the arm of flesh; for I know that cursed is he that putteth his trust in the arm of flesh. Yea, cursed is he that putteth his trust in man or maketh flesh his arm.",
            "Where should we place our confidence?"
        ));
    }

    // Select a random scripture from the collection
    public Scripture GetRandomScripture()
    {
        int index = _random.Next(_scriptures.Count);

        return _scriptures[index];
    }
}