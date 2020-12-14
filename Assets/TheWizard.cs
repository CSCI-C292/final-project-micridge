using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWizard : MonoBehaviour
{

    [SerializeField] Dialogue _dialogue;
    [SerializeField] Dialogue _dialogueComplete;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D()
    {
        GameEvents.InvokeDialogInitiated(_dialogue);
    }

    void OnTriggerExit2D()
    {
        GameEvents.InvokeDialogFinished();
    }
}
