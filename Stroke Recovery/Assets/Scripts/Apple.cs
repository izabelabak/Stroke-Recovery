using UnityEngine;

public class Apple : MonoBehaviour {
    public Canvas AppleInfo; //Podpowiedź pojawiająca się po najechaniu na łóżko, że można wykonać zadanie
    public Canvas GameMathQuiz;//Gra z dokończeniem przysłów

    void Start()
    {
        AppleInfo = AppleInfo.GetComponent<Canvas>();
        AppleInfo.enabled = false;
        GameMathQuiz = GameMathQuiz.GetComponent<Canvas>();
        GameMathQuiz.enabled = false;
    }

    public void OnMouseEnter()
    {
        AppleInfo.enabled = true;//aktywujemy podpowiedź po najechaniu kursorem na łóżko
        if (GameMathQuiz.enabled == true)
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
        GameMathQuiz.enabled = true;//wyświetlamy naszą grę
        AppleInfo.enabled = false;//chowamy podpowiedź
    }

    public void ExitCanva()
    {
        GameMathQuiz.enabled = false;
        AppleInfo.enabled = false;
    }
}
