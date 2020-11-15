using System;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InkScript2 : MonoBehaviour
{

    public GameObject dialogPanel;
    public GameObject buttonPanel;
    public TextAsset inkJSON;
    public Story story;
   // public Text textPrefab;
    public Button buttonPrefab;
    List<string> tags;
    public bool continuing = false;
    private EventSystem es;
    public Text textPanel; 


    // Start is called before the first frame update
    public void Start()
    {
        story = new Story(inkJSON.text);
        // refreshUI();
        dialogPanel = this.transform.GetChild(0).gameObject;
        buttonPanel = dialogPanel.transform.GetChild(0).gameObject;
        dialogPanel.SetActive(false);
        es = GameObject.Find("EventSystem").GetComponent<EventSystem>();
    }


    public void refreshStory()
    {
        story = new Story(inkJSON.text);
    }


    public void refreshUI()
    {

        if (story.currentChoices.Count < 1)
        {
            eraseUI();
        }

        if (story.canContinue == true)
        {
          //  Text storyText = Instantiate(textPrefab) as Text;

            string text = loadStoryChunk();

            List<string> tags = story.currentTags;

            textPanel.text = text;
         

            foreach (Choice choice in story.currentChoices)
            {
                Button choiceButton = Instantiate(buttonPrefab) as Button;
                Text choiceText = choiceButton.GetComponentInChildren<Text>();
                choiceText.text = choice.text;
                choiceButton.transform.SetParent(buttonPanel.transform, false);
                es.firstSelectedGameObject = choiceButton.gameObject;
                choiceButton.onClick.AddListener(delegate
                {
                    chooseStoryChoice(choice);
                });
            }

        }

        if (story.canContinue == false)
        {
            loadStoryChunk();
        }
    }


    internal bool canContinue(bool v)
    {
        throw new NotImplementedException();
    }



    public void eraseUI()
    {
        textPanel.text = "";
        /*
        if (dialogPanel.transform.childCount > 0)
        {
            for (int i = 0; i < dialogPanel.transform.childCount; i++)
            {
                GameObject obj = dialogPanel.transform.GetChild(i).gameObject;
                if (obj.GetComponent<Text>() != null)
                {
                    Destroy(dialogPanel.transform.GetChild(i).gameObject);
                }
            }
        }
        */
        /*
        if (buttonPanel.transform.childCount > 0)
        {
            for (int i = 0; i < buttonPanel.transform.childCount; i++)
            {
                Destroy(buttonPanel.transform.GetChild(i).gameObject);
            }
        }
        */
    }


    void chooseStoryChoice(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        refreshUI();
    }


    public void HidePanels()
    {
        dialogPanel.SetActive(false);
    }


    public void ShowPanels()
    {
        dialogPanel.SetActive(true);
    }


    string loadStoryChunk()
    {
        string text = "";

        if (story.canContinue)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().Freeze();
            text = story.Continue();
        }

        else if (story.currentChoices.Count > 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().Freeze();
        }

        else
        {
            //i unfreeze the character elsewhere in other scripts related to the interaction now
            //but i'm keeping this here just in case i need a reminder/for posterity
            // GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().UnFreeze();
            Debug.Log("unfreezed");
        }

        return text;
    }


    public void ContinueBool()
    {
        if (story.canContinue)
        {
            continuing = true;
        }
        else
        {
            continuing = false;
        }
    }
}