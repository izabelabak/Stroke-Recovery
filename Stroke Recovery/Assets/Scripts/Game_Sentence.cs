using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Game_Sentence : MonoBehaviour {
    public Question[] questionsSentence;//tablica z pytaniami, pytania dodajemy w Unity
    public Question[] questionsMath;
    public Question[] questionsMatching;
    public static List<Question> unansweredQuestionsSentence;
    public static List<Question> unansweredQuestionsMath;
    public static List<Question> unansweredQuestionsMatching;
    public static List<List<Question>> unansweredQuestionsList;

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
    public Image Won;
    public Text WonText;
    public Image OkButton;

    public Game_Sentence()
    {
        InitializeQuestionsList();
    }

    void InitializeQuestionsList()
    {
        unansweredQuestionsSentence = questionsSentence.ToList<Question>();
        unansweredQuestionsMath = questionsMath.ToList<Question>();
        unansweredQuestionsMatching = questionsMatching.ToList<Question>();
        unansweredQuestionsList = new List<List<Question>>();
        unansweredQuestionsList.Add(unansweredQuestionsSentence);
        unansweredQuestionsList.Add(unansweredQuestionsMath);
        unansweredQuestionsList.Add(unansweredQuestionsMatching);
    }

    void Start ()
    {
        GoodAnswer = GoodAnswer.GetComponent<Image>();
        GoodAnswer.enabled = false;
        WrongAnswer = WrongAnswer.GetComponent<Image>();
        WrongAnswer.enabled = false;
        Won = Won.GetComponent<Image>();
        Won.enabled = false;
        WonText = WonText.GetComponent<Text>();
        WonText.enabled = false;
        
        if (unansweredQuestionsList == null || unansweredQuestionsList.Count == 0)
        {
            InitializeQuestionsList();
        }

        GetRandomQuestion();
	}

    void GetRandomQuestion()
    {
        int randomListIndex = Random.Range(0, unansweredQuestionsList.Count);
        List<Question> unansweredQuestions = unansweredQuestionsList[randomListIndex];
        unansweredQuestionsList.RemoveAt(randomListIndex);

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
        WrongAnswer.enabled = false;
        GoodAnswer.enabled = false;
        GetRandomQuestion();
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
            }
            else
            {
                GoodAnswer.enabled = false;
                WrongAnswer.enabled = true;
            }
        }
    }

}
