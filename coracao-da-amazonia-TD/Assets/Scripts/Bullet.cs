using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;
    public int bulletDamageArqueiro = 10;
    public int damageDeal = 0;
    
    public void Perseguir(Transform _target)
    {
        target = _target;
    }
    void Start()
    {
        
    }
    
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame )
        {
            
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);


    }

    void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto colidido tem o script Enemy
        Enemy enemyScript = other.gameObject.GetComponent<Enemy>();


        // Aplica o dano ao inimigo
        if (enemyScript != null)
        {
            enemyScript.DamageTake(bulletDamageArqueiro);
            Debug.Log("Dano causado: " + bulletDamageArqueiro);

            

        }
    }
}
