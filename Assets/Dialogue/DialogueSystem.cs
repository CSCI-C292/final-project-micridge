using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class DialogueSystem : MonoBehaviour
{
    Dialogue _currentDialogue;
    int _currentSlideIndex = 0;

    void Awake()
    {
        GameEvents.DialogFinished += OnDialogFinished;
        GameEvents.DialogInitiated += OnDialogInitiated;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            if (_currentSlideIndex < _currentDialogue.DialogSlides.Length - 1) {
                _currentSlideIndex++;
                ShowSlide();
            }
            else if (_currentSlideIndex == _currentDialogue.DialogSlides.Length - 1) {
                GameEvents.InvokeDialogFinished();
                GameEvents.InvokeDialogInitiated(_currentDialogue.nextDialog1);
            }
        }
        else if(Input.GetMouseButtonDown(1)){
            if(_currentSlideIndex == _currentDialogue.DialogSlides.Length - 1){
                GameEvents.InvokeDialogFinished();
                GameEvents.InvokeDialogInitiated(_currentDialogue.nextDialog2);  
            }
        }
    }

    void OnDialogInitiated(object sender, DialogueEventArgs args)
    {
        _currentDialogue = args.dialoguePayload;
        _currentSlideIndex = 0;
        ShowSlide();
        GetComponent<Canvas>().enabled = true;
    }

    void OnDialogFinished(object sender, EventArgs args)
    {
        GetComponent<Canvas>().enabled = false;
    }

    void ShowSlide()
    {
        GameObject textObj = transform.Find("DialogText").gameObject;
        TextMeshProUGUI textComponent = textObj.GetComponent<TextMeshProUGUI>();
        textComponent.text = _currentDialogue.DialogSlides[_currentSlideIndex];
        if (_currentSlideIndex == _currentDialogue.DialogSlides.Length - 1) {
            GameObject textObj1 = transform.Find("DialogChoice1").gameObject;
            TextMeshProUGUI textComponent1 = textObj1.GetComponent<TextMeshProUGUI>();
            textComponent1.text = _currentDialogue.option1;
            GameObject textObj2 = transform.Find("DialogChoice2").gameObject;
            TextMeshProUGUI textComponent2 = textObj2.GetComponent<TextMeshProUGUI>();
            textComponent2.text = _currentDialogue.option2;
        }
        else {
            GameObject textObj1 = transform.Find("DialogChoice1").gameObject;
            TextMeshProUGUI textComponent1 = textObj1.GetComponent<TextMeshProUGUI>();
            textComponent1.text = null;
            GameObject textObj2 = transform.Find("DialogChoice2").gameObject;
            TextMeshProUGUI textComponent2 = textObj2.GetComponent<TextMeshProUGUI>();
            textComponent2.text = null;
        }
        
    }

}