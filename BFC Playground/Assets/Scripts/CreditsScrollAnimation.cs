using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsScrollAnimation : MonoBehaviour
{
    public GameObject sceneManager;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("TriggerBackToStart", 107f);
    }

    public void TriggerBackToStart()
    {
        sceneManager.GetComponent<SceneMovement>().BackToStart();
    }
}
