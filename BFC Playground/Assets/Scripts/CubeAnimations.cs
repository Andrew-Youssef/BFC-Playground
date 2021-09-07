using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class CubeAnimations : MonoBehaviour
{
    public GameObject cube;
    public GameObject memoryButton;
    public GameObject nameGButton;
    public GameObject proPicGButton;
    public GameObject hOrLButton;
    public Button leftArrow;
    public Button rightArrrow;
    int currentFace;

    public void Start()
    {
        currentFace = 1;
    }

    public void LeftArrowPressed()
    {
        if(currentFace == 1)
        {
            memoryButton.SetActive(false);
            leftArrow.interactable = false;
            rightArrrow.interactable = false;
            cube.GetComponent<Animator>().SetTrigger("Memory turn to H or L");
            Invoke("ShowHOrLButton", 0.5f);
            currentFace = 4;
        }
        else if (currentFace == 2)
        {
            nameGButton.SetActive(false);
            leftArrow.interactable = false;
            rightArrrow.interactable = false;
            cube.GetComponent<Animator>().SetTrigger("Name G turn to Memory");
            Invoke("ShowMemoryButton", 0.5f);
            currentFace = 1;
        }
        else if (currentFace == 3)
        {
            proPicGButton.SetActive(false);
            leftArrow.interactable = false;
            rightArrrow.interactable = false;
            cube.GetComponent<Animator>().SetTrigger("Pro Pic G turn to Name G");
            Invoke("ShowNameGButton", 0.5f);
            currentFace = 2;
        }
        else if (currentFace == 4)
        {
            hOrLButton.SetActive(false);
            leftArrow.interactable = false;
            rightArrrow.interactable = false;
            cube.GetComponent<Animator>().SetTrigger("H or L turn to Pro Pic G");
            Invoke("ShowProPicGButton", 0.5f);
            currentFace = 3;
        }
    }

    public void RightArrowPressed()
    {
        if (currentFace == 1)
        {
            memoryButton.SetActive(false);
            leftArrow.interactable = false;
            rightArrrow.interactable = false;
            cube.GetComponent<Animator>().SetTrigger("Memory turn to Name G");
            Invoke("ShowNameGButton", 0.5f);
            currentFace = 2;
        }
        else if (currentFace == 2)
        {
            nameGButton.SetActive(false);
            leftArrow.interactable = false;
            rightArrrow.interactable = false;
            cube.GetComponent<Animator>().SetTrigger("Name G turn to Pro Pic G");
            Invoke("ShowProPicGButton", 0.5f);
            currentFace = 3;
        }
        else if (currentFace == 3)
        {
            proPicGButton.SetActive(false);
            leftArrow.interactable = false;
            rightArrrow.interactable = false;
            cube.GetComponent<Animator>().SetTrigger("Pro Pic G turn to H or L");
            Invoke("ShowHOrLButton", 0.5f);
            currentFace = 4;
        }
        else if (currentFace == 4)
        {
            hOrLButton.SetActive(false);
            leftArrow.interactable = false;
            rightArrrow.interactable = false;
            cube.GetComponent<Animator>().SetTrigger("H or L turn to Memory");
            Invoke("ShowMemoryButton", 0.5f);
            currentFace = 1;
        }
    }

    public void ShowMemoryButton()
    {
        memoryButton.SetActive(true);
        leftArrow.interactable = true;
        rightArrrow.interactable = true;
    }

    public void ShowNameGButton()
    {
        nameGButton.SetActive(true);
        leftArrow.interactable = true;
        rightArrrow.interactable = true;
    }

    public void ShowProPicGButton()
    {
        proPicGButton.SetActive(true);
        leftArrow.interactable = true;
        rightArrrow.interactable = true;
    }

    public void ShowHOrLButton()
    {
        hOrLButton.SetActive(true);
        leftArrow.interactable = true;
        rightArrrow.interactable = true;
    }

    public void DisappearFromMemory()
    {
        cube.GetComponent<Animator>().SetTrigger("Disappear from Memory");
    }

    public void DisappearFromHOrL()
    {
        cube.GetComponent<Animator>().SetTrigger("Disappear from H or L");
    }

    public void DisappearFromNG()
    {
        cube.GetComponent<Animator>().SetTrigger("Disappear from N G");
    }

    public void DisappearFromPPG()
    {
        cube.GetComponent<Animator>().SetTrigger("Disappear from P P G");
    }
}