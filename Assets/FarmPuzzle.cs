using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmPuzzle : MonoBehaviour
{
    [SerializeField] Dialogue _dialogue;
    [SerializeField] Dialogue _dialogueComplete;
    ArrayList plotList = new ArrayList();
    // Start is called before the first frame update
    void Start()
    {
        plotList.Add("");
        plotList.Add("");
        plotList.Add("");
        plotList.Add("");
    }

    // Update is called once per frame
    void Update()
    {
        plotList[0] = this.gameObject.transform.GetChild(1).gameObject.name;
        plotList[1] = this.gameObject.transform.GetChild(2).gameObject.name;
        plotList[2] = this.gameObject.transform.GetChild(3).gameObject.name;
        plotList[3] = this.gameObject.transform.GetChild(4).gameObject.name;
        if(plotList.Contains("cheese") && plotList.Contains("water") && plotList.Contains("wheat") && plotList.Contains("tomato")) {
            GameState.Instance.CompleteFarm();
            GameObject fenceObj = transform.Find("Fence").gameObject;
            Destroy(fenceObj);
        }
    }

    void OnTriggerEnter2D()
    {
        if(GameState.Instance.IsComplete() == false) {
            GameEvents.InvokeDialogInitiated(_dialogue);
        }
        else {
            GameEvents.InvokeDialogInitiated(_dialogueComplete);
        }
    }

    void OnTriggerExit2D()
    {
        GameEvents.InvokeDialogFinished();
    }
}

