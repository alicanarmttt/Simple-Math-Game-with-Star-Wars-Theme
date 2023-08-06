using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DortIslem : MonoBehaviour
{
    public AudioSource audioClick;
    public AudioClip correctSound;
    public AudioClip wrongSound;
    public AudioSource activeSound;
    public AudioClip BackGroundMusic;


    public void playButton()
    {
        audioClick.Play();
    }
    
    public UnityEngine.UI.Text f�rstEnter, secondEnter, sonuc, s�gn, answer;
    int sayi1, sayi2, islemIsareti;
    float answerfinal; // Changed to float to support decimal answers

    // Start is called before the first frame update
    void Start()
    {
        NextQuestion();
        activeSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() 
    { 

    }

    public void AnswerCheck()
    {

        float userAnswer;
        if (float.TryParse(answer.text, out userAnswer))
        {
            if (Mathf.Approximately(userAnswer, answerfinal) || Mathf.Approximately(userAnswer, -answerfinal))
            {
                sonuc.text = "CORRECT";
                activeSound.clip = correctSound;
                activeSound.Play();
                
                StartCoroutine(ContinueBackgroundMusic(correctSound.length));

            }
            else
            {
                sonuc.text = "WRONG";
                activeSound.clip = wrongSound;
                activeSound.Play();
                StartCoroutine(ContinueBackgroundMusic(wrongSound.length));
            }
        }
        else
        {
            sonuc.text = "INVALID INPUT";
        }
    }
    public void NextQuestion()
    {
        answer.text = "";
        sonuc.text = "";
        islemIsareti = Random.Range(1, 5);

        sayi1 = Random.Range(1, 10);
        sayi2 = Random.Range(1, 10);


        switch (islemIsareti)
        {
            case 1:
                s�gn.text = "+";
                answerfinal = sayi1 + sayi2;
                break;
            case 2:
                s�gn.text = "-";
                answerfinal = sayi1 - sayi2;
                break;
            case 3:
                s�gn.text = "*";
                answerfinal = sayi1 * sayi2;
                break;
            case 4:
                s�gn.text = "/";

                int denemeSayisi = 0;
                while (denemeSayisi < 100) // 
                {
                    sayi1 = Random.Range(1, 10);
                    sayi2 = Random.Range(1, 10);

                    if (sayi1 % sayi2 == 0)
                    {
                        answerfinal = (float)sayi1 / sayi2;
                        break;
                    }

                    denemeSayisi++;
                }

                break;
        }

        f�rstEnter.text = sayi2 + "";
        secondEnter.text = sayi1 + "";
    }
    private IEnumerator ContinueBackgroundMusic(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        activeSound.clip = BackGroundMusic;
        activeSound.Play(); // Arkaplan m�zi�ine devam et
    }
}