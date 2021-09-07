using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMovement : MonoBehaviour
{
    public GameObject fadeOutBlack;
    public GameObject settingsObject;

    public void FadeOut()
    {
        fadeOutBlack.GetComponent<Animator>().SetTrigger("FadeOutNow");
    }

    public void BackToStart()
    {
        FadeOut();
        Invoke("BackToStart1", 0.6f);
    }
    
    public void GoToStatistics()
    {
        FadeOut();
        Invoke("GoToStatistics1", 0.6f);
    }

    public void GoToCredits()
    {
        FadeOut();
        Invoke("GoToCredits1", 0.6f);
    }

    // Memory Games
    public void GoToMemoryStart()
    {
        FadeOut();
        Invoke("GoToMemoryStart1", 0.6f);
        settingsObject.GetComponent<Settings>().SavePlayer();
    }

    public void GoToMemoryRegularEasy()
    {
        FadeOut();
        Invoke("GoToMemoryRegularEasy1", 0.6f);
    }

    public void GoToMemoryRegularMedium()
    {
        FadeOut();
        Invoke("GoToMemoryRegularMedium1", 0.6f);
    }
    
    public void GoToMemoryRegularHard()
    {
        FadeOut();
        Invoke("GoToMemoryRegularHard1", 0.6f);
    }

    public void GoToMemorySuddenDeathEasy()
    {
        FadeOut();
        Invoke("GoToMemorySuddenDeathEasy1", 0.6f);
    }

    public void GoToMemorySuddenDeathMedium()
    {
        FadeOut();
        Invoke("GoToMemorySuddenDeathMedium1", 0.6f);
    }

    public void GoToMemorySuddenDeathHard()
    {
        FadeOut();
        Invoke("GoToMemorySuddenDeathHard1", 0.6f);
    }

    // Higher Or Lower Games
    public void GoToHigherOrLowerStart()
    {
        FadeOut();
        Invoke("GoToHigherOrLowerStart1", 0.6f);
        settingsObject.GetComponent<Settings>().SavePlayer();
    }

    public void GoToHigherOrLowerRegularEasy()
    {
        FadeOut();
        Invoke("GoToHigherOrLowerRegularEasy1", 0.6f);
    }

    public void GoToHigherOrLowerRegularMedium()
    {
        FadeOut();
        Invoke("GoToHigherOrLowerRegularMedium1", 0.6f);
    }

    public void GoToHigherOrLowerRegularHard()
    {
        FadeOut();
        Invoke("GoToHigherOrLowerRegularHard1", 0.6f);
    }

    public void GoToHigherOrLowerSuddenDeathEasy()
    {
        FadeOut();
        Invoke("GoToHigherOrLowerSuddenDeathEasy1", 0.6f);
    }

    public void GoToHigherOrLowerSuddenDeathMedium()
    {
        FadeOut();
        Invoke("GoToHigherOrLowerSuddenDeathMedium1", 0.6f);
    }

    public void GoToHigherOrLowerSuddenDeathHard()
    {
        FadeOut();
        Invoke("GoToHigherOrLowerSuddenDeathHard1", 0.6f);
    }

    // Profile Pic Guesser Games
    public void GoToProfilePicGuesserStart()
    {
        FadeOut();
        Invoke("GoToProfilePicGuesserStart1", 0.6f);
        settingsObject.GetComponent<Settings>().SavePlayer();
    }

    public void GoToProfilePicGuesserRegularEasy()
    {
        FadeOut();
        Invoke("GoToProfilePicGuesserRegularEasy1", 0.6f);
    }

    public void GoToProfilePicGuesserRegularMedium()
    {
        FadeOut();
        Invoke("GoToProfilePicGuesserRegularMedium1", 0.6f);
    }

    public void GoToProfilePicGuesserRegularHard()
    {
        FadeOut();
        Invoke("GoToProfilePicGuesserRegularHard1", 0.6f);
    }

    public void GoToProfilePicGuesserSuddenDeathEasy()
    {
        FadeOut();
        Invoke("GoToProfilePicGuesserSuddenDeathEasy1", 0.6f);
    }

    public void GoToProfilePicGuesserSuddenDeathMedium()
    {
        FadeOut();
        Invoke("GoToProfilePicGuesserSuddenDeathMedium1", 0.6f);
    }

    public void GoToProfilePicGuesserSuddenDeathHard()
    {
        FadeOut();
        Invoke("GoToProfilePicGuesserSuddenDeathHard1", 0.6f);
    }

    // Name Guesser Games
    public void GoToNameGuesserStart()
    {
        FadeOut();
        Invoke("GoToNameGuesserStart1", 0.6f);
        settingsObject.GetComponent<Settings>().SavePlayer();
    }

    public void GoToNameGuesserRegularEasy()
    {
        FadeOut();
        Invoke("GoToNameGuesserRegularEasy1", 0.6f);
    }

    public void GoToNameGuesserRegularMedium()
    {
        FadeOut();
        Invoke("GoToNameGuesserRegularMedium1", 0.6f);
    }

    public void GoToNameGuesserRegularHard()
    {
        FadeOut();
        Invoke("GoToNameGuesserRegularHard1", 0.6f);
    }

    public void GoToNameGuesserSuddenDeathEasy()
    {
        FadeOut();
        Invoke("GoToNameGuesserSuddenDeathEasy1", 0.6f);
    }

    public void GoToNameGuesserSuddenDeathMedium()
    {
        FadeOut();
        Invoke("GoToNameGuesserSuddenDeathMedium1", 0.6f);
    }

    public void GoToNameGuesserSuddenDeathHard()
    {
        FadeOut();
        Invoke("GoToNameGuesserSuddenDeathHard1", 0.6f);
    }


    public void RestartGame()
    {
        FadeOut();
        Invoke("RestartGame1", 0.6f);
        settingsObject.GetComponent<Settings>().SavePlayer();
    }

    public void BackToStart1()
    {
        SceneManager.LoadScene("StartScreenWithCube");
    }

    public void GoToStatistics1()
    {
        SceneManager.LoadScene("StatsScreen");
    }

    public void GoToCredits1()
    {
        SceneManager.LoadScene("CreditsScreen");
    }

    // Memory Games
    public void GoToMemoryStart1()
    {
        SceneManager.LoadScene("MemoryGame");
    }

    public void GoToMemoryRegularEasy1()
    {
        SceneManager.LoadScene("MemoryGameRegularEasy");
    }

    public void GoToMemoryRegularMedium1()
    {
        SceneManager.LoadScene("MemoryGameRegularMedium");
    }

    public void GoToMemoryRegularHard1()
    {
        SceneManager.LoadScene("MemoryGameRegularHard");
    }

    public void GoToMemorySuddenDeathEasy1()
    {
        SceneManager.LoadScene("MemoryGameSuddenDeathEasy");
    }

    public void GoToMemorySuddenDeathMedium1()
    {
        SceneManager.LoadScene("MemoryGameSuddenDeathMedium");
    }

    public void GoToMemorySuddenDeathHard1()
    {
        SceneManager.LoadScene("MemoryGameSuddenDeathHard");
    }

    // Higher Or Lower Games
    public void GoToHigherOrLowerStart1()
    {
        SceneManager.LoadScene("HigherOrLower");
    }

    public void GoToHigherOrLowerRegularEasy1()
    {
        SceneManager.LoadScene("HigherOrLowerRegularEasy");
    }

    public void GoToHigherOrLowerRegularMedium1()
    {
        SceneManager.LoadScene("HigherOrLowerRegularMedium");
    }

    public void GoToHigherOrLowerRegularHard1()
    {
        SceneManager.LoadScene("HigherOrLowerRegularHard");
    }

    public void GoToHigherOrLowerSuddenDeathEasy1()
    {
        SceneManager.LoadScene("HigherOrLowerSuddenDeathEasy");
    }

    public void GoToHigherOrLowerSuddenDeathMedium1()
    {
        SceneManager.LoadScene("HigherOrLowerSuddenDeathMedium");
    }

    public void GoToHigherOrLowerSuddenDeathHard1()
    {
        SceneManager.LoadScene("HigherOrLowerSuddenDeathHard");
    }

    // Profile Pic Guesser Games
    public void GoToProfilePicGuesserStart1()
    {
        SceneManager.LoadScene("ProfilePicGuesser");
    }

    public void GoToProfilePicGuesserRegularEasy1()
    {
        SceneManager.LoadScene("ProfilePicGuesserRegularEasy");
    }

    public void GoToProfilePicGuesserRegularMedium1()
    {
        SceneManager.LoadScene("ProfilePicGuesserRegularMedium");
    }

    public void GoToProfilePicGuesserRegularHard1()
    {
        SceneManager.LoadScene("ProfilePicGuesserRegularHard");
    }

    public void GoToProfilePicGuesserSuddenDeathEasy1()
    {
        SceneManager.LoadScene("ProfilePicGuesserSuddenDeathEasy");
    }

    public void GoToProfilePicGuesserSuddenDeathMedium1()
    {
        SceneManager.LoadScene("ProfilePicGuesserSuddenDeathMedium");
    }

    public void GoToProfilePicGuesserSuddenDeathHard1()
    {
        SceneManager.LoadScene("ProfilePicGuesserSuddenDeathHard");
    }

    // Name Guesser Games
    public void GoToNameGuesserStart1()
    {
        SceneManager.LoadScene("NameGuesser");
    }

    public void GoToNameGuesserRegularEasy1()
    {
        SceneManager.LoadScene("NameGuesserRegularEasy");
    }

    public void GoToNameGuesserRegularMedium1()
    {
        SceneManager.LoadScene("NameGuesserRegularMedium");
    }

    public void GoToNameGuesserRegularHard1()
    {
        SceneManager.LoadScene("NameGuesserRegularHard");
    }

    public void GoToNameGuesserSuddenDeathEasy1()
    {
        SceneManager.LoadScene("NameGuesserSuddenDeathEasy");
    }

    public void GoToNameGuesserSuddenDeathMedium1()
    {
        SceneManager.LoadScene("NameGuesserSuddenDeathMedium");
    }

    public void GoToNameGuesserSuddenDeathHard1()
    {
        SceneManager.LoadScene("NameGuesserSuddenDeathHard");
    }

    public void RestartGame1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
