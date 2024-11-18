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
    private GameObject cacique;
    private GameObject paje;


    //config do panel TowerMenu
    public GameObject panel;  // Referência ao panel
    
   

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
           
        }
    }

    //quando o jogador clica no node
    void OnMouseDown()
    {
        if (panel.activeSelf)
        {
            return; // Interrompe o método se o painel estiver ativo
        }
        //verifica se tem objeto construido neste node
        if (arqueiro != null)
            {
                //se sim, impede que outro objeto seja construido no mesmo lugar
                return;

            }
        else
            {
                panel.SetActive(true);
                TowerMenu.Instance.SelectNode(this);

            }
        
    }
    
    public void Arqueiro()
    {
        
        //prefab do arqueiro construido atraves do BuildManager
        GameObject arqueiroToBuild = BuildManager.instance.GetArqueiroToBuild();
        //instancia o personagem no node, ajustando a posiçao com um positionOffset no ponto Y
        arqueiro = (GameObject)Instantiate(arqueiroToBuild, transform.position + positionOffset, transform.rotation);
    }

    public void Paje()
    {

        //prefab do arqueiro construido atraves do BuildManager
        GameObject pajeToBuild = BuildManager.instance.GetPajeToBuild();
        //instancia o personagem no node, ajustando a posiçao com um positionOffset no ponto Y
        paje = (GameObject)Instantiate(pajeToBuild, transform.position + positionOffset, transform.rotation);
    }
    public void Cacique()
    {

        //prefab do arqueiro construido atraves do BuildManager
        GameObject caciqueToBuild = BuildManager.instance.GetCaciqueToBuild();
        //instancia o personagem no node, ajustando a posiçao com um positionOffset no ponto Y
        cacique = (GameObject)Instantiate(caciqueToBuild, transform.position + positionOffset, transform.rotation);
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
