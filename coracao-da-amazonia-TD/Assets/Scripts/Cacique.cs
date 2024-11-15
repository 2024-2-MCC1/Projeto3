using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cacique : MonoBehaviour
{
    public float buffAmount = .5f; // Valor do buff para o fireRate
    public float debuffAmount = 5f; //Valor do debuff slow
    public string enemyTag = "Enemy";

    private HashSet<Enemy> debuffedEnemies = new HashSet<Enemy>();

    public void BuffFireRate(ShootersTowers torre)
    {
        torre.fireRate += buffAmount;
    }
    public void BuffSlow(ShootersTowers torre)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        foreach (GameObject enemyObj in enemies)
        {
            Enemy enemy = enemyObj.GetComponent<Enemy>();
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy <= torre.range)
            {
                // Aplica debuff
                if (!debuffedEnemies.Contains(enemy))
                {
                    enemy.ApplyDebuff(debuffAmount);
                    debuffedEnemies.Add(enemy);
                }
            }
            else
            {
                // Remove debuff se o inimigo sair do alcance
                if (debuffedEnemies.Contains(enemy))
                {
                    enemy.RemoveDebuff();
                    debuffedEnemies.Remove(enemy);
                }
            }
        }
    }
}
