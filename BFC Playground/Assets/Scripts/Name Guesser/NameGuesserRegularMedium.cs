using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameGuesserRegularMedium : MonoBehaviour
{
    public GameObject settingsObject;
    public GameObject whatIsObject;
    public GameObject guessTile;
    public Text matchesText;
    public Text mistakesText;

    public GameObject allTiles;
    public RectTransform[] Tiles;

    int mistakes;
    int matches;

    int currentlyPressedNum;

    public Image gameImage;
    public Button[] gameButtons = new Button[10];
    public Text[] gameTexts = new Text[10];
    public Sprite[] pictures = new Sprite[80];

    int[] xCoords = new int[10];
    int[] yCoords = new int[10];

    int[] throwaway2 = new int[80];
    bool[] usernamesToDisplay = new bool[80];
    int currentPlaceInOrder;        // this will hold where we are in the order of people being shown (in throwaway2)

    int[] throwaway3 = new int[80];                 // used to put random pictures in the 9 wrong tiles
    bool[] usernamesToDisplay1 = new bool[80];

    int[] throwaway4 = new int[10];                 // used to put the tiles in random locations
    bool[] usernamesToDisplay2 = new bool[10];

    //Timer things
    public float timeRemaining;
    public bool timerIsRunning;
    public Text timerText;

    public bool gameIsSuddenDeath;
    public GameObject newHighScore;
    public GameObject gameOverPanel;
    public Text highScoreMatches;
    public Text highScoreMistakes;
    public GameObject highScoreMistakesObject;

    public void Start()
    {
        settingsObject.GetComponent<Settings>().LoadPlayer();
        gameIsSuddenDeath = false;

        // DO NOT TOUCH
        xCoords[0] = -740; //1 x
        yCoords[0] = -330; //1 y
        xCoords[1] = -370; //2 x
        yCoords[1] = -330; //2 y
        xCoords[2] = 0; //3 x
        yCoords[2] = -330; //3 y
        xCoords[3] = 370; //4 x
        yCoords[3] = -330; //4 y
        xCoords[4] = 740; //5 x
        yCoords[4] = -330; //5 y
        xCoords[5] = -740; //6 x
        yCoords[5] = -530; //6 y
        xCoords[6] = -370; //7 x
        yCoords[6] = -530; //7 y
        xCoords[7] = 0; //8 x
        yCoords[7] = -530; //8 y
        xCoords[8] = 370; //9 x
        yCoords[8] = -530; //9 y
        xCoords[9] = 740; //10 x
        yCoords[9] = -530; //10 y


        // generates the order that the usernames will be displayed

        for (int i = 0; i < 80; i++)
        {
            do
            {
                throwaway2[i] = Random.Range(0, 80);                // generates random number
            } while (usernamesToDisplay[throwaway2[i]] == true);    // only continues past this line if the number hasnt been choosen already

            usernamesToDisplay[throwaway2[i]] = true;               // makes sure that the number cannot be chosen again
            Debug.Log("The username of place " + i + " was taken by " + throwaway2[i]);     // displays in the console the order in which the usernames will be displayed
        }
        // at this point, throwaway2[] holds the order of what will be shown

        currentPlaceInOrder = 0;
        gameImage.sprite = pictures[throwaway2[currentPlaceInOrder]];
        gameTexts[0].text = pictures[throwaway2[currentPlaceInOrder]].name;

        // at this point, the correct username is in the first tile

        usernamesToDisplay1[throwaway2[currentPlaceInOrder]] = true;    // to make sure that there is no duplication of the correct username one of the incorrect tiles


        for (int i = 1; i < 10; i++)
        {
            do
            {
                throwaway3[i] = Random.Range(0, 80);                // generates random number
            } while (usernamesToDisplay1[throwaway3[i]] == true);    // only continues past this line if the number hasnt been choosen already

            usernamesToDisplay1[throwaway3[i]] = true;               // makes sure that the number cannot be chosen again
            gameTexts[i].text = pictures[throwaway3[i]].name;
            Debug.Log("The username (" + throwaway3[i] + ") is in the tile (" + i + ").");     // displays in the console which picture is in which tile
        }

        // at this point, all tiles from 2 to 10 now have random wrong usernames


        for (int i = 0; i < 10; i++)
        {
            do
            {
                throwaway4[i] = Random.Range(0, 10);                // generates random number
            } while (usernamesToDisplay2[throwaway4[i]] == true);    // only continues past this line if the number hasnt been choosen already

            usernamesToDisplay2[throwaway4[i]] = true;               // makes sure that the number cannot be chosen again
            Tiles[throwaway4[i]].anchoredPosition = new Vector3(xCoords[i], yCoords[i]);
            Debug.Log("The tile (" + throwaway4[i] + ") is in the location of tile (" + i + ").");     // displays in the console which picture is in which tile
        }

        //at this point, all of the tiles have been shuffled

        timeRemaining = 45;
        timerIsRunning = true;

        if (Settings.suddenDeath == true)
        {
            highScoreMistakesObject.SetActive(false);
            gameIsSuddenDeath = true;
            Settings.suddenDeath = false;
        }
    }

    public void Update()
    {
        matchesText.text = "Matches: " + matches.ToString();

        if (gameIsSuddenDeath == true)
        {
            highScoreMatches.text = "Matches: " + Settings.highestNameGuesserSuddenDeathMediumMatchesScore.ToString();
        }
        else
        {
            mistakesText.text = "Mistakes: " + mistakes.ToString();
            highScoreMatches.text = "Matches: " + Settings.highestNameGuesserRegularMediumMatchesScore.ToString();
            highScoreMistakes.text = "Mistakes: " + Settings.highestNameGuesserRegularMediumMistakesScore.ToString();
        }

        float seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = "Timer: " + seconds.ToString() + "s";

        if (timerIsRunning == true)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                if (gameIsSuddenDeath == true)
                {
                    SDGameOver();
                }
                else
                {
                    GameOver();
                }

                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    public void AddMistakes()
    {
        mistakes++;
        Settings.totalMistakesInNameGuesser++;


        if (currentlyPressedNum == 1)
        {
            gameButtons[currentlyPressedNum].enabled = false;
            allTiles.GetComponent<Animator>().SetTrigger("Tile2Mistaken");
        }
        else if (currentlyPressedNum == 2)
        {
            gameButtons[currentlyPressedNum].enabled = false;
            allTiles.GetComponent<Animator>().SetTrigger("Tile3Mistaken");
        }
        else if (currentlyPressedNum == 3)
        {
            gameButtons[currentlyPressedNum].enabled = false;
            allTiles.GetComponent<Animator>().SetTrigger("Tile4Mistaken");
        }
        else if (currentlyPressedNum == 4)
        {
            gameButtons[currentlyPressedNum].enabled = false;
            allTiles.GetComponent<Animator>().SetTrigger("Tile5Mistaken");
        }
        else if (currentlyPressedNum == 5)
        {
            gameButtons[currentlyPressedNum].enabled = false;
            allTiles.GetComponent<Animator>().SetTrigger("Tile6Mistaken");
        }
        else if (currentlyPressedNum == 6)
        {
            gameButtons[currentlyPressedNum].enabled = false;
            allTiles.GetComponent<Animator>().SetTrigger("Tile7Mistaken");
        }
        else if (currentlyPressedNum == 7)
        {
            gameButtons[currentlyPressedNum].enabled = false;
            allTiles.GetComponent<Animator>().SetTrigger("Tile8Mistaken");
        }
        else if (currentlyPressedNum == 8)
        {
            gameButtons[currentlyPressedNum].enabled = false;
            allTiles.GetComponent<Animator>().SetTrigger("Tile9Mistaken");
        }
        else if (currentlyPressedNum == 9)
        {
            gameButtons[currentlyPressedNum].enabled = false;
            allTiles.GetComponent<Animator>().SetTrigger("Tile10Mistaken");
        }
    }

    public void AddMatches()
    {
        matches++;
        Settings.totalMatchesInNameGuesser++;

        // this makes every button on the board non-interactable
        for (int i = 0; i < 10; i++)
        {
            gameButtons[i].enabled = false;
            Debug.Log("The tile (" + i + ") is disabled");     // displays in the console which picture is in which tile
        }
    }

    public void GameOver()
    {
        timerIsRunning = false;
        for (int i = 0; i < 10; i++)
        {
            gameButtons[i].enabled = false;
        }

        allTiles.GetComponent<Animator>().SetTrigger("GameDone");

        if (matches > Settings.highestNameGuesserRegularMediumMatchesScore)
        {
            newHighScore.SetActive(true);
            Settings.highestNameGuesserRegularMediumMatchesScore = matches;
            Settings.highestNameGuesserRegularMediumMistakesScore = mistakes;
        }
        else if (matches == Settings.highestNameGuesserRegularMediumMatchesScore && mistakes < Settings.highestNameGuesserRegularMediumMistakesScore)
        {
            newHighScore.SetActive(true);
            Settings.highestNameGuesserRegularMediumMistakesScore = mistakes;
        }

        Settings.totalNameGuesserRegularMediumGames++;
        Invoke("ShowGameOverPanel", 0.6f);
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        whatIsObject.SetActive(false);
        guessTile.SetActive(false);
    }

    public void DebugTest()
    {
        Debug.Log("Matches = " + matches);
        Debug.Log("Mistakes = " + mistakes);
        Debug.Log("-------------------------------------------------");
    }

    public void CorrectButton()
    {
        allTiles.GetComponent<Animator>().SetTrigger("GameOver");
        AddMatches();
        Invoke("ResetTheBoard", 0.6f);
    }

    public void ResetTheBoard()
    {
        currentPlaceInOrder++;
        gameTexts[0].text = pictures[throwaway2[currentPlaceInOrder]].name;
        gameImage.sprite = pictures[throwaway2[currentPlaceInOrder]];

        // at this point, the correct username is in the first tile

        // Allows every username to be able to be chosen to go on the board
        for (int i = 0; i < 80; i++)
        {
            usernamesToDisplay1[i] = false;
        }

        for (int i = 0; i < 10; i++)
        {
            usernamesToDisplay2[i] = false;
        }

        usernamesToDisplay1[throwaway2[currentPlaceInOrder]] = true;    // to make sure that there is no duplication of the correct username one of the incorrect tiles

        for (int i = 1; i < 10; i++)
        {
            do
            {
                throwaway3[i] = Random.Range(0, 80);                // generates random number
            } while (usernamesToDisplay1[throwaway3[i]] == true);    // only continues past this line if the number hasnt been choosen already

            usernamesToDisplay1[throwaway3[i]] = true;               // makes sure that the number cannot be chosen again
            gameTexts[i].text = pictures[throwaway3[i]].name;
            Debug.Log("The username (" + throwaway3[i] + ") is in the tile (" + i + ").");     // displays in the console which picture is in which tile
        }

        // at this point, all tiles from 2 to 10 now have random wrong usernames

        for (int i = 0; i < 10; i++)
        {
            do
            {
                throwaway4[i] = Random.Range(0, 10);                // generates random number
            } while (usernamesToDisplay2[throwaway4[i]] == true);    // only continues past this line if the number hasnt been choosen already

            usernamesToDisplay2[throwaway4[i]] = true;               // makes sure that the number cannot be chosen again
            Tiles[throwaway4[i]].anchoredPosition = new Vector3(xCoords[i], yCoords[i]);
            Debug.Log("The tile (" + throwaway4[i] + ") is in the location of tile (" + i + ").");     // displays in the console which username is in which tile
        }

        //at this point, all of the tiles have been shuffled

        for (int i = 0; i < 10; i++)
        {
            gameButtons[i].enabled = true;
            Debug.Log("The tile (" + i + ") is enabled");     // displays in the console which picture is in which tile
        }

        allTiles.GetComponent<Animator>().SetTrigger("ResetBoard");
    }

    public void WrongButton2()
    {
        currentlyPressedNum = 1;
        AddMistakes();
    }

    public void WrongButton3()
    {
        currentlyPressedNum = 2;
        AddMistakes();
    }

    public void WrongButton4()
    {
        currentlyPressedNum = 3;
        AddMistakes();
    }

    public void WrongButton5()
    {
        currentlyPressedNum = 4;
        AddMistakes();
    }

    public void WrongButton6()
    {
        currentlyPressedNum = 5;
        AddMistakes();
    }

    public void WrongButton7()
    {
        currentlyPressedNum = 6;
        AddMistakes();
    }

    public void WrongButton8()
    {
        currentlyPressedNum = 7;
        AddMistakes();
    }

    public void WrongButton9()
    {
        currentlyPressedNum = 8;
        AddMistakes();
    }

    public void WrongButton10()
    {
        currentlyPressedNum = 9;
        AddMistakes();
    }


    // SUDDEN DEATH --------------------------------- SUDDEN DEATH  --------------------------------- SUDDEN DEATH --------------------------------- SUDDEN DEATH
    // SUDDEN DEATH --------------------------------- SUDDEN DEATH  --------------------------------- SUDDEN DEATH --------------------------------- SUDDEN DEATH
    // SUDDEN DEATH --------------------------------- SUDDEN DEATH  --------------------------------- SUDDEN DEATH --------------------------------- SUDDEN DEATH


    public void SDGameOver()
    {
        timerIsRunning = false;
        for (int i = 0; i < 10; i++)
        {
            gameButtons[i].enabled = false;
        }

        allTiles.GetComponent<Animator>().SetTrigger("GameDone");

        if (matches > Settings.highestNameGuesserSuddenDeathMediumMatchesScore)
        {
            newHighScore.SetActive(true);
            Settings.highestNameGuesserSuddenDeathMediumMatchesScore = matches;
        }

        Settings.totalNameGuesserSuddenDeathMediumGames++;
        Invoke("ShowGameOverPanel", 0.6f);
    }
}