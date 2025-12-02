using UnityEngine;

public class TutorialStarter : MonoBehaviour
{
    public BlinkManager_External blinkManager; // arraste no Inspector

    void Start()
    {
        blinkManager.LoadListAndBlink();
    }
}
