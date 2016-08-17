using UnityEngine;

public class Apple : MonoBehaviour {
    public Canvas AppleInfo; //Podpowiedź pojawiająca się po najechaniu na łóżko, że można wykonać zadanie
    public Canvas GameSentence;//Gra z dokończeniem przysłów

    void Start()
    {
        AppleInfo = AppleInfo.GetComponent<Canvas>();
        AppleInfo.enabled = false;
        GameSentence = GameSentence.GetComponent<Canvas>();
        GameSentence.enabled = false;
    }

    public void OnMouseEnter()
    {
        AppleInfo.enabled = true;//aktywujemy podpowiedź po najechaniu kursorem na łóżko
        if (GameSentence.enabled == true)
        {
            AppleInfo.enabled = false;
        }
    }

    public void OnMouseExit()
    {
        AppleInfo.enabled = false;//chowamy podpowiedź gdy kursor zjedzie z łóżka
    }

    public void OnMouseUp()
    {
        GameSentence.enabled = true;//wyświetlamy naszą grę
        AppleInfo.enabled = false;//chowamy podpowiedź
    }

    public void ExitCanva()
    {
        GameSentence.enabled = false;
        AppleInfo.enabled = false;
    }
}
