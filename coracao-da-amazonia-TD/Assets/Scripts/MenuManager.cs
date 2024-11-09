using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public string cena;

    public void Jogar()
    {
        SceneManager.LoadScene("Jogo");
    }
       
    public void Sair()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
