using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    //define uma instancia estatica, permitindo que outros scripts acessem o BuildManager atraves do BuildManager.instance
    public static BuildManager instance;
    
    void Awake()
    {  
        //verifica se ja existe uma instancia de BuildManager
        if (instance != null)
        {
            //se sim, não permite que haja mais
            Debug.LogError("Mais de um BuildManager em cena!");
            return;
        }
        //se nao, define a instancia atual como a instancia unica
        instance = this;
    }
    //prefab publica
    public GameObject standardArqueiroPrefab;

    void Start()
    {
        //define standardArqueiroPrefab como o arqueiro a ser contruido e o armazena na variavel arqueiroToBuild
        arqueiroToBuild = standardArqueiroPrefab;

        
    }
    //prefab privada
    private GameObject arqueiroToBuild;
    //metodo publico  para obter o prefab do arqueiro a ser contruido. Metodo retorna arqueiroToBuild e permite que todos os scripts acessem o prefab configurado para construçao
    public GameObject GetArqueiroToBuild()
    { 
        return arqueiroToBuild; 
    } 

   
}
