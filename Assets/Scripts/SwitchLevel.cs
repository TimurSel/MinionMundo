using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLevel : MonoBehaviour
{
    [Header("Animator")]
    public Animator animator;

    [Header("Levels")]
    public GameObject Office;
    public GameObject Head;
    public GameObject Factory;

    [Header("AI")]
    public GameObject OfficeAI;
    public GameObject HeadAI;
    public GameObject FactoryAI;

    [Header("Buttons")]
    public GameObject GoUp_button;
    public GameObject GoDown_button;

    [Header("Audio")]
    public AudioSource ASource;
    public AudioClip Transition;

    int levelSelector;

    private void Start()
    {
        levelSelector = 2;
    }

    void Update()
    {
        Debug.Log(levelSelector);
        if (Input.GetKeyDown("1"))
        {
            //Factory
            FadeToLevel();
            levelSelector = 1;
        }

        if (Input.GetKeyDown("2"))
        {
            //Office
            FadeToLevel();
            levelSelector = 2;
        }

        if (Input.GetKeyDown("3"))
        {
            //Head
            FadeToLevel();
            levelSelector = 3;
        }
    }

    public void FadeToLevel()
    {
        animator.SetBool("Switchlevel", true);
        GoUp_button.SetActive(false);
        GoDown_button.SetActive(false);    
    }

    public void OnFadeComplete()
    {
        ASource.PlayOneShot(Transition);
        GoUp_button.SetActive(true);
        GoDown_button.SetActive(true);

        Debug.Log("yo uh hitler haha");
        if (levelSelector == 1)
        {
            //Level
            Factory.SetActive(true);
            Office.SetActive(false);
            Head.SetActive(false);

            //AI
            FactoryAI.SetActive(true);
            OfficeAI.SetActive(false);
            HeadAI.SetActive(false);
        }
        if (levelSelector == 2)
        {
            //Level
            Factory.SetActive(false);
            Office.SetActive(true);
            Head.SetActive(false);

            //AI
            FactoryAI.SetActive(false);
            OfficeAI.SetActive(true);
            HeadAI.SetActive(false);

        }
        if (levelSelector == 3)
        {
            //Level
            Factory.SetActive(false);
            Office.SetActive(false);
            Head.SetActive(true);

            //AI
            FactoryAI.SetActive(false);
            OfficeAI.SetActive(false);
            HeadAI.SetActive(true);
        }
    }

    public void GoUp()
    {
        if(levelSelector < 3)
        {
            levelSelector += 1;
            FadeToLevel();
          
        }    
    }

    public void GoDown()
    {
        if(levelSelector > 1)
        {
            levelSelector -= 1;
            FadeToLevel();
           
        }        
    }

    public void ResetAnimation()
    {
        Debug.Log("RESEST IT SLUT");
        animator.SetBool("Switchlevel", false);
    }
}
