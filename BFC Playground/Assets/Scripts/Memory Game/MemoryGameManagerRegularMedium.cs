using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryGameManagerRegularMedium : MonoBehaviour
{
    public Text matchesText;
    public Text mistakesText;
    public GameObject winScreen;

    public GameObject allTiles;

    public RectTransform[] Tiles;

    public Text[] imageNames;
    public GameObject[] imageNamesObjects;

    int[] tileLocation = new int[12];
    bool[] matchBool = new bool[6];
    int mistakes;
    int matches;
    public static int totalMemoryRegularMediumWins;
    public static int totalMemorySuddenDeathMediumWins;
    public static int totalMemorySuddenDeathMediumLosses;

    int randomEndScreen;
    public GameObject[] EndScreens;

    bool currentlyClicked;
    int currentlyPressedNum;

    public Button[] gameButtons = new Button[12];
    public Image[] gameImages = new Image[12];
    public Sprite[] pictures = new Sprite[83];
    int[] pictureNum = new int[83];

    int[] xCoords = new int[12];
    int[] yCoords = new int[12];

    public bool[] randomPicBool1;
    public bool[] randomPicBool2;

    public void Start()
    {
        // DO NOT TOUCH
        xCoords[0] = -420; //1-1 x
        yCoords[0] = 80; //1-1 y
        xCoords[1] = -145; //1-2 x
        yCoords[1] = 80; //1-2 y
        xCoords[2] = 145; //2-1 x
        yCoords[2] = 80; //2-1 y
        xCoords[3] = 420; //2-2 x
        yCoords[3] = 80; //2-2 y
        xCoords[4] = -420; //3-1 x
        yCoords[4] = -60; //3-1 y
        xCoords[5] = -145; //3-2 x
        yCoords[5] = -60; //3-2 y
        xCoords[6] = 145; //4-1 x
        yCoords[6] = -60; //4-1 y
        xCoords[7] = 420; //4-2 x
        yCoords[7] = -60; //4-2 y
        xCoords[8] = -420; //5-1 x
        yCoords[8] = -200; //5-1 y
        xCoords[9] = -145; //5-2 x
        yCoords[9] = -200; //5-2 y
        xCoords[10] = 145; //6-1 x
        yCoords[10] = -200; //6-1 y
        xCoords[11] = 420; //6-2 x
        yCoords[11] = -200; //6-2 y

        for (int i = 0; i < 82; i++)
        {
            randomPicBool1[i] = false;
            Debug.Log("The random bool (1) of " + i + " has been made false.");
        }

        for (int i = 0; i < 12; i++)
        {
            randomPicBool2[i] = false;
            Debug.Log("The random bool (2) of " + i + " has been made false.");
        }

        for (int i = 0; i < 6; i++)
        {
            do
            {
                pictureNum[i] = Random.Range(0, 82);
            } while (randomPicBool1[pictureNum[i]] == true);
            randomPicBool1[pictureNum[i]] = true;

            gameImages[i].sprite = pictures[pictureNum[i]];
            imageNames[i].text = pictures[pictureNum[i]].name;
            gameImages[(i + 6)].sprite = pictures[pictureNum[i]];
            imageNames[(i + 6)].text = pictures[pictureNum[i]].name;

            Debug.Log("Picture Number (" + i + ") = " + pictureNum[i]);
            Debug.Log("Picture Name (" + i + ") = " + pictures[pictureNum[i]].name);
        }

        // code for randomising the positions of the tiles
        for (int i = 0; i < 12; i++)
        {
            do
            {
                tileLocation[i] = Random.Range(0, 12);
            } while (randomPicBool2[tileLocation[i]] == true);
            randomPicBool2[tileLocation[i]] = true;

            Tiles[tileLocation[i]].anchoredPosition = new Vector3(xCoords[i], yCoords[i]);
            Debug.Log("Position " + i + " was taken by " + tileLocation[i]);
            Debug.Log("Postion Taken (" + tileLocation[i] + ") = " + randomPicBool2[tileLocation[i]]);
        }

        if (Settings.suddenDeath == true)
        {
            for (int i = 0; i < 12; i++)
            {
                gameButtons[i].enabled = false;
            }
            allTiles.GetComponent<Animator>().SetTrigger("SDShowAll");
            Invoke("AllEnabled", 4.2f);
            Settings.suddenDeath = false;
        }
    }

    public void Update()
    {
        matchesText.text = "Matches: " + matches.ToString();
        mistakesText.text = "Mistakes: " + mistakes.ToString();


        if (matchBool[0] == true && matchBool[1] == true && matchBool[2] == true && matchBool[3] == true && matchBool[4] == true && matchBool[5] == true)
        {
            Debug.Log("Total Matches = " + Settings.totalMatchesInHigherOrLower.ToString() + ". Total Mistakes = " + Settings.totalMistakesInMemory.ToString());
            for (int i = 0; i < 6; i++)
            {
                matchBool[i] = false;
            }

            winScreen.SetActive(true);
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
        }
        else if (currentlyPressedNum == 1)
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
        else if (currentlyPressedNum == 6)
        {
            gameButtons[currentlyPressedNum].enabled = true;
            allTiles.GetComponent<Animator>().SetTrigger("Tile4To1HalfMistaken");
        }
        else if (currentlyPressedNum == 7)
        {
            gameButtons[currentlyPressedNum].enabled = true;
            allTiles.GetComponent<Animator>().SetTrigger("Tile4To2HalfMistaken");
        }
        else if (currentlyPressedNum == 8)
        {
            gameButtons[currentlyPressedNum].enabled = true;
            allTiles.GetComponent<Animator>().SetTrigger("Tile5To1HalfMistaken");
        }
        else if (currentlyPressedNum == 9)
        {
            gameButtons[currentlyPressedNum].enabled = true;
            allTiles.GetComponent<Animator>().SetTrigger("Tile5To2HalfMistaken");
        }
        else if (currentlyPressedNum == 10)
        {
            gameButtons[currentlyPressedNum].enabled = true;
            allTiles.GetComponent<Animator>().SetTrigger("Tile6To1HalfMistaken");
        }
        else if (currentlyPressedNum == 11)
        {
            gameButtons[currentlyPressedNum].enabled = true;
            allTiles.GetComponent<Animator>().SetTrigger("Tile6To2HalfMistaken");
        }
    }

    public void AddMatches()
    {
        currentlyClicked = false;
        matches++;
        Settings.totalMatchesInMemory++;

        if (matchBool[0] == true && matchBool[1] == true && matchBool[2] == true && matchBool[3] == true && matchBool[4] == true && matchBool[5] == true)
        {
            Settings.totalMemoryRegularMediumWins++;
        }
    }

    public void DebugTest()
    {
        Debug.Log("Currently Clicked = " + currentlyClicked);
        Debug.Log("Matches = " + matches);
        Debug.Log("Mistakes = " + mistakes);
        Debug.Log("Match 1 = " + matchBool[0] + ". Match 2 = " + matchBool[1] + ". Match 3 = " + matchBool[2] + ". Match 4 = " + matchBool[3] + ". Match 5 = " + matchBool[4] + ". Match 6 = " + matchBool[5]);
        Debug.Log("-------------------------------------------------");
    }

    public void Button1To1()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[0].enabled = false;
            currentlyPressedNum = 0;
            allTiles.GetComponent<Animator>().SetTrigger("Tile1To1Appeared");
        }
        else if (currentlyClicked == true && gameButtons[1].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[0] = true;
            AddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile1Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[1].enabled == true) // if something has been clicked and it doesn't match
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

    public void Button4To1()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[6].enabled = false;
            currentlyPressedNum = 6;
            allTiles.GetComponent<Animator>().SetTrigger("Tile4To1Appeared");
        }
        else if (currentlyClicked == true && gameButtons[7].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[3] = true;
            AddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile4Disappeared");

        }
        else if (currentlyClicked == true && gameButtons[7].enabled == true) // if something has been clicked and it doesn't match
        {
            AddMistakes();
            Invoke("Button4To1Mistaken", 0.4f);
        }

        DebugTest();
    }

    public void Button4To2()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[7].enabled = false;
            currentlyPressedNum = 7;
            allTiles.GetComponent<Animator>().SetTrigger("Tile4To2Appeared");
        }
        else if (currentlyClicked == true && gameButtons[6].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[3] = true;
            AddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile4Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[6].enabled == true) // if something has been clicked and it doesn't match
        {
            AddMistakes();
            Invoke("Button4To2Mistaken", 0.4f);
        }

        DebugTest();
    }

    public void Button5To1()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[8].enabled = false;
            currentlyPressedNum = 8;
            allTiles.GetComponent<Animator>().SetTrigger("Tile5To1Appeared");
        }
        else if (currentlyClicked == true && gameButtons[9].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[4] = true;
            AddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile5Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[9].enabled == true) // if something has been clicked and it doesn't match
        {
            AddMistakes();
            Invoke("Button5To1Mistaken", 0.4f);
        }

        DebugTest();
    }

    public void Button5To2()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[9].enabled = false;
            currentlyPressedNum = 9;
            allTiles.GetComponent<Animator>().SetTrigger("Tile5To2Appeared");
        }
        else if (currentlyClicked == true && gameButtons[8].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[4] = true;
            AddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile5Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[8].enabled == true) // if something has been clicked and it doesn't match
        {
            AddMistakes();
            Invoke("Button5To2Mistaken", 0.4f);
        }

        DebugTest();
    }

    public void Button6To1()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[10].enabled = false;
            currentlyPressedNum = 10;
            allTiles.GetComponent<Animator>().SetTrigger("Tile6To1Appeared");
        }
        else if (currentlyClicked == true && gameButtons[11].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[5] = true;
            AddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile6Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[11].enabled == true) // if something has been clicked and it doesn't match
        {
            AddMistakes();
            Invoke("Button6To1Mistaken", 0.4f);
        }

        DebugTest();
    }

    public void Button6To2()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[11].enabled = false;
            currentlyPressedNum = 11;
            allTiles.GetComponent<Animator>().SetTrigger("Tile6To2Appeared");
        }
        else if (currentlyClicked == true && gameButtons[10].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[5] = true;
            AddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile6Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[10].enabled == true) // if something has been clicked and it doesn't match
        {
            AddMistakes(); // I also want to make an animation here that will show the picture of the wrong tile for a little while, not to keep it as it is because right now, it doesn't show it at all.
            Invoke("Button6To2Mistaken", 0.4f);
        }

        DebugTest();
    }


    // SUDDEN DEATH --------------------------------- SUDDEN DEATH  --------------------------------- SUDDEN DEATH --------------------------------- SUDDEN DEATH
    // SUDDEN DEATH --------------------------------- SUDDEN DEATH  --------------------------------- SUDDEN DEATH --------------------------------- SUDDEN DEATH
    // SUDDEN DEATH --------------------------------- SUDDEN DEATH  --------------------------------- SUDDEN DEATH --------------------------------- SUDDEN DEATH

    public void AllEnabled()
    {
        for (int i = 0; i < 12; i++)
        {
            gameButtons[i].enabled = true;
        }
    }

    public void SDAddMistakes()
    {
        Settings.totalMistakesInMemory++;
        Settings.totalMemorySuddenDeathMediumLosses++;
        for (int i = 0; i < 12; i++)
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

        if (matchBool[0] == true && matchBool[1] == true && matchBool[2] == true && matchBool[3] == true && matchBool[4] == true && matchBool[5] == true)
        {
            Settings.totalMemorySuddenDeathMediumWins++;
        }
    }

    public void SDButton1To1()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[0].enabled = false;
            currentlyPressedNum = 0;
            allTiles.GetComponent<Animator>().SetTrigger("Tile1To1Appeared");
        }
        else if (currentlyClicked == true && gameButtons[1].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[0] = true;
            SDAddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile1Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[1].enabled == true) // if something has been clicked and it doesn't match
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

    public void SDButton4To1()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[6].enabled = false;
            currentlyPressedNum = 6;
            allTiles.GetComponent<Animator>().SetTrigger("Tile4To1Appeared");
        }
        else if (currentlyClicked == true && gameButtons[7].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[3] = true;
            SDAddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile4Disappeared");

        }
        else if (currentlyClicked == true && gameButtons[7].enabled == true) // if something has been clicked and it doesn't match
        {
            SDAddMistakes();
        }

        DebugTest();
    }

    public void SDButton4To2()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[7].enabled = false;
            currentlyPressedNum = 7;
            allTiles.GetComponent<Animator>().SetTrigger("Tile4To2Appeared");
        }
        else if (currentlyClicked == true && gameButtons[6].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[3] = true;
            SDAddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile4Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[6].enabled == true) // if something has been clicked and it doesn't match
        {
            SDAddMistakes();
        }

        DebugTest();
    }

    public void SDButton5To1()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[8].enabled = false;
            currentlyPressedNum = 8;
            allTiles.GetComponent<Animator>().SetTrigger("Tile5To1Appeared");
        }
        else if (currentlyClicked == true && gameButtons[9].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[4] = true;
            SDAddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile5Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[9].enabled == true) // if something has been clicked and it doesn't match
        {
            SDAddMistakes();
        }

        DebugTest();
    }

    public void SDButton5To2()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[9].enabled = false;
            currentlyPressedNum = 9;
            allTiles.GetComponent<Animator>().SetTrigger("Tile5To2Appeared");
        }
        else if (currentlyClicked == true && gameButtons[8].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[4] = true;
            SDAddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile5Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[8].enabled == true) // if something has been clicked and it doesn't match
        {
            SDAddMistakes();
        }

        DebugTest();
    }

    public void SDButton6To1()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[10].enabled = false;
            currentlyPressedNum = 10;
            allTiles.GetComponent<Animator>().SetTrigger("Tile6To1Appeared");
        }
        else if (currentlyClicked == true && gameButtons[11].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[5] = true;
            SDAddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile6Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[11].enabled == true) // if something has been clicked and it doesn't match
        {
            SDAddMistakes();
        }

        DebugTest();
    }

    public void SDButton6To2()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[11].enabled = false;
            currentlyPressedNum = 11;
            allTiles.GetComponent<Animator>().SetTrigger("Tile6To2Appeared");
        }
        else if (currentlyClicked == true && gameButtons[10].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[5] = true;
            SDAddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile6Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[10].enabled == true) // if something has been clicked and it doesn't match
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

    public void Button4To1Mistaken()
    {
        allTiles.GetComponent<Animator>().SetTrigger("Tile4To1Mistaken");
    }

    public void Button4To2Mistaken()
    {
        allTiles.GetComponent<Animator>().SetTrigger("Tile4To2Mistaken");
    }

    public void Button5To1Mistaken()
    {
        allTiles.GetComponent<Animator>().SetTrigger("Tile5To1Mistaken");
    }

    public void Button5To2Mistaken()
    {
        allTiles.GetComponent<Animator>().SetTrigger("Tile5To2Mistaken");
    }

    public void Button6To1Mistaken()
    {
        allTiles.GetComponent<Animator>().SetTrigger("Tile6To1Mistaken");
    }

    public void Button6To2Mistaken()
    {
        allTiles.GetComponent<Animator>().SetTrigger("Tile6To2Mistaken");
    }
}