using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cacique : MonoBehaviour
{
    public float rangeCacique = 20f;
    public string towerTag = "Tower";
    private List<Arqueiro> arqueirosInRange = new List<Arqueiro>();
    public GameObject spawner_tower;
    public GameObject arqueiro;
    public float dist;
    public float fireRate;
    void Start()
    {
        arqueirosInRange.Clear();

    }
    
    // Update is called once per frame
    void Update()
    {
        arqueiro = spawner_tower.GetComponent<BuildManager>().arqueiroToBuild;
        dist = Vector3.Distance(transform.position, arqueiro.transform.position);
        
        if (dist < rangeCacique)
        {
            Buff(2);
        }
    }

    public void Buff(int buffAmount)
    {
        //Arqueiro[] arqueiros = FindObjectsOfType<Arqueiro>();
        //foreach (Arqueiro arqueiro in arqueiros)
        { 
            // Calcula a distância entre o Cacique e o Arqueiro
            float distance = Vector3.Distance(transform.position, arqueiro.transform.position);
            Debug.Log("Distância entre Cacique e Arqueiro: " + distance);
            // Verifica se o Arqueiro está dentro do range
            if (distance <= rangeCacique)
            {
                // Aplica o buff no range do Arqueiro
                arqueiro.GetComponent<Arqueiro>().fireRate += buffAmount;
                Debug.Log("Buff aplicado! Novo range do Arqueiro: " + arqueiro.GetComponent<Arqueiro>().fireRate);
            }
            else
            {
                Debug.Log("Arqueiro fora de alcance. FireRate do Arqueiro não alterado.");
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeCacique);
    }

    
}
