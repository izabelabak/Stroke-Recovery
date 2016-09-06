using UnityEngine;
using System.Collections;

public class TimerEnd : MonoBehaviour {
    void OnTriggerEnter(Collider other)
    {
        GameObject.Find("Remy").SendMessage("Finished");
    }
}
