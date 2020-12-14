using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppetPuzzle : MonoBehaviour
{
    bool playerNear = false;
    int puppetBegin = 0;
    int eduScore = 0;
    static int eduGoal = 216;
    [SerializeField] Dialogue _dialogue;
    [SerializeField] Dialogue _dialogueComplete;
    [SerializeField] Dialogue _goodDialogue;
    [SerializeField] Dialogue _badDialogue;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerNear) {
            if(Input.GetMouseButtonDown(0)){
                puppetBegin++;
                if(puppetBegin >= 9 && puppetBegin < 27){
                    eduScore = eduScore + 1;
                } 
            }
            else if(Input.GetMouseButtonDown(1)){
                puppetBegin++;
                if(puppetBegin >= 9 && puppetBegin < 26){
                   eduScore = eduScore + 100; 
                }
            }
            if(puppetBegin >= 26){
                if(eduScore == eduGoal){
                    GameEvents.InvokeDialogInitiated(_goodDialogue);
                    GameState.Instance.CompleteEducation();
                    GameObject schoolFenceObj = transform.Find("SchoolFence").gameObject;
                    Destroy(schoolFenceObj);
                }
                else{
                    GameEvents.InvokeDialogInitiated(_badDialogue);
                }
            }
        }
    }

    void OnTriggerEnter2D()
    {
        playerNear = true;
        if(GameState.Instance.SuccessfulEducation() == false) {
            GameEvents.InvokeDialogInitiated(_dialogue);
        }
        else {
            GameEvents.InvokeDialogInitiated(_dialogueComplete);
        }
    }

    void OnTriggerExit2D()
    {
        playerNear = false;
        GameEvents.InvokeDialogFinished();
        eduScore = 0;
        puppetBegin = 0;
    }
}
