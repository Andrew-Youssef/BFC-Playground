using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statistics : MonoBehaviour
{
    public GameObject settingsObject;

    public Text totalMatchesInMemoryText;
    public Text totalMistakesInMemoryText;
    public Text totalMemoryRegularEasyWins;
    public Text totalMemoryRegularMediumWins;
    public Text totalMemoryRegularHardWins;
    public Text totalMemorySuddenDeathEasyWins;
    public Text totalMemorySuddenDeathMediumWins;
    public Text totalMemorySuddenDeathHardWins;
    public Text totalMemorySuddenDeathEasyLosses;
    public Text totalMemorySuddenDeathMediumLosses;
    public Text totalMemorySuddenDeathHardLosses;

    public Text totalMatchesInHigherOrLowerText;
    public Text totalMistakesInHigherOrLowerText;
    public Text totalHigherOrLowerRegularEasyWins;
    public Text totalHigherOrLowerRegularMediumWins;
    public Text totalHigherOrLowerRegularHardWins;
    public Text totalHigherOrLowerRegularEasyLosses;
    public Text totalHigherOrLowerRegularMediumLosses;
    public Text totalHigherOrLowerRegularHardLosses;
    public Text totalHigherOrLowerSuddenDeathEasyWins;
    public Text totalHigherOrLowerSuddenDeathMediumWins;
    public Text totalHigherOrLowerSuddenDeathHardWins;
    public Text totalHigherOrLowerSuddenDeathEasyLosses;
    public Text totalHigherOrLowerSuddenDeathMediumLosses;
    public Text totalHigherOrLowerSuddenDeathHardLosses;

    public Text totalMatchesInNameGuesserText;
    public Text totalMistakesInNameGuesserText;
    public Text totalNameGuesserRegularEasyGames;
    public Text highestNameGuesserRegularEasyMatchesScore;
    public Text highestNameGuesserRegularEasyMistakesScore;
    public Text totalNameGuesserSuddenDeathEasyGames;
    public Text highestNameGuesserSuddenDeathEasyMatchesScore;
    public Text totalNameGuesserRegularMediumGames;
    public Text highestNameGuesserRegularMediumMatchesScore;
    public Text highestNameGuesserRegularMediumMistakesScore;
    public Text totalNameGuesserSuddenDeathMediumGames;
    public Text highestNameGuesserSuddenDeathMediumMatchesScore;
    public Text totalNameGuesserRegularHardGames;
    public Text highestNameGuesserRegularHardMatchesScore;
    public Text highestNameGuesserRegularHardMistakesScore;
    public Text totalNameGuesserSuddenDeathHardGames;
    public Text highestNameGuesserSuddenDeathHardMatchesScore;

    public Text totalMatchesInProPicGuesserText;
    public Text totalMistakesInProPicGuesserText;
    public Text totalProPicGuesserRegularEasyGames;
    public Text highestProPicGuesserRegularEasyMatchesScore;
    public Text highestProPicGuesserRegularEasyMistakesScore;
    public Text totalProPicGuesserSuddenDeathEasyGames;
    public Text highestProPicGuesserSuddenDeathEasyMatchesScore;
    public Text totalProPicGuesserRegularMediumGames;
    public Text highestProPicGuesserRegularMediumMatchesScore;
    public Text highestProPicGuesserRegularMediumMistakesScore;
    public Text totalProPicGuesserSuddenDeathMediumGames;
    public Text highestProPicGuesserSuddenDeathMediumMatchesScore;
    public Text totalProPicGuesserRegularHardGames;
    public Text highestProPicGuesserRegularHardMatchesScore;
    public Text highestProPicGuesserRegularHardMistakesScore;
    public Text totalProPicGuesserSuddenDeathHardGames;
    public Text highestProPicGuesserSuddenDeathHardMatchesScore;

    private void Start()
    {
        settingsObject.GetComponent<Settings>().LoadPlayer();

        // Load in Memory Stats
        totalMatchesInMemoryText.text = "Total Matches: " + Settings.totalMatchesInMemory.ToString();
        totalMistakesInMemoryText.text = "Total Mistakes: " + Settings.totalMistakesInMemory.ToString();
        totalMemoryRegularEasyWins.text = "Total Regular Easy Wins: " + Settings.totalMemoryRegularEasyWins.ToString();
        totalMemoryRegularMediumWins.text = "Total Regular Medium Wins: " + Settings.totalMemoryRegularMediumWins.ToString();
        totalMemoryRegularHardWins.text = "Total Regular Hard Wins: " + Settings.totalMemoryRegularHardWins.ToString();
        totalMemorySuddenDeathEasyWins.text = "Total Sudden Death Easy Wins: " + Settings.totalMemorySuddenDeathEasyWins.ToString();
        totalMemorySuddenDeathMediumWins.text = "Total Sudden Death Medium Wins: " + Settings.totalMemorySuddenDeathMediumWins.ToString();
        totalMemorySuddenDeathHardWins.text = "Total Sudden Death Hard Wins: " + Settings.totalMemorySuddenDeathHardWins.ToString();
        totalMemorySuddenDeathEasyLosses.text = "Total Sudden Death Easy Losses: " + Settings.totalMemorySuddenDeathEasyLosses.ToString();
        totalMemorySuddenDeathMediumLosses.text = "Total Sudden Death Medium Losses: " + Settings.totalMemorySuddenDeathMediumLosses.ToString();
        totalMemorySuddenDeathHardLosses.text = "Total Sudden Death Hard Losses: " + Settings.totalMemorySuddenDeathHardLosses.ToString();

        // Load in Higher Or Lower Stats
        totalMatchesInHigherOrLowerText.text = "Total Matches: " + Settings.totalMatchesInHigherOrLower.ToString();
        totalMistakesInHigherOrLowerText.text = "Total Mistakes: " + Settings.totalMistakesInHigherOrLower.ToString();
        totalHigherOrLowerRegularEasyWins.text = "Total Regular Easy Wins: " + Settings.totalHigherOrLowerRegularEasyWins.ToString();
        totalHigherOrLowerRegularMediumWins.text = "Total Regular Medium Wins: " + Settings.totalHigherOrLowerRegularMediumWins.ToString();
        totalHigherOrLowerRegularHardWins.text = "Total Regular Hard Wins: " + Settings.totalHigherOrLowerRegularHardWins.ToString();
        totalHigherOrLowerRegularEasyLosses.text = "Total Regular Easy Losses: " + Settings.totalHigherOrLowerRegularEasyLosses.ToString();
        totalHigherOrLowerRegularMediumLosses.text = "Total Regular Medium Losses: " + Settings.totalHigherOrLowerRegularMediumLosses.ToString();
        totalHigherOrLowerRegularHardLosses.text = "Total Regular Hard Losses: " + Settings.totalHigherOrLowerRegularHardLosses.ToString();
        totalHigherOrLowerSuddenDeathEasyWins.text = "Total Sudden Death Easy Wins: " + Settings.totalHigherOrLowerSuddenDeathEasyWins.ToString();
        totalHigherOrLowerSuddenDeathMediumWins.text = "Total Sudden Death Medium Wins: " + Settings.totalHigherOrLowerSuddenDeathMediumWins.ToString();
        totalHigherOrLowerSuddenDeathHardWins.text = "Total Sudden Death Hard Wins: " + Settings.totalHigherOrLowerSuddenDeathHardWins.ToString();
        totalHigherOrLowerSuddenDeathEasyLosses.text = "Total Sudden Death Easy Losses: " + Settings.totalHigherOrLowerSuddenDeathEasyLosses.ToString();
        totalHigherOrLowerSuddenDeathMediumLosses.text = "Total Sudden Death Medium Losses: " + Settings.totalHigherOrLowerSuddenDeathMediumLosses.ToString();
        totalHigherOrLowerSuddenDeathHardLosses.text = "Total Sudden Death Hard Losses: " + Settings.totalHigherOrLowerSuddenDeathHardLosses.ToString();

        // Load in Name Guesser Stats
        totalMatchesInNameGuesserText.text = "Total Matches: " + Settings.totalMatchesInNameGuesser.ToString();
        totalMistakesInNameGuesserText.text = "Total Mistakes: " + Settings.totalMistakesInNameGuesser.ToString();
        totalNameGuesserRegularEasyGames.text = "Total Regular Easy Games: " + Settings.totalNameGuesserRegularEasyGames.ToString();
        highestNameGuesserRegularEasyMatchesScore.text = "Mat. : " + Settings.highestNameGuesserRegularEasyMatchesScore.ToString();
        highestNameGuesserRegularEasyMistakesScore.text = "Mis. : " + Settings.highestNameGuesserRegularEasyMistakesScore.ToString();
        totalNameGuesserSuddenDeathEasyGames.text = "Total Sudden Death Easy Games: " + Settings.totalNameGuesserSuddenDeathEasyGames.ToString();
        highestNameGuesserSuddenDeathEasyMatchesScore.text = "Matches : " + Settings.highestNameGuesserSuddenDeathEasyMatchesScore.ToString();
        totalNameGuesserRegularMediumGames.text = "Total Regular Medium Games: " + Settings.totalNameGuesserRegularMediumGames.ToString();
        highestNameGuesserRegularMediumMatchesScore.text = "Mat. : " + Settings.highestNameGuesserRegularMediumMatchesScore.ToString();
        highestNameGuesserRegularMediumMistakesScore.text = "Mis. : " + Settings.highestNameGuesserRegularMediumMistakesScore.ToString();
        totalNameGuesserSuddenDeathMediumGames.text = "Total Sudden Death Medium Games: " + Settings.totalNameGuesserSuddenDeathMediumGames.ToString();
        highestNameGuesserSuddenDeathMediumMatchesScore.text = "Matches : " + Settings.highestNameGuesserSuddenDeathMediumMatchesScore.ToString();
        totalNameGuesserRegularHardGames.text = "Total Regular Hard Games: " + Settings.totalNameGuesserRegularHardGames.ToString();
        highestNameGuesserRegularHardMatchesScore.text = "Mat. : " + Settings.highestNameGuesserRegularHardMatchesScore.ToString();
        highestNameGuesserRegularHardMistakesScore.text = "Mis. : " + Settings.highestNameGuesserRegularHardMistakesScore.ToString();
        totalNameGuesserSuddenDeathHardGames.text = "Total Sudden Death Hard Games: " + Settings.totalNameGuesserSuddenDeathHardGames.ToString();
        highestNameGuesserSuddenDeathHardMatchesScore.text = "Matches : " + Settings.highestNameGuesserSuddenDeathHardMatchesScore.ToString();

        // Load in Profile Picture Guesser Stats
        totalMatchesInProPicGuesserText.text = "Total Matches: " + Settings.totalMatchesInProPicGuesser.ToString();
        totalMistakesInProPicGuesserText.text = "Total Mistakes: " + Settings.totalMistakesInProPicGuesser.ToString();
        totalProPicGuesserRegularEasyGames.text = "Total Regular Easy Games: " + Settings.totalProPicGuesserRegularEasyGames.ToString();
        highestProPicGuesserRegularEasyMatchesScore.text = "Mat. : " + Settings.highestProPicGuesserRegularEasyMatchesScore.ToString();
        highestProPicGuesserRegularEasyMistakesScore.text = "Mis. : " + Settings.highestProPicGuesserRegularEasyMistakesScore.ToString();
        totalProPicGuesserSuddenDeathEasyGames.text = "Total Sudden Death Easy Games: " + Settings.totalProPicGuesserSuddenDeathEasyGames.ToString();
        highestProPicGuesserSuddenDeathEasyMatchesScore.text = "Matches : " + Settings.highestProPicGuesserSuddenDeathEasyMatchesScore.ToString();
        totalProPicGuesserRegularMediumGames.text = "Total Regular Medium Games: " + Settings.totalProPicGuesserRegularMediumGames.ToString();
        highestProPicGuesserRegularMediumMatchesScore.text = "Mat. : " + Settings.highestProPicGuesserRegularMediumMatchesScore.ToString();
        highestProPicGuesserRegularMediumMistakesScore.text = "Mis. : " + Settings.highestProPicGuesserRegularMediumMistakesScore.ToString();
        totalProPicGuesserSuddenDeathMediumGames.text = "Total Sudden Death Medium Games: " + Settings.totalProPicGuesserSuddenDeathMediumGames.ToString();
        highestProPicGuesserSuddenDeathMediumMatchesScore.text = "Matches : " + Settings.highestProPicGuesserSuddenDeathMediumMatchesScore.ToString();
        totalProPicGuesserRegularHardGames.text = "Total Regular Hard Games: " + Settings.totalProPicGuesserRegularHardGames.ToString();
        highestProPicGuesserRegularHardMatchesScore.text = "Mat. : " + Settings.highestProPicGuesserRegularHardMatchesScore.ToString();
        highestProPicGuesserRegularHardMistakesScore.text = "Mis. : " + Settings.highestProPicGuesserRegularHardMistakesScore.ToString();
        totalProPicGuesserSuddenDeathHardGames.text = "Total Sudden Death Hard Games: " + Settings.totalProPicGuesserSuddenDeathHardGames.ToString();
        highestProPicGuesserSuddenDeathHardMatchesScore.text = "Matches : " + Settings.highestProPicGuesserSuddenDeathHardMatchesScore.ToString();
    }

    public void ResetStats()
    {
        // Memory Game
        Settings.totalMatchesInMemory = 0;
        Settings.totalMistakesInMemory = 0;
        Settings.totalMemoryRegularEasyWins = 0;
        Settings.totalMemorySuddenDeathEasyWins = 0;
        Settings.totalMemorySuddenDeathEasyLosses = 0;
        Settings.totalMemoryRegularMediumWins = 0;
        Settings.totalMemorySuddenDeathMediumWins = 0;
        Settings.totalMemorySuddenDeathMediumLosses = 0;
        Settings.totalMemoryRegularHardWins = 0;
        Settings.totalMemorySuddenDeathHardWins = 0;
        Settings.totalMemorySuddenDeathHardLosses = 0;
        
        // Higher or Lower
        Settings.totalMatchesInHigherOrLower = 0;
        Settings.totalMistakesInHigherOrLower = 0;
        Settings.totalHigherOrLowerRegularEasyWins = 0;
        Settings.totalHigherOrLowerSuddenDeathEasyWins = 0;
        Settings.totalHigherOrLowerSuddenDeathEasyLosses = 0;
        Settings.totalHigherOrLowerRegularMediumWins = 0;
        Settings.totalHigherOrLowerSuddenDeathMediumWins = 0;
        Settings.totalHigherOrLowerSuddenDeathMediumLosses = 0;
        Settings.totalHigherOrLowerRegularHardWins = 0;
        Settings.totalHigherOrLowerSuddenDeathHardWins = 0;
        Settings.totalHigherOrLowerSuddenDeathHardLosses = 0;

        // Name Guesser Stats
        Settings.totalMatchesInNameGuesser = 0;
        Settings.totalMistakesInNameGuesser = 0;
        Settings.totalNameGuesserRegularEasyGames = 0;
        Settings.highestNameGuesserRegularEasyMatchesScore = 0;
        Settings.highestNameGuesserRegularEasyMistakesScore = 0;
        Settings.totalNameGuesserSuddenDeathEasyGames = 0;
        Settings.highestNameGuesserSuddenDeathEasyMatchesScore = 0;
        Settings.totalNameGuesserRegularMediumGames = 0;
        Settings.highestNameGuesserRegularMediumMatchesScore = 0;
        Settings.highestNameGuesserRegularMediumMistakesScore = 0;
        Settings.totalNameGuesserSuddenDeathMediumGames = 0;
        Settings.highestNameGuesserSuddenDeathMediumMatchesScore = 0;
        Settings.totalNameGuesserRegularHardGames = 0;
        Settings.highestNameGuesserRegularHardMatchesScore = 0;
        Settings.highestNameGuesserRegularHardMistakesScore = 0;
        Settings.totalNameGuesserSuddenDeathHardGames = 0;
        Settings.highestNameGuesserSuddenDeathHardMatchesScore = 0;

        // Profile Picture Guesser Stats
        Settings.totalMatchesInProPicGuesser = 0;
        Settings.totalMistakesInProPicGuesser = 0;
        Settings.totalProPicGuesserRegularEasyGames = 0;
        Settings.highestProPicGuesserRegularEasyMatchesScore = 0;
        Settings.highestProPicGuesserRegularEasyMistakesScore = 0;
        Settings.totalProPicGuesserSuddenDeathEasyGames = 0;
        Settings.highestProPicGuesserSuddenDeathEasyMatchesScore = 0;
        Settings.totalProPicGuesserRegularMediumGames = 0;
        Settings.highestProPicGuesserRegularMediumMatchesScore = 0;
        Settings.highestProPicGuesserRegularMediumMistakesScore = 0;
        Settings.totalProPicGuesserSuddenDeathMediumGames = 0;
        Settings.highestProPicGuesserSuddenDeathMediumMatchesScore = 0;
        Settings.totalProPicGuesserRegularHardGames = 0;
        Settings.highestProPicGuesserRegularHardMatchesScore = 0;
        Settings.highestProPicGuesserRegularHardMistakesScore = 0;
        Settings.totalProPicGuesserSuddenDeathHardGames = 0;
        Settings.highestProPicGuesserSuddenDeathHardMatchesScore = 0;

        settingsObject.GetComponent<Settings>().SavePlayer();
    }
}