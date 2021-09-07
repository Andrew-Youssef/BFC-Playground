using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HigherOrLowerRegularEasy : MonoBehaviour
{
    public Text matchesText; //Tells the player how many matches they have made out of 3
    public Text WhenDid; //Tells the player who they are guessing
    public GameObject winScreen; //Is shown if the player guesses all 3 users' follow ages correctly

    int livesRemaining; //Shows how many more mistakes the player can make
    public GameObject allHearts; //used for animations

    int guessingPlayerNum;
    bool gameEnded;
    bool singleMistake;
    bool doubleMistake;

    public GameObject tileGameObject;
    public Image tileImage; //Shows the profile picture of the person
    public Text tileName;

    public Text previousMonth;
    public Text previousYear;

    bool[] matchBool = new bool[3];
    int mistakes;
    int matches;

    int randomEndScreen;
    public GameObject[] EndScreens;

    public GameObject monthTitle;
    public GameObject yearTitle;
    public GameObject monthHigher;
    public GameObject monthLower;
    public GameObject monthLocked;
    public GameObject yearHigher;
    public GameObject yearLower;
    public GameObject yearLocked;

    public Dropdown monthDropdown;
    public Dropdown yearDropdown;

    int chosenMonth;
    int chosenYear;
    int currentMonth;
    int currentYear;

    //Timer things
    public float timeRemaining;
    public bool timerIsRunning;
    public Text timerText;

    public GameObject[] disappearThings;

    // CHANGE THIS WHEN NEW PEOPLE ARE ADDED
    // CHANGE THIS WHEN NEW PEOPLE ARE ADDED
    // CHANGE THIS WHEN NEW PEOPLE ARE ADDED
    public Sprite[] pictures = new Sprite[101]; // the amount of people with profile pics (and another for the unavailable sign)
    int[] pictureNum = new int[4];
    public string[] names;
    string[] userMonth = new string[101];
    string[] userYear = new string[101];

    public void Start()
    {
        // the month and year that people started following https://twitch.tv/brodie

        userMonth[1] = "May"; //1nnathan
        userYear[1] = "2020";
        userMonth[2] = "October"; //aimee_gibby
        userYear[2] = "2019";
        userMonth[3] = "January"; //amylee__c
        userYear[3] = "2021";
        userMonth[4] = "January"; //andrew654667
        userYear[4] = "2020";
        userMonth[5] = "January"; //Artem1sTV
        userYear[5] = "2020";
        userMonth[6] = "September"; //ashleighh2
        userYear[6] = "2019";
        userMonth[7] = "June"; //bazoski1er
        userYear[7] = "2019";
        userMonth[8] = "January"; //Belangerz
        userYear[8] = "2020";
        userMonth[9] = "June"; //Blacklight20
        userYear[9] = "2020";
        userMonth[10] = "March"; //Bodesoner
        userYear[10] = "2020";

        userMonth[11] = "February"; //Boxi_JJ
        userYear[11] = "2019";
        userMonth[12] = "July"; //caiiittt
        userYear[12] = "2019";
        userMonth[13] = "July"; //catpartyqueen
        userYear[13] = "2019";
        userMonth[14] = "November"; //Caydosity
        userYear[14] = "2019";
        userMonth[15] = "December"; //Clarice_Olivia
        userYear[15] = "2019";
        userMonth[16] = "January"; //cogginsnuff
        userYear[16] = "2020";
        userMonth[17] = "November"; //DedicatedDuck
        userYear[17] = "2019";
        userMonth[18] = "January"; //DeepCreamy
        userYear[18] = "2020";
        userMonth[19] = "January"; //desguisedskye 
        userYear[19] = "2020";
        userMonth[20] = "August"; //Drulps
        userYear[20] = "2019";

        userMonth[21] = "September"; //Dylchiz
        userYear[21] = "2019";
        userMonth[22] = "March"; //Enigma091
        userYear[22] = "2020";
        userMonth[23] = "December"; //Faked9
        userYear[23] = "2019";
        userMonth[24] = "December"; //frikkn_bot
        userYear[24] = "2019";
        userMonth[25] = "January"; //Goatyguy11
        userYear[25] = "2020";
        userMonth[26] = "November"; //HawkSager
        userYear[26] = "2019";
        userMonth[27] = "January"; //hippert
        userYear[27] = "2020";
        userMonth[28] = "December"; //Hozbomb
        userYear[28] = "2019";
        userMonth[29] = "September"; //HyphyAUS
        userYear[29] = "2019";
        userMonth[30] = "June"; //ikxrley
        userYear[30] = "2020";

        userMonth[31] = "January"; //ImpulseMills
        userYear[31] = "2020";
        userMonth[32] = "March"; //ImxFrosty
        userYear[32] = "2019";
        userMonth[33] = "April"; //its_hanhan29
        userYear[33] = "2020";
        userMonth[34] = "December"; //Jaiden_oce
        userYear[34] = "2019";
        userMonth[35] = "September"; //JaydenKable
        userYear[35] = "2019";
        userMonth[36] = "January"; //jodasparkles
        userYear[36] = "2020";
        userMonth[37] = "September"; //joshrvega
        userYear[37] = "2019";
        userMonth[38] = "March"; //JudgJudy
        userYear[38] = "2019";
        userMonth[39] = "February"; //KarmaaKen
        userYear[39] = "2020";
        userMonth[40] = "December"; //laurathestork
        userYear[40] = "2019";

        userMonth[41] = "January"; //LazyJax
        userYear[41] = "2020";
        userMonth[42] = "August"; //Mareil
        userYear[42] = "2019";
        userMonth[43] = "January"; //matt_blass012
        userYear[43] = "2020";
        userMonth[44] = "May"; //mattyjonesy45
        userYear[44] = "2019";
        userMonth[45] = "April"; //MAVOURNEE
        userYear[45] = "2019";
        userMonth[46] = "May"; //megzamo
        userYear[46] = "2020";
        userMonth[47] = "October"; //megzz_00
        userYear[47] = "2020";
        userMonth[48] = "October"; //meIamphetamine
        userYear[48] = "2019";
        userMonth[49] = "February"; //metro17
        userYear[49] = "2019";
        userMonth[50] = "June"; //mistry101
        userYear[50] = "2020";

        userMonth[51] = "January"; //MitchellAUS
        userYear[51] = "2020";
        userMonth[52] = "January"; //mrfliperic
        userYear[52] = "2020";
        userMonth[53] = "October"; //MrSweden
        userYear[53] = "2019";
        userMonth[54] = "September"; //nicholasbikolas
        userYear[54] = "2019";
        userMonth[55] = "October"; //NoonyAU
        userYear[55] = "2019";
        userMonth[56] = "October"; //NorahPerk
        userYear[56] = "2019";
        userMonth[57] = "September"; //NosAU
        userYear[57] = "2019";
        userMonth[58] = "February"; //NotCryptick
        userYear[58] = "2020";
        userMonth[59] = "July"; //onyi
        userYear[59] = "2019";
        userMonth[60] = "January"; //PatThePostMan_
        userYear[60] = "2020";

        userMonth[61] = "May"; //pebblesqt
        userYear[61] = "2019";
        userMonth[62] = "October"; //RageZV
        userYear[62] = "2018";
        userMonth[63] = "June"; //RicardoJ_E
        userYear[63] = "2020";
        userMonth[64] = "March"; //RickyBobby14
        userYear[64] = "2020";
        userMonth[65] = "January"; //samuel_armer
        userYear[65] = "2020";
        userMonth[66] = "May"; //Saxn
        userYear[66] = "2018";
        userMonth[67] = "April"; //SirYogiWan
        userYear[67] = "2020";
        userMonth[68] = "May"; //SmudgeyB
        userYear[68] = "2020";
        userMonth[69] = "January"; //Stickdoggg
        userYear[69] = "2019";
        userMonth[70] = "August"; //SUPERGOOSE5
        userYear[70] = "2019";

        userMonth[71] = "February"; //T0M0E_
        userYear[71] = "2020";
        userMonth[72] = "March"; //tg_rubi
        userYear[72] = "2020";
        userMonth[73] = "April"; //theLevitate
        userYear[73] = "2019";
        userMonth[74] = "April"; //TimTam779
        userYear[74] = "2019";
        userMonth[75] = "January"; //Trojan_Aus
        userYear[75] = "2020";
        userMonth[76] = "May"; //Twinkle_197
        userYear[76] = "2020";
        userMonth[77] = "November"; //upjade
        userYear[77] = "2019";
        userMonth[78] = "May"; //waitwhen
        userYear[78] = "2020";
        userMonth[79] = "January"; //Wings95_
        userYear[79] = "2020";
        userMonth[80] = "December"; //xxskittlesxx
        userYear[80] = "2019";

        userMonth[81] = "April"; //yuurnan
        userYear[81] = "2020";
        userMonth[82] = "December"; //AlsoCDP
        userYear[82] = "2019";
        userMonth[83] = "March"; //AxelDaxelAU
        userYear[83] = "2020";
        userMonth[84] = "June"; //Bert_mcsquirt
        userYear[84] = "2020";
        userMonth[85] = "March"; //emilylm0102
        userYear[85] = "2020";
        userMonth[86] = "April"; //hashtag_oreo
        userYear[86] = "2020";
        userMonth[87] = "May"; //JonoDash
        userYear[87] = "2020";
        userMonth[88] = "January"; //kidsbooksbydavid
        userYear[88] = "2020";
        userMonth[89] = "February"; //manavpurohit
        userYear[89] = "2020";
        userMonth[90] = "July"; //MotorPopcorn958
        userYear[90] = "2020";

        userMonth[91] = "July"; //nubgamer28
        userYear[91] = "2020";
        userMonth[92] = "May"; //OniS__
        userYear[92] = "2019";
        userMonth[93] = "May"; //solenebby
        userYear[93] = "2020";
        userMonth[94] = "September"; //Vishh1J
        userYear[94] = "2020";
        userMonth[95] = "August"; //xjazzmynn
        userYear[95] = "2020";
        userMonth[96] = "November"; //ZeeDodo
        userYear[96] = "2019";
        userMonth[97] = "January"; //Creamz
        userYear[97] = "2020";
        userMonth[98] = "May"; //Monkeyboy8008
        userYear[98] = "2020";
        userMonth[99] = "January"; //benno_15
        userYear[99] = "2020";
        userMonth[100] = "September"; //golden_log
        userYear[100] = "2020";


        livesRemaining = 10;

        do
        {
            for (int i = 0; i < 3; i++)
            {
                do
                {
                    pictureNum[i] = Random.Range(0, 100);
                } while (pictureNum[i] == 0);

                Debug.Log("Picture Number (" + i + ") = " + pictureNum[i]);
                Debug.Log("Picture Name (" + i + ") = " + names[pictureNum[i]]);
            }
        } while (pictureNum[0] == pictureNum[1] || pictureNum[0] == pictureNum[2] || pictureNum[1] == pictureNum[2]);

        if (Settings.suddenDeath == true)
        {
            timeRemaining = 60;
            timerIsRunning = true;
            Settings.suddenDeath = false;
        }

        guessingPlayerNum = 0;
        LogCurrentlyGuessing();

        Debug.Log("This person started following in " + currentMonth + ", " + currentYear + ".");
    }

    public void LogCurrentlyGuessing()
    {
        tileImage.sprite = pictures[pictureNum[guessingPlayerNum]];

        tileName.text = names[pictureNum[guessingPlayerNum]];

        WhenDid.text = "When did " + names[pictureNum[guessingPlayerNum]] + " start following 'brodie'?";

        // logs the random person's month as a number
        if (userMonth[pictureNum[guessingPlayerNum]] == "January")
        {
            currentMonth = 0;
        }
        else if (userMonth[pictureNum[guessingPlayerNum]] == "February")
        {
            currentMonth = 1;
        }
        else if (userMonth[pictureNum[guessingPlayerNum]] == "March")
        {
            currentMonth = 2;
        }
        else if (userMonth[pictureNum[guessingPlayerNum]] == "April")
        {
            currentMonth = 3;
        }
        else if (userMonth[pictureNum[guessingPlayerNum]] == "May")
        {
            currentMonth = 4;
        }
        else if (userMonth[pictureNum[guessingPlayerNum]] == "June")
        {
            currentMonth = 5;
        }
        else if (userMonth[pictureNum[guessingPlayerNum]] == "July")
        {
            currentMonth = 6;
        }
        else if (userMonth[pictureNum[guessingPlayerNum]] == "August")
        {
            currentMonth = 7;
        }
        else if (userMonth[pictureNum[guessingPlayerNum]] == "September")
        {
            currentMonth = 8;
        }
        else if (userMonth[pictureNum[guessingPlayerNum]] == "October")
        {
            currentMonth = 9;
        }
        else if (userMonth[pictureNum[guessingPlayerNum]] == "November")
        {
            currentMonth = 10;
        }
        else if (userMonth[pictureNum[guessingPlayerNum]] == "December")
        {
            currentMonth = 11;
        }

        // logs the random person's year as a number
        if (userYear[pictureNum[guessingPlayerNum]] == "2018")
        {
            currentYear = 0;
        }
        else if (userYear[pictureNum[guessingPlayerNum]] == "2019")
        {
            currentYear = 1;
        }
        else if (userYear[pictureNum[guessingPlayerNum]] == "2020")
        {
            currentYear = 2;
        }
        else if (userYear[pictureNum[guessingPlayerNum]] == "2021")
        {
            currentYear = 3;
        }
    }

    public void AddMistakes()
    {
        mistakes++;
        Settings.totalMistakesInHigherOrLower++;

        livesRemaining--;

        if (livesRemaining == 9)
        {
            allHearts.GetComponent<Animator>().SetTrigger("Killed Tenth Heart");
        }
        else if (livesRemaining == 8)
        {
            if (doubleMistake == true)
            {
                Invoke("NinthHeartDeath", 1f);
                doubleMistake = false;
            }
            else
            {
                allHearts.GetComponent<Animator>().SetTrigger("Killed Ninth Heart");
            }
        }
        else if (livesRemaining == 7)
        {
            if (doubleMistake == true)
            {
                Invoke("EighthHeartDeath", 1f);
                doubleMistake = false;
            }
            else
            {
                allHearts.GetComponent<Animator>().SetTrigger("Killed Eighth Heart");
            }
        }
        else if (livesRemaining == 6)
        {
            if (doubleMistake == true)
            {
                Invoke("SeventhHeartDeath", 1f);
                doubleMistake = false;
            }
            else
            {
                allHearts.GetComponent<Animator>().SetTrigger("Killed Seventh Heart");
            }
        }
        else if (livesRemaining == 5)
        {
            if (doubleMistake == true)
            {
                Invoke("SixthHeartDeath", 1f);
                doubleMistake = false;
            }
            else
            {
                allHearts.GetComponent<Animator>().SetTrigger("Killed Sixth Heart");
            }
        }
        else if (livesRemaining == 4)
        {
            if (doubleMistake == true)
            {
                Invoke("FifthHeartDeath", 1f);
                doubleMistake = false;
            }
            else
            {
                allHearts.GetComponent<Animator>().SetTrigger("Killed Fifth Heart");
            }
        }
        else if (livesRemaining == 3)
        {
            if (doubleMistake == true)
            {
                Invoke("FourthHeartDeath", 1f);
                doubleMistake = false;
            }
            else
            {
                allHearts.GetComponent<Animator>().SetTrigger("Killed Fourth Heart");
            }
        }
        else if (livesRemaining == 2)
        {
            if (doubleMistake == true)
            {
                Invoke("ThirdHeartDeath", 1f);
                doubleMistake = false;
            }
            else
            {
                allHearts.GetComponent<Animator>().SetTrigger("Killed Third Heart");
            }
        }
        else if (livesRemaining == 1)
        {
            if (doubleMistake == true)
            {
                Invoke("SecondHeartDeath", 1f);
                doubleMistake = false;
            }
            else
            {
                allHearts.GetComponent<Animator>().SetTrigger("Killed Second Heart");
            }
        }
        else if (livesRemaining <= 0)
        {
            if (doubleMistake == true)
            {
                Invoke("FirstHeartDeath", 1f);
                doubleMistake = false;
            }
            else
            {
                allHearts.GetComponent<Animator>().SetTrigger("Killed First Heart");
            }

            Debug.Log("You Lose :(");
            gameEnded = true;

            for (int i = 0; i < 22; i++)
            {
                disappearThings[i].SetActive(false);
            }

            tileGameObject.GetComponent<Animator>().SetTrigger("Disappear Tile");

            Settings.totalHigherOrLowerRegularEasyLosses++;

            randomEndScreen = Random.Range(0, 4);
            EndScreens[randomEndScreen].SetActive(true);
        }
    }

    public void AddMatches()
    {
        matches++;
        Settings.totalMatchesInHigherOrLower++;

        if (matchBool[0] == true && matchBool[1] == true && matchBool[2] == true)
        {
            Settings.totalHigherOrLowerRegularEasyWins++;
        }
    }

    public void Update()
    {
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
                SDAddMistakes();
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }

        matchesText.text = "Matches: " + matches.ToString() + " / 3";

        if (matchBool[0] == true && matchBool[1] == true && matchBool[2] == true)
        {
            matchBool[0] = false;
            matchBool[1] = false;
            matchBool[2] = false;

            for (int i = 0; i < 22; i++)
            {
                disappearThings[i].SetActive(false);
            }

            tileGameObject.GetComponent<Animator>().SetTrigger("Disappear Tile");

            winScreen.SetActive(true);
        }
    }

    public void GuessButton()
    {
        Debug.Log("Chosen month is " + monthDropdown.value);
        Debug.Log("Chosen year is " + yearDropdown.value);

        chosenMonth = monthDropdown.value;
        chosenYear = yearDropdown.value;
        monthTitle.SetActive(true);
        yearTitle.SetActive(true);

        // if the month chosen by the user matches the follower age month, then disable the month dropdown
        if (chosenMonth == currentMonth)
        {
            monthDropdown.interactable = false;
            monthHigher.SetActive(false);
            monthLower.SetActive(false);
            monthLocked.SetActive(true);
        }

        // if the year chosen by the user matches the follower age year, then disable the year dropdown
        if (chosenYear == currentYear)
        {
            yearDropdown.interactable = false;
            yearHigher.SetActive(false);
            yearLower.SetActive(false);
            yearLocked.SetActive(true);
        }

        if (chosenMonth < currentMonth)
        {
            monthHigher.SetActive(true);
            monthLower.SetActive(false);
            singleMistake = true;
            AddMistakes();
        }
        else if (chosenMonth > currentMonth)
        {
            monthHigher.SetActive(false);
            monthLower.SetActive(true);
            singleMistake = true;
            AddMistakes();
        }

        if (gameEnded == false)
        {
            if (chosenYear < currentYear)
            {
                yearHigher.SetActive(true);
                yearLower.SetActive(false);

                if (singleMistake == true)
                {
                    doubleMistake = true;
                    singleMistake = false;
                }
                AddMistakes();
            }
            else if (chosenYear > currentYear)
            {
                yearHigher.SetActive(false);
                yearLower.SetActive(true);

                if (singleMistake == true)
                {
                    doubleMistake = true;
                    singleMistake = false;
                }
                AddMistakes();
            }
        }

        // if both of the guesses are correct, then add matches
        if (monthDropdown.interactable == false && yearDropdown.interactable == false)
        {

            Debug.Log("You guessed the month and year correctly!");

            monthHigher.SetActive(false);
            monthLower.SetActive(false);
            yearHigher.SetActive(false);
            yearLower.SetActive(false);
            monthLocked.SetActive(false);
            yearLocked.SetActive(false);
            monthTitle.SetActive(false);
            yearTitle.SetActive(false);

            monthDropdown.interactable = true;
            yearDropdown.interactable = true;

            if (matchBool[0] == false)
            {
                matchBool[0] = true;
                guessingPlayerNum = 1;
                tileGameObject.GetComponent<Animator>().SetTrigger("Remove Pic and Name");
                Invoke("DoTheLog", 0.3f);
            }
            else if (matchBool[0] == true && matchBool[1] == false)
            {
                matchBool[1] = true;
                guessingPlayerNum = 2;
                tileGameObject.GetComponent<Animator>().SetTrigger("Remove Pic and Name");
                Invoke("DoTheLog", 0.3f);
            }
            else if (matchBool[1] == true && matchBool[2] == false)
            {
                matchBool[2] = true;
            }

            AddMatches();
        }

        if (chosenMonth == 0)
        {
            previousMonth.text = "January";
        }
        else if (chosenMonth == 1)
        {
            previousMonth.text = "February";
        }
        else if (chosenMonth == 2)
        {
            previousMonth.text = "March";
        }
        else if (chosenMonth == 3)
        {
            previousMonth.text = "April";
        }
        else if (chosenMonth == 4)
        {
            previousMonth.text = "May";
        }
        else if (chosenMonth == 5)
        {
            previousMonth.text = "June";
        }
        else if (chosenMonth == 6)
        {
            previousMonth.text = "July";
        }
        else if (chosenMonth == 7)
        {
            previousMonth.text = "August";
        }
        else if (chosenMonth == 8)
        {
            previousMonth.text = "September";
        }
        else if (chosenMonth == 9)
        {
            previousMonth.text = "October";
        }
        else if (chosenMonth == 10)
        {
            previousMonth.text = "November";
        }
        else if (chosenMonth == 11)
        {
            previousMonth.text = "December";
        }

        if (chosenYear == 0)
        {
            previousYear.text = "2018";
        }
        else if (chosenYear == 1)
        {
            previousYear.text = "2019";
        }
        else if (chosenYear == 2)
        {
            previousYear.text = "2020";
        }
        else if (chosenYear == 3)
        {
            previousYear.text = "2021";
        }
    }

    public void NinthHeartDeath()
    {
        allHearts.GetComponent<Animator>().SetTrigger("Killed Ninth Heart");
    }

    public void EighthHeartDeath()
    {
        allHearts.GetComponent<Animator>().SetTrigger("Killed Eighth Heart");
    }

    public void SeventhHeartDeath()
    {
        allHearts.GetComponent<Animator>().SetTrigger("Killed Seventh Heart");
    }

    public void SixthHeartDeath()
    {
        allHearts.GetComponent<Animator>().SetTrigger("Killed Sixth Heart");
    }

    public void FifthHeartDeath()
    {
        allHearts.GetComponent<Animator>().SetTrigger("Killed Fifth Heart");
    }

    public void FourthHeartDeath()
    {
        allHearts.GetComponent<Animator>().SetTrigger("Killed Fourth Heart");
    }

    public void ThirdHeartDeath()
    {
        allHearts.GetComponent<Animator>().SetTrigger("Killed Third Heart");
    }

    public void SecondHeartDeath()
    {
        allHearts.GetComponent<Animator>().SetTrigger("Killed Second Heart");
    }

    public void FirstHeartDeath()
    {
        allHearts.GetComponent<Animator>().SetTrigger("Killed First Heart");
    }

    public void DoTheLog()
    {
        LogCurrentlyGuessing();
    }

    public void DebugTest()
    {
        Debug.Log("Matches = " + matches);
        Debug.Log("Mistakes = " + mistakes);
        Debug.Log("Match 1 = " + matchBool[0] + ". Match 2 = " + matchBool[1] + ". Match 3 = " + matchBool[2] + ".");
        Debug.Log("-------------------------------------------------");
    }



    // SUDDEN DEATH --------------------------------- SUDDEN DEATH  --------------------------------- SUDDEN DEATH --------------------------------- SUDDEN DEATH
    // SUDDEN DEATH --------------------------------- SUDDEN DEATH  --------------------------------- SUDDEN DEATH --------------------------------- SUDDEN DEATH
    // SUDDEN DEATH --------------------------------- SUDDEN DEATH  --------------------------------- SUDDEN DEATH --------------------------------- SUDDEN DEATH

    public void SDAddMistakes()
    {
        Settings.totalMistakesInHigherOrLower++;
        Settings.totalHigherOrLowerSuddenDeathEasyLosses++;

        Debug.Log("You Lose :(");
        gameEnded = true;
        timerIsRunning = false;

        for (int i = 0; i < 22; i++)
        {
            disappearThings[i].SetActive(false);
        }

        tileGameObject.GetComponent<Animator>().SetTrigger("Disappear Tile");

        randomEndScreen = Random.Range(0, 4);
        EndScreens[randomEndScreen].SetActive(true);
    }

    public void SDAddMatches()
    {
        matches++;
        Settings.totalMatchesInHigherOrLower++;

        if (matchBool[0] == true && matchBool[1] == true && matchBool[2] == true)
        {
            Settings.totalHigherOrLowerSuddenDeathEasyWins++;
            timerIsRunning = false;
            Debug.Log("you have won!");
        }
    }

    public void SDGuessButton()
    {
        Debug.Log("Chosen month is " + monthDropdown.value);
        Debug.Log("Chosen year is " + yearDropdown.value);

        chosenMonth = monthDropdown.value;
        chosenYear = yearDropdown.value;
        monthTitle.SetActive(true);
        yearTitle.SetActive(true);

        // if the month chosen by the user matches the follower age month, then disable the month dropdown
        if (chosenMonth == currentMonth)
        {
            monthDropdown.interactable = false;
            monthHigher.SetActive(false);
            monthLower.SetActive(false);
            monthLocked.SetActive(true);
        }

        // if the year chosen by the user matches the follower age year, then disable the year dropdown
        if (chosenYear == currentYear)
        {
            yearDropdown.interactable = false;
            yearHigher.SetActive(false);
            yearLower.SetActive(false);
            yearLocked.SetActive(true);
        }

        if (chosenMonth < currentMonth)
        {
            monthHigher.SetActive(true);
            monthLower.SetActive(false);
            singleMistake = true;
            SDAddMistakes();
        }
        else if (chosenMonth > currentMonth)
        {
            monthHigher.SetActive(false);
            monthLower.SetActive(true);
            singleMistake = true;
            SDAddMistakes();
        }
        else if (chosenYear < currentYear)
        {
            yearHigher.SetActive(true);
            yearLower.SetActive(false);
            SDAddMistakes();
        }
        else if (chosenYear > currentYear)
        {
            yearHigher.SetActive(false);
            yearLower.SetActive(true);
            SDAddMistakes();
        }


        // if both of the guesses are correct, then add matches
        if (monthDropdown.interactable == false && yearDropdown.interactable == false)
        {

            Debug.Log("You guessed the month and year correctly!");

            monthHigher.SetActive(false);
            monthLower.SetActive(false);
            yearHigher.SetActive(false);
            yearLower.SetActive(false);
            monthLocked.SetActive(false);
            yearLocked.SetActive(false);
            monthTitle.SetActive(false);
            yearTitle.SetActive(false);

            monthDropdown.interactable = true;
            yearDropdown.interactable = true;

            if (matchBool[0] == false)
            {
                matchBool[0] = true;
                guessingPlayerNum = 1;
                tileGameObject.GetComponent<Animator>().SetTrigger("Remove Pic and Name");
                Invoke("DoTheLog", 0.3f);
            }
            else if (matchBool[0] == true && matchBool[1] == false)
            {
                matchBool[1] = true;
                guessingPlayerNum = 2;
                tileGameObject.GetComponent<Animator>().SetTrigger("Remove Pic and Name");
                Invoke("DoTheLog", 0.3f);
            }
            else if (matchBool[1] == true && matchBool[2] == false)
            {
                matchBool[2] = true;
                timerIsRunning = false;
            }
            SDAddMatches();
        }

        if (chosenMonth == 0)
        {
            previousMonth.text = "January";
        }
        else if (chosenMonth == 1)
        {
            previousMonth.text = "February";
        }
        else if (chosenMonth == 2)
        {
            previousMonth.text = "March";
        }
        else if (chosenMonth == 3)
        {
            previousMonth.text = "April";
        }
        else if (chosenMonth == 4)
        {
            previousMonth.text = "May";
        }
        else if (chosenMonth == 5)
        {
            previousMonth.text = "June";
        }
        else if (chosenMonth == 6)
        {
            previousMonth.text = "July";
        }
        else if (chosenMonth == 7)
        {
            previousMonth.text = "August";
        }
        else if (chosenMonth == 8)
        {
            previousMonth.text = "September";
        }
        else if (chosenMonth == 9)
        {
            previousMonth.text = "October";
        }
        else if (chosenMonth == 10)
        {
            previousMonth.text = "November";
        }
        else if (chosenMonth == 11)
        {
            previousMonth.text = "December";
        }

        if (chosenYear == 0)
        {
            previousYear.text = "2018";
        }
        else if (chosenYear == 1)
        {
            previousYear.text = "2019";
        }
        else if (chosenYear == 2)
        {
            previousYear.text = "2020";
        }
        else if (chosenYear == 3)
        {
            previousYear.text = "2021";
        }
    }
}