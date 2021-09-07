using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryGameManagerRegularHard : MonoBehaviour
{
    public Text matchesText;
    public Text mistakesText;
    public GameObject winScreen;

    public GameObject allTiles;

    public RectTransform[] Tiles;

    public Text[] imageNames;
    public GameObject[] imageNamesObjects;

    int[] tileLocation = new int[20];
    bool[] matchBool = new bool[10];
    int mistakes;
    int matches;
    public static int totalMemoryRegularHardWins;
    public static int totalMemorySuddenDeathHardWins;
    public static int totalMemorySuddenDeathHardLosses;

    int randomEndScreen;
    public GameObject[] EndScreens;

    bool currentlyClicked;
    int currentlyPressedNum;

    public Button[] gameButtons = new Button[20];
    public Image[] gameImages = new Image[20];
    public Sprite[] pictures = new Sprite[83];
    int[] pictureNum = new int[83];

    int[] xCoords = new int[20];
    int[] yCoords = new int[20];

    public bool[] randomPicBool1;
    public bool[] randomPicBool2;

    public void Start()
    {
        // DO NOT TOUCH
        xCoords[0] = -400; //1-1 x
        yCoords[0] = 100; //1-1 y
        xCoords[1] = -200; //1-2 x
        yCoords[1] = 100; //1-2 y
        xCoords[2] = 0; //2-1 x
        yCoords[2] = 100; //2-1 y
        xCoords[3] = 200; //2-2 x
        yCoords[3] = 100; //2-2 y
        xCoords[4] = 400; //3-1 x
        yCoords[4] = 100; //3-1 y
        xCoords[5] = -400; //3-2 x
        yCoords[5] = -10; //3-2 y
        xCoords[6] = -200; //4-1 x
        yCoords[6] = -10; //4-1 y
        xCoords[7] = 0; //4-2 x
        yCoords[7] = -10; //4-2 y
        xCoords[8] = 200; //5-1 x
        yCoords[8] = -10; //5-1 y
        xCoords[9] = 400; //5-2 x
        yCoords[9] = -10; //5-2 y
        xCoords[10] = -400; //6-1 x
        yCoords[10] = -120; //6-1 y
        xCoords[11] = -200; //6-2 x
        yCoords[11] = -120; //6-2 y
        xCoords[12] = 0; //7-1 x
        yCoords[12] = -120; //7-1 y
        xCoords[13] = 200; //7-2 x
        yCoords[13] = -120; //7-2 y
        xCoords[14] = 400; //8-1 x
        yCoords[14] = -120; //8-1 y
        xCoords[15] = -400; //8-2 x
        yCoords[15] = -230; //8-2 y
        xCoords[16] = -200; //9-1 x
        yCoords[16] = -230; //9-1 y
        xCoords[17] = 0; //9-2 x
        yCoords[17] = -230; //9-2 y
        xCoords[18] = 200; //10-1 x
        yCoords[18] = -230; //10-1 y
        xCoords[19] = 400; //10-2 x
        yCoords[19] = -230; //10-2 y

        for (int i = 0; i < 82; i++)
        {
            randomPicBool1[i] = false;
            Debug.Log("The random bool (1) of " + i + " has been made false.");
        }

        for (int i = 0; i < 20; i++)
        {
            randomPicBool2[i] = false;
            Debug.Log("The random bool (2) of " + i + " has been made false.");
        }

        for (int i = 0; i < 10; i++)
        {
            do
            {
                pictureNum[i] = Random.Range(0, 82);
            } while (randomPicBool1[pictureNum[i]] == true);
            randomPicBool1[pictureNum[i]] = true;

            gameImages[i].sprite = pictures[pictureNum[i]];
            imageNames[i].text = pictures[pictureNum[i]].name;
            gameImages[(i + 10)].sprite = pictures[pictureNum[i]];
            imageNames[(i + 10)].text = pictures[pictureNum[i]].name;
                
            Debug.Log("Picture Number (" + i + ") = " + pictureNum[i]);
            Debug.Log("Picture Name (" + i + ") = " + pictures[pictureNum[i]].name);
        }

        // code for randomising the positions of the tiles
        for (int i = 0; i < 20; i++)
        {
            do
            {
                tileLocation[i] = Random.Range(0, 20);
            } while (randomPicBool2[tileLocation[i]] == true);

            randomPicBool2[tileLocation[i]] = true;
            Tiles[tileLocation[i]].anchoredPosition = new Vector3(xCoords[i], yCoords[i]);
            Debug.Log("Position " + i + " was taken by " + tileLocation[i]);
            Debug.Log("Postion Taken (" + tileLocation[i] + ") = " + randomPicBool2[tileLocation[i]]);
        }

        if (Settings.suddenDeath == true)
        {
            for (int i = 0; i < 20; i++)
            {
                gameButtons[i].enabled = false;
            }

            allTiles.GetComponent<Animator>().SetTrigger("SDShowAll");
            Invoke("AllEnabled", 8.2f);
            Settings.suddenDeath = false;
        }
    }

    public void Update()
    {
        matchesText.text = "Matches: " + matches.ToString();
        mistakesText.text = "Mistakes: " + mistakes.ToString();


        if (matchBool[0] == true && matchBool[1] == true && matchBool[2] == true && matchBool[3] == true && matchBool[4] == true && matchBool[5] == true && matchBool[6] == true && matchBool[7] == true && matchBool[8] == true && matchBool[9] == true)
        {
            Debug.Log("Total Matches = " + Settings.totalMatchesInMemory.ToString() + ". Total Mistakes = " + Settings.totalMistakesInMemory.ToString());
            for (int i = 0; i < 10; i++)
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
        else if (currentlyPressedNum == 12)
        {
            gameButtons[currentlyPressedNum].enabled = true;
            allTiles.GetComponent<Animator>().SetTrigger("Tile7To1HalfMistaken");
        }
        else if (currentlyPressedNum == 13)
        {
            gameButtons[currentlyPressedNum].enabled = true;
            allTiles.GetComponent<Animator>().SetTrigger("Tile7To2HalfMistaken");
        }
        else if (currentlyPressedNum == 14)
        {
            gameButtons[currentlyPressedNum].enabled = true;
            allTiles.GetComponent<Animator>().SetTrigger("Tile8To1HalfMistaken");
        }
        else if (currentlyPressedNum == 15)
        {
            gameButtons[currentlyPressedNum].enabled = true;
            allTiles.GetComponent<Animator>().SetTrigger("Tile8To2HalfMistaken");
        }
        else if (currentlyPressedNum == 16)
        {
            gameButtons[currentlyPressedNum].enabled = true;
            allTiles.GetComponent<Animator>().SetTrigger("Tile9To1HalfMistaken");
        }
        else if (currentlyPressedNum == 17)
        {
            gameButtons[currentlyPressedNum].enabled = true;
            allTiles.GetComponent<Animator>().SetTrigger("Tile9To2HalfMistaken");
        }
        else if (currentlyPressedNum == 18)
        {
            gameButtons[currentlyPressedNum].enabled = true;
            allTiles.GetComponent<Animator>().SetTrigger("Tile10To1HalfMistaken");
        }
        else if (currentlyPressedNum == 19)
        {
            gameButtons[currentlyPressedNum].enabled = true;
            allTiles.GetComponent<Animator>().SetTrigger("Tile10To2HalfMistaken");
        }
    }

    public void AddMatches()
    {
        currentlyClicked = false;
        matches++;
        Settings.totalMatchesInMemory++;

        if (matchBool[0] == true && matchBool[1] == true && matchBool[2] == true && matchBool[3] == true && matchBool[4] == true && matchBool[5] == true && matchBool[6] == true && matchBool[7] == true && matchBool[8] == true && matchBool[9] == true)
        {
            Settings.totalMemoryRegularHardWins++;
        }
    }

    public void DebugTest()
    {
        Debug.Log("Currently Clicked = " + currentlyClicked);
        Debug.Log("Matches = " + matches);
        Debug.Log("Mistakes = " + mistakes);
        Debug.Log("Match 1 = " + matchBool[0] + ". Match 2 = " + matchBool[1] + ". Match 3 = " + matchBool[2] + ". Match 4 = " + matchBool[3] + ". Match 5 = " + matchBool[4] + ". Match 6 = " + matchBool[5] + ". Match 7 = " + matchBool[6] + ". Match 8 = " + matchBool[7] + ". Match 9 = " + matchBool[8] + ". Match 10 = " + matchBool[9]);
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

    public void Button7To1()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[12].enabled = false;
            currentlyPressedNum = 12;
            allTiles.GetComponent<Animator>().SetTrigger("Tile7To1Appeared");
        }
        else if (currentlyClicked == true && gameButtons[13].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[6] = true;
            AddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile7Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[13].enabled == true) // if something has been clicked and it doesn't match
        {
            AddMistakes(); // I also want to make an animation here that will show the picture of the wrong tile for a little while, not to keep it as it is because right now, it doesn't show it at all.
            Invoke("Button7To1Mistaken", 0.4f);
        }

        DebugTest();
    }

    public void Button7To2()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[13].enabled = false;
            currentlyPressedNum = 13;
            allTiles.GetComponent<Animator>().SetTrigger("Tile7To2Appeared");
        }
        else if (currentlyClicked == true && gameButtons[12].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[6] = true;
            AddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile7Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[12].enabled == true) // if something has been clicked and it doesn't match
        {
            AddMistakes(); // I also want to make an animation here that will show the picture of the wrong tile for a little while, not to keep it as it is because right now, it doesn't show it at all.
            Invoke("Button7To2Mistaken", 0.4f);
        }

        DebugTest();
    }

    public void Button8To1()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[14].enabled = false;
            currentlyPressedNum = 14;
            allTiles.GetComponent<Animator>().SetTrigger("Tile8To1Appeared");
        }
        else if (currentlyClicked == true && gameButtons[15].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[7] = true;
            AddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile8Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[15].enabled == true) // if something has been clicked and it doesn't match
        {
            AddMistakes(); // I also want to make an animation here that will show the picture of the wrong tile for a little while, not to keep it as it is because right now, it doesn't show it at all.
            Invoke("Button8To1Mistaken", 0.4f);
        }

        DebugTest();
    }

    public void Button8To2()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[15].enabled = false;
            currentlyPressedNum = 15;
            allTiles.GetComponent<Animator>().SetTrigger("Tile8To2Appeared");
        }
        else if (currentlyClicked == true && gameButtons[14].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[7] = true;
            AddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile8Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[14].enabled == true) // if something has been clicked and it doesn't match
        {
            AddMistakes(); // I also want to make an animation here that will show the picture of the wrong tile for a little while, not to keep it as it is because right now, it doesn't show it at all.
            Invoke("Button8To2Mistaken", 0.4f);
        }

        DebugTest();
    }

    public void Button9To1()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[16].enabled = false;
            currentlyPressedNum = 16;
            allTiles.GetComponent<Animator>().SetTrigger("Tile9To1Appeared");
        }
        else if (currentlyClicked == true && gameButtons[17].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[8] = true;
            AddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile9Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[17].enabled == true) // if something has been clicked and it doesn't match
        {
            AddMistakes(); // I also want to make an animation here that will show the picture of the wrong tile for a little while, not to keep it as it is because right now, it doesn't show it at all.
            Invoke("Button9To1Mistaken", 0.4f);
        }

        DebugTest();
    }

    public void Button9To2()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[17].enabled = false;
            currentlyPressedNum = 17;
            allTiles.GetComponent<Animator>().SetTrigger("Tile9To2Appeared");
        }
        else if (currentlyClicked == true && gameButtons[16].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[8] = true;
            AddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile9Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[16].enabled == true) // if something has been clicked and it doesn't match
        {
            AddMistakes(); // I also want to make an animation here that will show the picture of the wrong tile for a little while, not to keep it as it is because right now, it doesn't show it at all.
            Invoke("Button9To2Mistaken", 0.4f);
        }

        DebugTest();
    }

    public void Button10To1()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[18].enabled = false;
            currentlyPressedNum = 18;
            allTiles.GetComponent<Animator>().SetTrigger("Tile10To1Appeared");
        }
        else if (currentlyClicked == true && gameButtons[19].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[9] = true;
            AddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile10Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[19].enabled == true) // if something has been clicked and it doesn't match
        {
            AddMistakes(); // I also want to make an animation here that will show the picture of the wrong tile for a little while, not to keep it as it is because right now, it doesn't show it at all.
            Invoke("Button10To1Mistaken", 0.4f);
        }

        DebugTest();
    }

    public void Button10To2()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[19].enabled = false;
            currentlyPressedNum = 19;
            allTiles.GetComponent<Animator>().SetTrigger("Tile10To2Appeared");
        }
        else if (currentlyClicked == true && gameButtons[18].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[9] = true;
            AddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile10Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[18].enabled == true) // if something has been clicked and it doesn't match
        {
            AddMistakes(); // I also want to make an animation here that will show the picture of the wrong tile for a little while, not to keep it as it is because right now, it doesn't show it at all.
            Invoke("Button10To2Mistaken", 0.4f);
        }

        DebugTest();
    }

    // SUDDEN DEATH --------------------------------- SUDDEN DEATH  --------------------------------- SUDDEN DEATH --------------------------------- SUDDEN DEATH
    // SUDDEN DEATH --------------------------------- SUDDEN DEATH  --------------------------------- SUDDEN DEATH --------------------------------- SUDDEN DEATH
    // SUDDEN DEATH --------------------------------- SUDDEN DEATH  --------------------------------- SUDDEN DEATH --------------------------------- SUDDEN DEATH

    public void AllEnabled()
    {
        for (int i = 0; i < 20; i++)
        {
            gameButtons[i].enabled = true;
        }
    }

    public void SDAddMistakes()
    {
        for (int i = 0; i < 20; i++)
        {
            gameButtons[i].enabled = false;
        }

        allTiles.GetComponent<Animator>().SetTrigger("LostSDGame");
        Settings.totalMistakesInMemory++;
        Settings.totalMemorySuddenDeathHardLosses++;

        randomEndScreen = Random.Range(0, 4);
        EndScreens[randomEndScreen].SetActive(true);
    }

    public void SDAddMatches()
    {
        currentlyClicked = false;
        matches++;
        Settings.totalMatchesInMemory++;

        if (matchBool[0] == true && matchBool[1] == true && matchBool[2] == true && matchBool[3] == true && matchBool[4] == true && matchBool[5] == true && matchBool[6] == true && matchBool[7] == true && matchBool[8] == true && matchBool[9] == true)
        {
            Settings.totalMemorySuddenDeathHardWins++;
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

    public void SDButton7To1()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[12].enabled = false;
            currentlyPressedNum = 12;
            allTiles.GetComponent<Animator>().SetTrigger("Tile7To1Appeared");
        }
        else if (currentlyClicked == true && gameButtons[13].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[6] = true;
            SDAddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile7Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[13].enabled == true) // if something has been clicked and it doesn't match
        {
            SDAddMistakes();
        }

        DebugTest();
    }

    public void SDButton7To2()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[13].enabled = false;
            currentlyPressedNum = 13;
            allTiles.GetComponent<Animator>().SetTrigger("Tile7To2Appeared");
        }
        else if (currentlyClicked == true && gameButtons[12].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[6] = true;
            SDAddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile7Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[12].enabled == true) // if something has been clicked and it doesn't match
        {
            SDAddMistakes();
        }

        DebugTest();
    }

    public void SDButton8To1()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[14].enabled = false;
            currentlyPressedNum = 14;
            allTiles.GetComponent<Animator>().SetTrigger("Tile8To1Appeared");
        }
        else if (currentlyClicked == true && gameButtons[15].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[7] = true;
            SDAddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile8Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[15].enabled == true) // if something has been clicked and it doesn't match
        {
            SDAddMistakes();
        }

        DebugTest();
    }

    public void SDButton8To2()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[15].enabled = false;
            currentlyPressedNum = 15;
            allTiles.GetComponent<Animator>().SetTrigger("Tile8To2Appeared");
        }
        else if (currentlyClicked == true && gameButtons[14].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[7] = true;
            SDAddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile8Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[14].enabled == true) // if something has been clicked and it doesn't match
        {
            SDAddMistakes();
        }

        DebugTest();
    }

    public void SDButton9To1()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[16].enabled = false;
            currentlyPressedNum = 16;
            allTiles.GetComponent<Animator>().SetTrigger("Tile9To1Appeared");
        }
        else if (currentlyClicked == true && gameButtons[17].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[8] = true;
            SDAddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile9Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[17].enabled == true) // if something has been clicked and it doesn't match
        {
            SDAddMistakes();
        }

        DebugTest();
    }

    public void SDButton9To2()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[17].enabled = false;
            currentlyPressedNum = 17;
            allTiles.GetComponent<Animator>().SetTrigger("Tile9To2Appeared");
        }
        else if (currentlyClicked == true && gameButtons[16].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[8] = true;
            SDAddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile9Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[16].enabled == true) // if something has been clicked and it doesn't match
        {
            SDAddMistakes();
        }

        DebugTest();
    }

    public void SDButton10To1()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[18].enabled = false;
            currentlyPressedNum = 18;
            allTiles.GetComponent<Animator>().SetTrigger("Tile10To1Appeared");
        }
        else if (currentlyClicked == true && gameButtons[19].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[9] = true;
            SDAddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile10Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[19].enabled == true) // if something has been clicked and it doesn't match
        {
            SDAddMistakes();
        }

        DebugTest();
    }

    public void SDButton10To2()
    {
        // if this is the first button clicked in the game
        if (currentlyClicked == false)
        {
            currentlyClicked = true;
            gameButtons[19].enabled = false;
            currentlyPressedNum = 19;
            allTiles.GetComponent<Animator>().SetTrigger("Tile10To2Appeared");
        }
        else if (currentlyClicked == true && gameButtons[18].enabled == false)   // if the partner tile has already been clicked
        {
            matchBool[9] = true;
            SDAddMatches();
            // play the animation that will remove the buttons from the game, but for now i will make the buttons setactive equal false immediately
            allTiles.GetComponent<Animator>().SetTrigger("Tile10Disappeared");
        }
        else if (currentlyClicked == true && gameButtons[18].enabled == true) // if something has been clicked and it doesn't match
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

    public void Button7To1Mistaken()
    {
        allTiles.GetComponent<Animator>().SetTrigger("Tile7To1Mistaken");
    }

    public void Button7To2Mistaken()
    {
        allTiles.GetComponent<Animator>().SetTrigger("Tile7To2Mistaken");
    }

    public void Button8To1Mistaken()
    {
        allTiles.GetComponent<Animator>().SetTrigger("Tile8To1Mistaken");
    }

    public void Button8To2Mistaken()
    {
        allTiles.GetComponent<Animator>().SetTrigger("Tile8To2Mistaken");
    }

    public void Button9To1Mistaken()
    {
        allTiles.GetComponent<Animator>().SetTrigger("Tile9To1Mistaken");
    }

    public void Button9To2Mistaken()
    {
        allTiles.GetComponent<Animator>().SetTrigger("Tile9To2Mistaken");
    }

    public void Button10To1Mistaken()
    {
        allTiles.GetComponent<Animator>().SetTrigger("Tile10To1Mistaken");
    }

    public void Button10To2Mistaken()
    {
        allTiles.GetComponent<Animator>().SetTrigger("Tile10To2Mistaken");
    }
}