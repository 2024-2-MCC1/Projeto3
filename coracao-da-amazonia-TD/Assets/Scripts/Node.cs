using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    
    private Renderer rend;
    private Color startColor;

    private GameObject arqueiro;


    //config do panel TowerMenu
    public GameObject panel;  // Referência ao panel
    public GameObject overlay;
   

    void Start()
    {
        //atribui Renderer do objeto a rend, para poder manipular cor do node
        rend = GetComponent<Renderer>();
        //cor inicial do node
        startColor = rend.material.color;

        

        //seta o panel como desativado
        if (panel != null)
        {
            panel.SetActive(false);
            overlay.SetActive(false);
        }
    }

    //quando o jogador clica no node
    void OnMouseDown()
    {
        //verifica se tem objeto construido neste node
        if (arqueiro != null)
        {
            //se sim, impede que outro objeto seja construido no mesmo lugar
            Debug.Log("Não da pra construir ai!");
            return;
            
        }
        else 
        {
            
            if (panel == false && overlay == false)
            {
                // Alterna a visibilidade do painel
                
                panel.SetActive(true);
                overlay.SetActive(true);
                TowerMenu.Instance.SelectNode(this);
            }
        }
    }

    public void Arqueiro()
    {
        
        //prefab do arqueiro construido atraves do BuildManager
        GameObject arqueiroToBuild = BuildManager.instance.GetArqueiroToBuild();
        //instancia o personagem no node, ajustando a posiçao com um positionOffset no ponto Y
        arqueiro = (GameObject)Instantiate(arqueiroToBuild, transform.position + positionOffset, transform.rotation);
        
    }

    //quando o cursor do mouse passa sobre o node
    void OnMouseEnter()
    {
        //altera a cor para indicar onde vai selecionar a construçao
        rend.material.color = hoverColor;
    }

    //quando o cursor do mouse sai do node
    void OnMouseExit()
    {
        //restaura a cor original
        rend.material.color = startColor;
    }
}
