using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cacique : MonoBehaviour
{
    public float buffAmount = .5f; // Valor do buff para o fireRate
    public float debuffAmount = 5f; //Valor do debuff slow
    public Enemy alvo;
    public Animator animator;

    //private HashSet<Enemy> debuffedEnemies = new HashSet<Enemy>();

    private bool isDebuff;

    public void BuffFireRate(ShootersTowers torre)
    {
        torre.fireRate += buffAmount;
        animator.SetBool("buffer", true);
    }
    public void BuffSlow(ShootersTowers torre)
    {
        alvo = torre.targetEnemy;
        if (alvo != null)
        {
            isDebuff = alvo.isDebuffed;
        }
        if (alvo == null) return;

        float distanceToEnemy = Vector3.Distance(transform.position, alvo.transform.position);

        if (distanceToEnemy <= torre.range)
        {
         // Aplica debuff
            if (!isDebuff)
            {
                alvo.ApplyDebuff(debuffAmount);
                isDebuff = true;
            }
         }
        else
        {
            // Remove debuff se o inimigo sair do alcance
            if (distanceToEnemy > torre.range && isDebuff)
            {
                alvo.RemoveDebuff();
                
            }
            
        }
    }
}
