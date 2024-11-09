using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HpPlayer : MonoBehaviour
{
    public TextMeshProUGUI hpCount;
    //Inicia a variavel vida
    public int vida = 100;
    //Inicia a variavel gameOver para testar se o jogador perdeu
    public bool gameOver = false;
    //Funcao para 
    public void Perder()
    {
        
        if (vida == 0)
        {
            gameOver = true;

        }
        if (gameOver == true) 
        {
            Debug.Log("Perdi");
        }

    }
    public void TomarDano(int dano)
    {
        if (!gameOver)
        {
            vida -= dano;
            hpCount.text = ("Vida do jogador: " + vida);

        }
    }
    
}
