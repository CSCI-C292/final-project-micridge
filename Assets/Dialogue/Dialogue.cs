using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Dialogue")]

public class Dialogue : ScriptableObject
{
    public string[] DialogSlides;
    public string option1;
    public string option2;
    public Dialogue nextDialog1;
    public Dialogue nextDialog2;
}
