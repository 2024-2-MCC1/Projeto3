using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMenu : MonoBehaviour
{
    public static TowerMenu Instance;
    private Node selectedNode;
    public GameObject moneyManager;
    public GameObject towerMenu;
    public GameObject overlay;

    // Start is called before the first frame update
    void Start()
    {
        moneyManager = GameObject.Find("GameMaster"); ;
        
        
    }

    private void Awake()
    {
        Instance = this;
    }
    public void SelectNode(Node node)
    {
        selectedNode = node;
    }
    public void ArqueiroButton()
    {
        moneyManager.GetComponent<MoneyManager>().MoneyCheck(100);
        if (moneyManager.GetComponent<MoneyManager>().moneyValidate == true)
        {
            if (selectedNode != null)
            {
                HidePanel();
                selectedNode.Arqueiro();
                moneyManager.GetComponent<MoneyManager>().SubtractMoney(100);
                
            }
            
            
        }
    }
    
    public void OverlayClick()
    {
        HidePanel ();
    }
    void HidePanel()
    {
        towerMenu.SetActive(false);
        
    }
}
