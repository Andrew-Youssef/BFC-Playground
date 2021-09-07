using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{

    public static int colourChosen;
    public static int volume;
    public static bool lockedScroll;

    public GameObject pinkBackground;
    public GameObject blueBackground;
    public GameObject greenBackground;
    public GameObject instructions;

    public Text lockScrollText;

    public static bool instructionsShownM;
    public static bool instructionsShownHOrL;
    public static bool instructionsShownNG;
    public static bool instructionsShownPPG;

    public static bool suddenDeath;

    // Matches Stats
    public static int totalMatchesInMemory;
    public static int totalMistakesInMemory;
    public static int totalMemoryRegularEasyWins;
    public static int totalMemorySuddenDeathEasyWins;
    public static int totalMemorySuddenDeathEasyLosses;
    public static int totalMemoryRegularMediumWins;
    public static int totalMemorySuddenDeathMediumWins;
    public static int totalMemorySuddenDeathMediumLosses;
    public static int totalMemoryRegularHardWins;
    public static int totalMemorySuddenDeathHardWins;
    public static int totalMemorySuddenDeathHardLosses;

    // Higher or Lower Stats
    public static int totalMatchesInHigherOrLower;
    public static int totalMistakesInHigherOrLower;
    public static int totalHigherOrLowerRegularEasyWins;
    public static int totalHigherOrLowerRegularEasyLosses;
    public static int totalHigherOrLowerSuddenDeathEasyWins;
    public static int totalHigherOrLowerSuddenDeathEasyLosses;
    public static int totalHigherOrLowerRegularMediumWins;
    public static int totalHigherOrLowerRegularMediumLosses;
    public static int totalHigherOrLowerSuddenDeathMediumWins;
    public static int totalHigherOrLowerSuddenDeathMediumLosses;
    public static int totalHigherOrLowerRegularHardWins;
    public static int totalHigherOrLowerRegularHardLosses;
    public static int totalHigherOrLowerSuddenDeathHardWins;
    public static int totalHigherOrLowerSuddenDeathHardLosses;

    // Name Guesser Stats
    public static int totalMatchesInNameGuesser;
    public static int totalMistakesInNameGuesser;
    public static int totalNameGuesserRegularEasyGames;
    public static int highestNameGuesserRegularEasyMatchesScore;
    public static int highestNameGuesserRegularEasyMistakesScore;
    public static int totalNameGuesserSuddenDeathEasyGames;
    public static int highestNameGuesserSuddenDeathEasyMatchesScore;
    public static int totalNameGuesserRegularMediumGames;
    public static int highestNameGuesserRegularMediumMatchesScore;
    public static int highestNameGuesserRegularMediumMistakesScore;
    public static int totalNameGuesserSuddenDeathMediumGames;
    public static int highestNameGuesserSuddenDeathMediumMatchesScore;
    public static int totalNameGuesserRegularHardGames;
    public static int highestNameGuesserRegularHardMatchesScore;
    public static int highestNameGuesserRegularHardMistakesScore;
    public static int totalNameGuesserSuddenDeathHardGames;
    public static int highestNameGuesserSuddenDeathHardMatchesScore;

    // Profile Picture Guesser Stats
    public static int totalMatchesInProPicGuesser;
    public static int totalMistakesInProPicGuesser;
    public static int totalProPicGuesserRegularEasyGames;
    public static int highestProPicGuesserRegularEasyMatchesScore;
    public static int highestProPicGuesserRegularEasyMistakesScore;
    public static int totalProPicGuesserSuddenDeathEasyGames;
    public static int highestProPicGuesserSuddenDeathEasyMatchesScore;
    public static int totalProPicGuesserRegularMediumGames;
    public static int highestProPicGuesserRegularMediumMatchesScore;
    public static int highestProPicGuesserRegularMediumMistakesScore;
    public static int totalProPicGuesserSuddenDeathMediumGames;
    public static int highestProPicGuesserSuddenDeathMediumMatchesScore;
    public static int totalProPicGuesserRegularHardGames;
    public static int highestProPicGuesserRegularHardMatchesScore;
    public static int highestProPicGuesserRegularHardMistakesScore;
    public static int totalProPicGuesserSuddenDeathHardGames;
    public static int highestProPicGuesserSuddenDeathHardMatchesScore;

    // Start is called before the first frame update
    public void Start()
    {
        if (lockedScroll == false)
        {
            pinkBackground.GetComponent<Animator>().enabled = true;
            blueBackground.GetComponent<Animator>().enabled = true;
            greenBackground.GetComponent<Animator>().enabled = true;
            lockScrollText.text = "";
        }
        else
        {
            pinkBackground.GetComponent<Animator>().enabled = false;
            blueBackground.GetComponent<Animator>().enabled = false;
            greenBackground.GetComponent<Animator>().enabled = false;
            lockScrollText.text = "X";
        }

        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + scene.name + "'.");

        if (scene.name == "MemoryGame")
        {
            if (instructionsShownM == false)
            {
                instructions.SetActive(true);
                instructionsShownM = true;
            }
        }
        else if(scene.name == "HigherOrLower")
        {
            if (instructionsShownHOrL == false)
            {
                instructions.SetActive(true);
                instructionsShownHOrL = true;
            }
        }
        else if (scene.name == "ProfilePicGuesser")
        {
            if (instructionsShownPPG == false)
            {
                instructions.SetActive(true);
                instructionsShownPPG = true;
            }
        }
        else if (scene.name == "NameGuesser")
        {
            if (instructionsShownNG == false)
            {
                instructions.SetActive(true);
                instructionsShownNG = true;
            }
        }
    }

    public void ChangeFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void LockScroll()
    {
        if (lockScrollText.text == "")
        {
            pinkBackground.GetComponent<Animator>().enabled = false;
            blueBackground.GetComponent<Animator>().enabled = false;
            greenBackground.GetComponent<Animator>().enabled = false;
            lockScrollText.text = "X";
            lockedScroll = true;
        }
        else
        {
            pinkBackground.GetComponent<Animator>().enabled = true;
            blueBackground.GetComponent<Animator>().enabled = true;
            greenBackground.GetComponent<Animator>().enabled = true;
            lockScrollText.text = "";
            lockedScroll = false;
        }
    }

    public void ShowInstructions()
    {
        instructions.SetActive(true);
    }

    public void SuddenDeathEnabled()
    {
        suddenDeath = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
        Debug.Log("saved");
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        totalMatchesInMemory = data.totalMatchesInMemory;
        totalMistakesInMemory = data.totalMistakesInMemory;
        totalMemoryRegularEasyWins = data.totalMemoryRegularEasyWins;
        totalMemorySuddenDeathEasyWins = data.totalMemorySuddenDeathEasyWins;
        totalMemorySuddenDeathEasyLosses = data.totalMemorySuddenDeathEasyLosses;
        totalMemoryRegularMediumWins = data.totalMemoryRegularMediumWins;
        totalMemorySuddenDeathMediumWins = data.totalMemorySuddenDeathMediumWins;
        totalMemorySuddenDeathMediumLosses = data.totalMemorySuddenDeathMediumLosses;
        totalMemoryRegularHardWins = data.totalMemoryRegularHardWins;
        totalMemorySuddenDeathHardWins = data.totalMemorySuddenDeathHardWins;
        totalMemorySuddenDeathHardLosses = data.totalMemorySuddenDeathHardLosses;

        totalMatchesInHigherOrLower = data.totalMatchesInHigherOrLower;
        totalMistakesInHigherOrLower = data.totalMistakesInHigherOrLower;
        totalHigherOrLowerRegularEasyWins = data.totalHigherOrLowerRegularEasyWins;
        totalHigherOrLowerRegularEasyLosses = data.totalHigherOrLowerRegularEasyLosses;
        totalHigherOrLowerSuddenDeathEasyWins = data.totalHigherOrLowerSuddenDeathEasyWins;
        totalHigherOrLowerSuddenDeathEasyLosses = data.totalHigherOrLowerSuddenDeathEasyLosses;
        totalHigherOrLowerRegularMediumWins = data.totalHigherOrLowerRegularMediumWins;
        totalHigherOrLowerRegularMediumLosses = data.totalHigherOrLowerRegularMediumLosses;
        totalHigherOrLowerSuddenDeathMediumWins = data.totalHigherOrLowerSuddenDeathMediumWins;
        totalHigherOrLowerSuddenDeathMediumLosses = data.totalHigherOrLowerSuddenDeathMediumLosses;
        totalHigherOrLowerRegularHardWins = data.totalHigherOrLowerRegularHardWins;
        totalHigherOrLowerRegularHardLosses = data.totalHigherOrLowerRegularHardLosses;
        totalHigherOrLowerSuddenDeathHardWins = data.totalHigherOrLowerSuddenDeathHardWins;
        totalHigherOrLowerSuddenDeathHardLosses = data.totalHigherOrLowerSuddenDeathHardLosses;

        totalMatchesInNameGuesser = data.totalMatchesInNameGuesser;
        totalMistakesInNameGuesser = data.totalMistakesInNameGuesser;
        totalNameGuesserRegularEasyGames = data.totalNameGuesserRegularEasyGames;
        highestNameGuesserRegularEasyMatchesScore = data.highestNameGuesserRegularEasyMatchesScore;
        highestNameGuesserRegularEasyMistakesScore = data.highestNameGuesserRegularEasyMistakesScore;
        totalNameGuesserSuddenDeathEasyGames = data.totalNameGuesserSuddenDeathEasyGames;
        highestNameGuesserSuddenDeathEasyMatchesScore = data.highestNameGuesserSuddenDeathEasyMatchesScore;
        totalNameGuesserRegularMediumGames = data.totalNameGuesserRegularMediumGames;
        highestNameGuesserRegularMediumMatchesScore = data.highestNameGuesserRegularMediumMatchesScore;
        highestNameGuesserRegularMediumMistakesScore = data.highestNameGuesserRegularMediumMistakesScore;
        totalNameGuesserSuddenDeathMediumGames = data.totalNameGuesserSuddenDeathMediumGames;
        highestNameGuesserSuddenDeathMediumMatchesScore = data.highestNameGuesserSuddenDeathMediumMatchesScore;
        totalNameGuesserRegularHardGames = data.totalNameGuesserRegularHardGames;
        highestNameGuesserRegularHardMatchesScore = data.highestNameGuesserRegularHardMatchesScore;
        highestNameGuesserRegularHardMistakesScore = data.highestNameGuesserRegularHardMistakesScore;
        totalNameGuesserSuddenDeathHardGames = data.totalNameGuesserSuddenDeathHardGames;
        highestNameGuesserSuddenDeathHardMatchesScore = data.highestNameGuesserSuddenDeathHardMatchesScore;

        totalMatchesInProPicGuesser = data.totalMatchesInProPicGuesser;
        totalMistakesInProPicGuesser = data.totalMistakesInProPicGuesser;
        totalProPicGuesserRegularEasyGames = data.totalProPicGuesserRegularEasyGames;
        highestProPicGuesserRegularEasyMatchesScore = data.highestProPicGuesserRegularEasyMatchesScore;
        highestProPicGuesserRegularEasyMistakesScore = data.highestProPicGuesserRegularEasyMistakesScore;
        totalProPicGuesserSuddenDeathEasyGames = data.totalProPicGuesserSuddenDeathEasyGames;
        highestProPicGuesserSuddenDeathEasyMatchesScore = data.highestProPicGuesserSuddenDeathEasyMatchesScore;
        totalProPicGuesserRegularMediumGames = data.totalProPicGuesserRegularMediumGames;
        highestProPicGuesserRegularMediumMatchesScore = data.highestProPicGuesserRegularMediumMatchesScore;
        highestProPicGuesserRegularMediumMistakesScore = data.highestProPicGuesserRegularMediumMistakesScore;
        totalProPicGuesserSuddenDeathMediumGames = data.totalProPicGuesserSuddenDeathMediumGames;
        highestProPicGuesserSuddenDeathMediumMatchesScore = data.highestProPicGuesserSuddenDeathMediumMatchesScore;
        totalProPicGuesserRegularHardGames = data.totalProPicGuesserRegularHardGames;
        highestProPicGuesserRegularHardMatchesScore = data.highestProPicGuesserRegularHardMatchesScore;
        highestProPicGuesserRegularHardMistakesScore = data.highestProPicGuesserRegularHardMistakesScore;
        totalProPicGuesserSuddenDeathHardGames = data.totalProPicGuesserSuddenDeathHardGames;
        highestProPicGuesserSuddenDeathHardMatchesScore = data.highestProPicGuesserSuddenDeathHardMatchesScore;
    }

    //Throwaway Function
    private void Throwaway()
    {
        // In the start method

        if (colourChosen == 1)
        {
            pinkBackground.SetActive(true);
            blueBackground.SetActive(false);
            greenBackground.SetActive(false);
        }
        else if (colourChosen == 2)
        {
            pinkBackground.SetActive(false);
            blueBackground.SetActive(true);
            greenBackground.SetActive(false);
        }
        else if (colourChosen == 3)
        {
            pinkBackground.SetActive(false);
            blueBackground.SetActive(false);
            greenBackground.SetActive(true);
        }

        // In "SetColourToPink" void
        pinkBackground.SetActive(true);
        blueBackground.SetActive(false);
        greenBackground.SetActive(false);

        colourChosen = 1;

        // In "SetColourToBlue" public void
        pinkBackground.SetActive(false);
        blueBackground.SetActive(true);
        greenBackground.SetActive(false);

        colourChosen = 2;

        // In "SetColourToGreen" public void
        pinkBackground.SetActive(false);
        blueBackground.SetActive(false);
        greenBackground.SetActive(true);

        colourChosen = 3;
    }
}