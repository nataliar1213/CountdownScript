using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityMeter : MonoBehaviour
{
    public static int sanityLevel = 2;
    public Canvas mainCanvas;

    // Start is called before the first frame update
    void Start()
    {
        SanityDisplayer();
        InvokeRepeating("Sanity", 10f, 10f);
    }


    void SanityDisplayer()
    {
        //Find the object you're looking for
        GameObject tempObject = GameObject.Find("mainCanvas");
        if (tempObject != null)
        {
            //If we found the object , get the Canvas component from it.
            mainCanvas = tempObject.GetComponent<Canvas>();
            if (mainCanvas == null)
            {
                Debug.Log("Could not locate Canvas component on " + tempObject.name);
            }
        }

        Text[] displaySanity;

        displaySanity = mainCanvas.GetComponentsInChildren<Text>();

        displaySanity[0].text = "Sanity: " + sanityLevel;
    }

    // Update is called once per frame
    void Update()
    {
        if (sanityLevel == 0)
        {
            print("LETS LOAD DEATH SCREEN");
        }
    }

    void Sanity()
    {
        sanityLevel--;
        SanityDisplayer();
        if (sanityLevel == 0)
        {
            CancelInvoke();
            print("YOU HAVE DIED!!!");
        }
    }
}
