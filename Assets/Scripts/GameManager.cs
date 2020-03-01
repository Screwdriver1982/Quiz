using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    [Header("UI Elements")]
    public Image questionImage;
    public Button[] buttons;

    [Header("Config")]
    // список, по типу массива, но не фиксированной длины и позволяет удалять и добавлять новые элементы
    public List<QuestionData> allQuestions;
    QuestionData activeQuestion;
    public Text resultText;
    public Text triesLeft;
    public int difficultyLevel;
    int maxMistake;
    int doneMistake;
    public float answerTime;
    float leftTime;
    GameRecord gameRecordComponent;



    // Start is called before the first frame update
    void Start()
    {
        GameDifficulty difficultyComponent = FindObjectOfType<GameDifficulty>();
        difficultyLevel = difficultyComponent.difficulty;
        Destroy(difficultyComponent.gameObject);
        maxMistake = 2 - difficultyLevel;
        doneMistake = 0;
        answerTime = answerTime - difficultyLevel;
        gameRecordComponent = FindObjectOfType<GameRecord>();
        gameRecordComponent.maxQuestions = allQuestions.Count;

        LoadNextQuestion();
    }

    private void LoadNextQuestion()
    {
        if ((doneMistake > maxMistake) || allQuestions.Count == 0)
        {
            ScenesLoader scenesLoaderComponent = FindObjectOfType<ScenesLoader>();
            scenesLoaderComponent.LoadNextLevel();
        }
        else
        { 
       
            triesLeft.text = "Mistakes: " + doneMistake + "/" + maxMistake ;

            //берет случайный элемент из листа-массива, правая граница не включается
            int randomIndex = Random.Range(0, allQuestions.Count);
            activeQuestion = allQuestions[randomIndex];
            questionImage.sprite = activeQuestion.image;

            for (int index = 0; index < buttons.Length; index++)
            {

                //для понятности разбито на 3 шага, но можно все объединить в один с кучей точек
                //buttons[0].GetComponentInChildren<Text>().text ="Bla Bla bla";

                Button Button = buttons[index];
                Text ButtonChildText = Button.GetComponentInChildren<Text>();

                string answerText = activeQuestion.questions[index];
                ButtonChildText.text = answerText.ToUpper();
            }
            leftTime = answerTime;
        }
    }

    public void CheckAnswer(int answerNumber)
    {
        Debug.Log("Clicked: " + answerNumber);
        if (answerNumber == activeQuestion.rightAnswer)
        {
            // correct
            gameRecordComponent.playerRecord += 1;
            ShowResult(true);
        }

        else
        {
            // incorrect
            doneMistake += 1;
            ShowResult(false);
        }

        // go to next question

        //удаляет из листа-массива нулевой элемент
        //allQuestions.RemoveAt(randomIndex);
        allQuestions.Remove(activeQuestion); //удаляет из листа вопрос, на который ссылается activeQuestion
        LoadNextQuestion();
        RestartButtons();
    }

    void ShowResult(bool correct)
    {
        if (correct)
        { 
            resultText.text = "CORRECT";
            resultText.color = Color.green;
        }
        else 
        {
            resultText.text = "WRONG";
            resultText.color = Color.red;
        }
    }

    void RestartButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            Button button = buttons[i];
            button.interactable = true;
        }
           
    }


    public void UseHint()
    {
        int counter = 0;

        for (int i = 0; i < buttons.Length; i++)
        {
            Button button = buttons[i];

            if (i != activeQuestion.rightAnswer)
            {
                button.interactable = false;

                counter++;

                if (counter == 2)
                {
                    //прерывает выполнение цикла и дальше по коду происходит выход из цикла
                    break;
                }
                
            }


        }
      

    }

    private void Update()
    {
        if (leftTime > 0)
        {
            leftTime = leftTime - Time.deltaTime;
            Debug.Log(leftTime);
        }
        else
        {
            doneMistake += 1;
            allQuestions.Remove(activeQuestion); //удаляет из листа вопрос, на который ссылается activeQuestion
            LoadNextQuestion();
        }
    }
}
