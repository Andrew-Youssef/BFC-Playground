using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryGameManagerRegularEasy : MonoBehaviour
{
    public Text matchesText;
    public Text mistakesText;
    public GameObject winScreen;

    public GameObject allTiles;

    public RectTransform[] Tiles;

    public Text[] imageNames;
    public GameObject[] imageNamesObjects;
    
    int[] tileLocation = new int[6];
    bool[] matchBool = new bool[3];
    int mistakes;
    int matches;

    int randomEndScreen;
    public GameObject[] EndScreens;

    bool currentlyClicked;
    int currentlyPressedNum;

    public Button[] gameButtons = new Button[6];
    public Image[] gameImages = new Image[6];
    public Sprite[] pictures = new Sprite[83];
    int[] pictureNum = new int[83];
    
    int[] xCoords = new int[6];
    int[] yCoords = new int[6];

    public bool[] randomPicBool1;
    public bool[] randomPicBool2;

    public void Start()
    {
        // DO NOT TOUCH
        xCoords[0] = -400;
        yCoords[0] = 55;
        xCoords[1] = 0;
        yCoords[1] = 55;
        xCoords[2] = 400;
        yCoords[2] = 55;
        xCoords[3] = -400;
        yCoords[3] = -150;
        xCoords[4] = 0;
        yCoords[4] = -150;
        xCoords[5] = 400;
        yCoords[5] = -150;

        for (int i = 0; i < 82; i++)
        {
            randomPicBool1[i] = false;
            Debug.Log("The random bool (1) of " + i + " has been made false.");
        }

        for (int i = 0; i < 6; i++)
        {
            randomPicBool2[i] = false;
            Debug.Log("The random bool (2) of " + i + " has been made false.");
        }

        for (int i = 0; i < 3; i++)
        {
            do
            {
                pictureNum[i] = Random.Range(0, 82);
            } while (randomPicBool1[pictureNum[i]] == true);
            randomPicBool1[pictureNum[i]] = true;

            gameImages[i].sprite = pictures[pictureNum[i]];
            imageNames[i].text = pictures[pictureNum[i]].name;
            gameImages[(i + 3)].sprite = pictures[pictureNum[i]];
            imageNames[(i + 3)].text = pictures[pictureNum[i]].name;

            Debug.Log("Picture Number (" + i + ") = " + pictureNum[i]);
            Debug.Log("Picture Name (" + i + ") = " + pictures[pictureNum[i]].name);
        }
        
        // Determining the positions of each tile
        for (int i = 0; i < 6; i++)     // for loop from 0 to 5
        {
            do
            {
                tileLocation[i] = Random.Range(0, 6);           // generate a random number between and including 0 to 5
            } while (randomPicBool2[tileLocation[i]] == true);  // make sure that the random numbers are not duplicated
            randomPicBool2[tileLocation[i]] = true;

            Tiles[tileLocation[i]].anchoredPosition = new Vector3(xCoords[i], yCoords[i]);  // move the tile to a random position
            Debug.Log("Tile location (" + tileLocation[i] + ") = " + tileLocation[i]);      // display in the console where each tile has been moved
            Debug.Log("Position Taken (" + tileLocation[i] + ") = " + randomPicBool2[tileLocation[i]]);
        }

        if (Settings.suddenDeath == true)
        {
            for (int i = 0; i < 6; i++)
            {
                gameButtons[i].enabled = false;
            }

            allTiles.GetComponent<Animator>().SetTrigger("SDShowAll");
            Invoke("AllEnabled", 1f);
            Settings.suddenDeath = false;
        }
    }

    public void AddMistakes()
    {
        currentlyClicked = false;
        mistakes++;
        Settings.totalMistakesInMemory++;

        if (currentlyPressedNum == 0)
        {
            gameButtons[currentlyPressedNum].enabled = true;
            allTiles.GetComponent<Animator>().SetTrigger("Tile1To1HalfMistaken");
        } else if (currentlyPressedNum == 1)
        {
            gameButtons[currentlyPressedNum].enabled = true;
            allTiles.GetComponent<Animator>().SetTrigger("Tile1To2HalfMistaken");
        }
        else if (currentlyPressedNum == 2)
        {
            gameButtons[currentlyPressedNum].enabled = true;
            allTiles.GetComponent<Animator>().SetTrigger("Tile2To1HalfMistaken");
        }
        else if (currentlyPressedNum == 3)
        {
            gameButtons[currentlyPressedNum].enabled = true;
            allTiles.GetComponent<Animator>().SetTrigger("Tile2To2HalfMistaken");
        }
        else if (currentlyPressedNum == 4)
        {
            gameButtons[currentlyPressedNum].enabled = true;
            allTiles.GetComponent<Animator>().SetTrigger("Tile3To1HalfMistaken");
        }
        else if (currentlyPressedNum == 5)
        {
            gameButtons[currentlyPressedNum].enabled = true;
            allTiles.GetComponent<Animator>().SetTrigger("Tile3To2HalfMistaken");
        }
    }

    public void AddMatches()
    {
        currentlyClicked = false;
        matches++;
        Settings.totalMatchesInMemory++;

        if (matchBool[0] == true && matchBool[1] == true && matchBool[2] == true)
        {
            Settings.totalMemoryRegularEasyWins++;
        }
    }

    public void Update()
    {
        matchesText.text = "Matches: " + matches.ToString();
        mistakesText.text = "Mistakes: " + mistakes.ToString();


        if (matchBool[0] == true && matchBool[1] == true && matchBool[2] == true)
        {
            matchBool[0] = false;
            matchBool[1] = false;
            matchBool[2] = false;

            winScreen.SetActive(true);
        }
    }

    public void DebugTest()
    {
        Debug.Log("Currently Clicked = " + currentlyClicked);
        Debug.Log("Matches = " + matches);
        Debug.Log("Mistakes = " + mistakes);
        Debug.Log("Match 1 = " + matchBool[0] + ". Match 2 = " + matchBool[1] + ". Match 3 = " + matchBool[2] + ".");
        Debug.Log("-------------------------------------------------");
    }

    public void Button1To1()
    {
        // if this is the first button clicked in the game (appeared)
        if (currentlyClicked == false)
        {            
            currentlyClicked = true;
            gameButtons[0].enabled = false;
            currentlyPressedNum = 0;
            allTiles.GetComponent<Animator>().SetTrigger("Tile1To1Appeared");
        }
        else if (currentlyClicked == true && gameButtons[1].enabled == false)   // if the partner tile has already been clicked (disappear)
        {
            matchBool[0] = true;
            AddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile1Disappeared");

        }
        else if (currentlyClicked == true && gameButtons[1].enabled == true) // if something has been clicked and it doesn't match (mistake)
        {
            AddMistakes();
            Invoke("Button1To1Mistaken", 0.4f);
        }

        DebugTest();
    }

    public void Button1To2()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[1].enabled = false;
            currentlyPressedNum = 1;
            allTiles.GetComponent<Animator>().SetTrigger("Tile1To2Appeared");
        }
        else if (currentlyClicked == true && gameButtons[0].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[0] = true;
            AddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile1Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[0].enabled == true) // if something has been clicked and it doesn't match
        {
            AddMistakes();
            Invoke("Button1To2Mistaken", 0.4f);
        }

        DebugTest();
    }

    public void Button2To1()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[2].enabled = false;
            currentlyPressedNum = 2;
            allTiles.GetComponent<Animator>().SetTrigger("Tile2To1Appeared");
        }
        else if (currentlyClicked == true && gameButtons[3].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[1] = true;
            AddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile2Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[3].enabled == true) // if something has been clicked and it doesn't match
        {
            AddMistakes();
            Invoke("Button2To1Mistaken", 0.4f);
        }

        DebugTest();
    }

    public void Button2To2()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;            
            gameButtons[3].enabled = false;            
            currentlyPressedNum = 3;
            allTiles.GetComponent<Animator>().SetTrigger("Tile2To2Appeared");
        }
        else if (currentlyClicked == true && gameButtons[2].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[1] = true;
            AddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile2Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[2].enabled == true) // if something has been clicked and it doesn't match
        {
            AddMistakes();
            Invoke("Button2To2Mistaken", 0.4f);
        }

        DebugTest();
    }

    public void Button3To1()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;          
            gameButtons[4].enabled = false;            
            currentlyPressedNum = 4;
            allTiles.GetComponent<Animator>().SetTrigger("Tile3To1Appeared");
        }
        else if (currentlyClicked == true && gameButtons[5].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[2] = true;
            AddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile3Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[5].enabled == true) // if something has been clicked and it doesn't match
        {
            AddMistakes();
            Invoke("Button3To1Mistaken", 0.4f);
        }

        DebugTest();
    }

    public void Button3To2()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;           
            gameButtons[5].enabled = false;            
            currentlyPressedNum = 5;
            allTiles.GetComponent<Animator>().SetTrigger("Tile3To2Appeared");
        }
        else if (currentlyClicked == true && gameButtons[4].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[2] = true;
            AddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile3Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[4].enabled == true) // if something has been clicked and it doesn't match
        {
            AddMistakes();
            Invoke("Button3To2Mistaken", 0.4f);
        }

        DebugTest();
    }

    // SUDDEN DEATH --------------------------------- SUDDEN DEATH  --------------------------------- SUDDEN DEATH --------------------------------- SUDDEN DEATH
    // SUDDEN DEATH --------------------------------- SUDDEN DEATH  --------------------------------- SUDDEN DEATH --------------------------------- SUDDEN DEATH
    // SUDDEN DEATH --------------------------------- SUDDEN DEATH  --------------------------------- SUDDEN DEATH --------------------------------- SUDDEN DEATH

    public void AllEnabled()
    {
        for (int i = 0; i < 6; i++)
        {
            gameButtons[i].enabled = true;
        }
    }

    public void SDAddMistakes()
    {
        Settings.totalMistakesInMemory++;
        Settings.totalMemorySuddenDeathEasyLosses++;
        for (int i = 0; i < 6; i++)
        {
            gameButtons[i].enabled = false;
        }
        allTiles.GetComponent<Animator>().SetTrigger("LostSDGame");

        randomEndScreen = Random.Range(0, 4);
        EndScreens[randomEndScreen].SetActive(true);
    }

    public void SDAddMatches()
    {
        currentlyClicked = false;
        matches++;
        Settings.totalMatchesInMemory++;

        if (matchBool[0] == true && matchBool[1] == true && matchBool[2] == true)
        {
            Settings.totalMemorySuddenDeathEasyWins++;
        }
    }

    public void SDButton1To1()
    {
        // if this is the first button clicked in the game (appeared)
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[0].enabled = false;
            currentlyPressedNum = 0;
            allTiles.GetComponent<Animator>().SetTrigger("Tile1To1Appeared");
        }
        else if (currentlyClicked == true && gameButtons[1].enabled == false)   // if the partner tile has already been clicked (disappear)
        {
            matchBool[0] = true;
            SDAddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile1Disappeared");

        }
        else if (currentlyClicked == true && gameButtons[1].enabled == true) // if something has been clicked and it doesn't match (mistake)
        {
            SDAddMistakes();
        }

        DebugTest();
    }

    public void SDButton1To2()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[1].enabled = false;
            currentlyPressedNum = 1;
            allTiles.GetComponent<Animator>().SetTrigger("Tile1To2Appeared");
        }
        else if (currentlyClicked == true && gameButtons[0].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[0] = true;
            SDAddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile1Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[0].enabled == true) // if something has been clicked and it doesn't match
        {
            SDAddMistakes();
        }

        DebugTest();
    }

    public void SDButton2To1()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[2].enabled = false;
            currentlyPressedNum = 2;
            allTiles.GetComponent<Animator>().SetTrigger("Tile2To1Appeared");
        }
        else if (currentlyClicked == true && gameButtons[3].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[1] = true;
            SDAddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile2Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[3].enabled == true) // if something has been clicked and it doesn't match
        {
            SDAddMistakes();
        }

        DebugTest();
    }

    public void SDButton2To2()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[3].enabled = false;
            currentlyPressedNum = 3;
            allTiles.GetComponent<Animator>().SetTrigger("Tile2To2Appeared");
        }
        else if (currentlyClicked == true && gameButtons[2].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[1] = true;
            SDAddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile2Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[2].enabled == true) // if something has been clicked and it doesn't match
        {
            SDAddMistakes();
        }

        DebugTest();
    }

    public void SDButton3To1()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[4].enabled = false;
            currentlyPressedNum = 4;
            allTiles.GetComponent<Animator>().SetTrigger("Tile3To1Appeared");
        }
        else if (currentlyClicked == true && gameButtons[5].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[2] = true;
            SDAddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile3Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[5].enabled == true) // if something has been clicked and it doesn't match
        {
            SDAddMistakes();
        }

        DebugTest();
    }

    public void SDButton3To2()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[5].enabled = false;
            currentlyPressedNum = 5;
            allTiles.GetComponent<Animator>().SetTrigger("Tile3To2Appeared");
        }
        else if (currentlyClicked == true && gameButtons[4].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[2] = true;
            SDAddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile3Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[4].enabled == true) // if something has been clicked and it doesn't match
        {
            SDAddMistakes();
        }

        DebugTest();
    }

    public void Button1To1Mistaken()
    {
        allTiles.GetComponent<Animator>().SetTrigger("Tile1To1Mistaken");
    }

    public void Button1To2Mistaken()
    {
        allTiles.GetComponent<Animator>().SetTrigger("Tile1To2Mistaken");
    }

    public void Button2To1Mistaken()
    {
        allTiles.GetComponent<Animator>().SetTrigger("Tile2To1Mistaken");
    }

    public void Button2To2Mistaken()
    {
        allTiles.GetComponent<Animator>().SetTrigger("Tile2To2Mistaken");
    }

    public void Button3To1Mistaken()
    {
        allTiles.GetComponent<Animator>().SetTrigger("Tile3To1Mistaken");
    }

    public void Button3To2Mistaken()
    {
        allTiles.GetComponent<Animator>().SetTrigger("Tile3To2Mistaken");
    }
}