using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance; //Este script(UIManager) es un singleton. Todos los manager deben ser un singleton
    [SerializeField] Text scoreText;
    [SerializeField] Text healthText;
    [SerializeField] Text timeText;
    [SerializeField] Text finalScoreText;
    [SerializeField] GameObject gameOverScreen; //El game object referenciado aqui es un canvas UI

    private void Awake()
    {
        if (Instance == null) //Este if junto con la variable Instance hacen de este script un singleton
        {
            Instance = this;
        }
    }

    public void UpdateUIScore(int newScore) //Los parametros de una funcion son variables locales, o sea, solo se usaran dentro de esa funcion
    {
        scoreText.text = newScore.ToString(); //ToString() convierte variables numericas a texto
    }

    public void UpdateUIHealth(int newHealth)
    {
        healthText.text = newHealth.ToString();
    }

    public void UpdateUITime(int newTime)
    {
        timeText.text = newTime.ToString();
    }

    public void ShowGameOverScreen()
    {
        Time.timeScale = 0; //Detiene el tiempo en el juego
        gameOverScreen.SetActive(true);
        finalScoreText.text = "SCORE: " + GameManager.Instance.Score; //Al concatenar con letras no es necesario escribir .ToString() despues de .Score porque entiende que va a ser texto
        Instance=null;
    }
}