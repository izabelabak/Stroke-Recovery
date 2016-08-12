using UnityEngine;
using System.Collections;

public class Bed : MonoBehaviour {
    public Canvas BedInfo; //Podpowiedź pojawiająca się po najechaniu na łóżko, że można wykonać zadanie
    public bool IsComplete;
    public Canvas GameSentence;//Gra z dokończeniem przysłów

	void Start () {
        BedInfo = BedInfo.GetComponent<Canvas>();
        BedInfo.enabled = false;
        GameSentence = GameSentence.GetComponent<Canvas>();
        GameSentence.enabled = false;
	
	}
	
	void Update () {
	
	}

    public void OnMouseEnter()
    {
        BedInfo.enabled = true;//aktywujemy podpowiedź po najechaniu kursorem na łóżko
        if (GameSentence.enabled == true)
        {
            BedInfo.enabled = false;
        }
    }

    public void OnMouseExit()
    {
        BedInfo.enabled = false;//chowamy podpowiedź gdy kursor zjedzie z łóżka
    }

    public void OnMouseUp()
    {
        GameSentence.enabled = true;//wyświetlamy naszą grę
        BedInfo.enabled = false;//chowamy podpowiedź
    }

    public void ExitCanva()
    {
        GameSentence.enabled = false;
        BedInfo.enabled = false;
    }
}
