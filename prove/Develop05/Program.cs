using System;

// Exceeding Requirements:
// I added an XP leveling system to make completing goals more rewarding.
// Players start as Beginners and earn new ranks as they gain XP.
// The program also announces when the player reaches a new rank.
// Completed simple and checklist goals cannot award points again.

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}