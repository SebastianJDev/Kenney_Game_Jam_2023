using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int Puntos = 0;
    public TextMeshProUGUI Textopuntos,PUNTOSPANEL;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Application.targetFrameRate = 120;
    }
    public void StartGame()
    {
        StartCoroutine(Esperar());
    }
    public void StartGameTwo()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public IEnumerator Esperar()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadSceneAsync(1);
    }
    public void PausarTiempo()
    {
        Time.timeScale = 0;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void SumarPunto()
    {
        Puntos++;
    }
    public void PuntosDobles()
    {
        Puntos += 2;
    }
    public void ActualizarTextoPuntos()
    {
        Textopuntos.text = $"POINTS: {Puntos.ToString()}";
        PUNTOSPANEL.text = Puntos.ToString();
    }
}
