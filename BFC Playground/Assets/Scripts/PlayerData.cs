using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    // Matches Stats
    public int totalMatchesInMemory;
    public int totalMistakesInMemory;
    public int totalMemoryRegularEasyWins;
    public int totalMemorySuddenDeathEasyWins;
    public int totalMemorySuddenDeathEasyLosses;
    public int totalMemoryRegularMediumWins;
    public int totalMemorySuddenDeathMediumWins;
    public int totalMemorySuddenDeathMediumLosses;
    public int totalMemoryRegularHardWins;
    public int totalMemorySuddenDeathHardWins;
    public int totalMemorySuddenDeathHardLosses;

    // Higher or Lower Stats
    public int totalMatchesInHigherOrLower;
    public int totalMistakesInHigherOrLower;
    public int totalHigherOrLowerRegularEasyWins;
    public int totalHigherOrLowerRegularEasyLosses;
    public int totalHigherOrLowerSuddenDeathEasyWins;
    public int totalHigherOrLowerSuddenDeathEasyLosses;
    public int totalHigherOrLowerRegularMediumWins;
    public int totalHigherOrLowerRegularMediumLosses;
    public int totalHigherOrLowerSuddenDeathMediumWins;
    public int totalHigherOrLowerSuddenDeathMediumLosses;
    public int totalHigherOrLowerRegularHardWins;
    public int totalHigherOrLowerRegularHardLosses;
    public int totalHigherOrLowerSuddenDeathHardWins;
    public int totalHigherOrLowerSuddenDeathHardLosses;

    // Name Guesser Stats
    public int totalMatchesInNameGuesser;
    public int totalMistakesInNameGuesser;
    public int totalNameGuesserRegularEasyGames;
    public int highestNameGuesserRegularEasyMatchesScore;
    public int highestNameGuesserRegularEasyMistakesScore;
    public int totalNameGuesserSuddenDeathEasyGames;
    public int highestNameGuesserSuddenDeathEasyMatchesScore;
    public int totalNameGuesserRegularMediumGames;
    public int highestNameGuesserRegularMediumMatchesScore;
    public int highestNameGuesserRegularMediumMistakesScore;
    public int totalNameGuesserSuddenDeathMediumGames;
    public int highestNameGuesserSuddenDeathMediumMatchesScore;
    public int totalNameGuesserRegularHardGames;
    public int highestNameGuesserRegularHardMatchesScore;
    public int highestNameGuesserRegularHardMistakesScore;
    public int totalNameGuesserSuddenDeathHardGames;
    public int highestNameGuesserSuddenDeathHardMatchesScore;

    // Profile Picture Guesser Stats
    public int totalMatchesInProPicGuesser;
    public int totalMistakesInProPicGuesser;
    public int totalProPicGuesserRegularEasyGames;
    public int highestProPicGuesserRegularEasyMatchesScore;
    public int highestProPicGuesserRegularEasyMistakesScore;
    public int totalProPicGuesserSuddenDeathEasyGames;
    public int highestProPicGuesserSuddenDeathEasyMatchesScore;
    public int totalProPicGuesserRegularMediumGames;
    public int highestProPicGuesserRegularMediumMatchesScore;
    public int highestProPicGuesserRegularMediumMistakesScore;
    public int totalProPicGuesserSuddenDeathMediumGames;
    public int highestProPicGuesserSuddenDeathMediumMatchesScore;
    public int totalProPicGuesserRegularHardGames;
    public int highestProPicGuesserRegularHardMatchesScore;
    public int highestProPicGuesserRegularHardMistakesScore;
    public int totalProPicGuesserSuddenDeathHardGames;
    public int highestProPicGuesserSuddenDeathHardMatchesScore;

    public PlayerData (Settings settings)
    {
        totalMatchesInMemory = Settings.totalMatchesInMemory;
        totalMistakesInMemory = Settings.totalMistakesInMemory;
        totalMemoryRegularEasyWins = Settings.totalMemoryRegularEasyWins;
        totalMemorySuddenDeathEasyWins = Settings.totalMemorySuddenDeathEasyWins;
        totalMemorySuddenDeathEasyLosses = Settings.totalMemorySuddenDeathEasyLosses;
        totalMemoryRegularMediumWins = Settings.totalMemoryRegularMediumWins;
        totalMemorySuddenDeathMediumWins = Settings.totalMemorySuddenDeathMediumWins;
        totalMemorySuddenDeathMediumLosses = Settings.totalMemorySuddenDeathMediumLosses;
        totalMemoryRegularHardWins = Settings.totalMemoryRegularHardWins;
        totalMemorySuddenDeathHardWins = Settings.totalMemorySuddenDeathHardWins;
        totalMemorySuddenDeathHardLosses = Settings.totalMemorySuddenDeathHardLosses;

        totalMatchesInHigherOrLower = Settings.totalMatchesInHigherOrLower;
        totalMistakesInHigherOrLower = Settings.totalMistakesInHigherOrLower;
        totalHigherOrLowerRegularEasyWins = Settings.totalHigherOrLowerRegularEasyWins;
        totalHigherOrLowerRegularEasyLosses = Settings.totalHigherOrLowerRegularEasyLosses;
        totalHigherOrLowerSuddenDeathEasyWins = Settings.totalHigherOrLowerSuddenDeathEasyWins;
        totalHigherOrLowerSuddenDeathEasyLosses = Settings.totalHigherOrLowerSuddenDeathEasyLosses;
        totalHigherOrLowerRegularMediumWins = Settings.totalHigherOrLowerRegularMediumWins;
        totalHigherOrLowerRegularMediumLosses = Settings.totalHigherOrLowerRegularMediumLosses;
        totalHigherOrLowerSuddenDeathMediumWins = Settings.totalHigherOrLowerSuddenDeathMediumWins;
        totalHigherOrLowerSuddenDeathMediumLosses = Settings.totalHigherOrLowerSuddenDeathMediumLosses;
        totalHigherOrLowerRegularHardWins = Settings.totalHigherOrLowerRegularHardWins;
        totalHigherOrLowerRegularHardLosses = Settings.totalHigherOrLowerRegularHardLosses;
        totalHigherOrLowerSuddenDeathHardWins = Settings.totalHigherOrLowerSuddenDeathHardWins;
        totalHigherOrLowerSuddenDeathHardLosses = Settings.totalHigherOrLowerSuddenDeathHardLosses;

        totalMatchesInNameGuesser = Settings.totalMatchesInNameGuesser;
        totalMistakesInNameGuesser = Settings.totalMistakesInNameGuesser;
        totalNameGuesserRegularEasyGames = Settings.totalNameGuesserRegularEasyGames;
        highestNameGuesserRegularEasyMatchesScore = Settings.highestNameGuesserRegularEasyMatchesScore;
        highestNameGuesserRegularEasyMistakesScore = Settings.highestNameGuesserRegularEasyMistakesScore;
        totalNameGuesserSuddenDeathEasyGames = Settings.totalNameGuesserSuddenDeathEasyGames;
        highestNameGuesserSuddenDeathEasyMatchesScore = Settings.highestNameGuesserSuddenDeathEasyMatchesScore;
        totalNameGuesserRegularMediumGames = Settings.totalNameGuesserRegularMediumGames;
        highestNameGuesserRegularMediumMatchesScore = Settings.highestNameGuesserRegularMediumMatchesScore;
        highestNameGuesserRegularMediumMistakesScore = Settings.highestNameGuesserRegularMediumMistakesScore;
        totalNameGuesserSuddenDeathMediumGames = Settings.totalNameGuesserSuddenDeathMediumGames;
        highestNameGuesserSuddenDeathMediumMatchesScore = Settings.highestNameGuesserSuddenDeathMediumMatchesScore;
        totalNameGuesserRegularHardGames = Settings.totalNameGuesserRegularHardGames;
        highestNameGuesserRegularHardMatchesScore = Settings.highestNameGuesserRegularHardMatchesScore;
        highestNameGuesserRegularHardMistakesScore = Settings.highestNameGuesserRegularHardMistakesScore;
        totalNameGuesserSuddenDeathHardGames = Settings.totalNameGuesserSuddenDeathHardGames;
        highestNameGuesserSuddenDeathHardMatchesScore = Settings.highestNameGuesserSuddenDeathHardMatchesScore;

        totalMatchesInProPicGuesser = Settings.totalMatchesInProPicGuesser;
        totalMistakesInProPicGuesser = Settings.totalMistakesInProPicGuesser;
        totalProPicGuesserRegularEasyGames = Settings.totalProPicGuesserRegularEasyGames;
        highestProPicGuesserRegularEasyMatchesScore = Settings.highestProPicGuesserRegularEasyMatchesScore;
        highestProPicGuesserRegularEasyMistakesScore = Settings.highestProPicGuesserRegularEasyMistakesScore;
        totalProPicGuesserSuddenDeathEasyGames = Settings.totalProPicGuesserSuddenDeathEasyGames;
        highestProPicGuesserSuddenDeathEasyMatchesScore = Settings.highestProPicGuesserSuddenDeathEasyMatchesScore;
        totalProPicGuesserRegularMediumGames = Settings.totalProPicGuesserRegularMediumGames;
        highestProPicGuesserRegularMediumMatchesScore = Settings.highestProPicGuesserRegularMediumMatchesScore;
        highestProPicGuesserRegularMediumMistakesScore = Settings.highestProPicGuesserRegularMediumMistakesScore;
        totalProPicGuesserSuddenDeathMediumGames = Settings.totalProPicGuesserSuddenDeathMediumGames;
        highestProPicGuesserSuddenDeathMediumMatchesScore = Settings.highestProPicGuesserSuddenDeathMediumMatchesScore;
        totalProPicGuesserRegularHardGames = Settings.totalProPicGuesserRegularHardGames;
        highestProPicGuesserRegularHardMatchesScore = Settings.highestProPicGuesserRegularHardMatchesScore;
        highestProPicGuesserRegularHardMistakesScore = Settings.highestProPicGuesserRegularHardMistakesScore;
        totalProPicGuesserSuddenDeathHardGames = Settings.totalProPicGuesserSuddenDeathHardGames;
        highestProPicGuesserSuddenDeathHardMatchesScore = Settings.highestProPicGuesserSuddenDeathHardMatchesScore;
    }
}