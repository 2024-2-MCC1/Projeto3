using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Atributos")]
    public float speed = 10.0f; // Velocidade do inimigo
    public float hpEnemy = 50;

    private Transform target;
    private int wavepointIndex = 0;

    private GameObject hpPlayer;
    private GameObject moneyManager;

    // Variáveis para debuff
    private float originalSpeed;  // Armazena a velocidade original do inimigo
    private bool isDebuffed = false; // Verifica se o inimigo está debuffado
    private float debuffAmount = 0f; // A quantidade de debuff a ser aplicada

    void Start()
    {
        hpPlayer = GameObject.Find("GameMaster");
        moneyManager = GameObject.Find("GameMaster");

        target = Waypoints.points[0];

        originalSpeed = speed;  // Armazena a velocidade original ao começar o jogo
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            hpPlayer.GetComponent<HpPlayer>().TomarDano(1);
            WaveSpawner.EnemiesAlive--;
            Destroy(gameObject);
            hpPlayer.GetComponent<HpPlayer>().Perder();
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    public void DamageTake(float dano)
    {
        hpEnemy = hpEnemy - dano;
        if (hpEnemy <= 0)
        {
            Die();
        }
        return;
    }

    void Die()
    {
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
        moneyManager.GetComponent<MoneyManager>().AddMoney(35);
    }

    // Método para aplicar o debuff no inimigo
    public void ApplyDebuff(float debuffAmount)
    {
        if (!isDebuffed)
        {
            this.debuffAmount = debuffAmount;
            speed -= debuffAmount; // Reduz a velocidade do inimigo
            speed = Mathf.Max(speed, 0f); // Impede que a velocidade se torne negativa
            isDebuffed = true; // Marca o inimigo como debuffado
            
        }
    }

    // Método para remover o debuff
    public void RemoveDebuff()
    {
        if (isDebuffed)
        {
            speed = originalSpeed; // Restaura a velocidade original
            isDebuffed = false; // Marca o inimigo como sem debuff
        }
    }
}
