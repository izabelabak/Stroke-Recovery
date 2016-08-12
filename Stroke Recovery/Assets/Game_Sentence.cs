using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class Game_Sentence : MonoBehaviour {
    public Question[] questions;//tablica z pytaniami, pytania dodajemy w Unity
    public static List<Question> unansweredQuestions;

    private Question currentQuestion;
    
    public Text txtSentence;
    public Text txtAnswerA;
    public Text txtAnswerB;
    public Text txtAnswerC;
    public Text txtAnswerD;

    private string clickedAnswer;

    public Button NextSentence;
    public Image GoodAnswer;
    public Image WrongAnswer;

    void Start ()
    {
        GoodAnswer = GoodAnswer.GetComponent<Image>();
        GoodAnswer.enabled = false;
        WrongAnswer = WrongAnswer.GetComponent<Image>();
        WrongAnswer.enabled = false;
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)//sprawdzamy czy mamy jeszcze pytania do odpowiedzenia
        {
            unansweredQuestions = questions.ToList<Question>();
        }

        GetRandomQuestion();
	}

    void GetRandomQuestion()//losujemy pytanie z tych które nam zostały
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        txtSentence.text = currentQuestion.Sentence;
        txtAnswerA.text = currentQuestion.AnswerA;
        txtAnswerB.text = currentQuestion.AnswerB;
        txtAnswerC.text = currentQuestion.AnswerC;
        txtAnswerD.text = currentQuestion.AnswerD;

        unansweredQuestions.RemoveAt(randomQuestionIndex);
    }

    public void NextQuestion()
    {
        
    }

    public void OnClicked(Button button)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            clickedAnswer = button.GetComponentInChildren<Text>().text;
            if (clickedAnswer == currentQuestion.CorrectAnswer)
            {
                WrongAnswer.enabled = false;
                GoodAnswer.enabled = true;
                Debug.Log("Good");
            }
            else
            {
                GoodAnswer.enabled = false;
                WrongAnswer.enabled = true;
                Debug.Log("Wrong");
            }
        }
    }

}
