using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMenu : MonoBehaviour
{
    public static TowerMenu Instance;
    private Node selectedNode;
    public GameObject moneyManager;
    public GameObject towerMenu;

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
        moneyManager.GetComponent<MoneyManager>().MoneyCheck(50);
        if (moneyManager.GetComponent<MoneyManager>().moneyValidate == true)
        {
            if (selectedNode != null)
            {
                HidePanel();
                selectedNode.Arqueiro();
                moneyManager.GetComponent<MoneyManager>().SubtractMoney(50);
            }
        }
    }
    public void PajeButton()
    {
        moneyManager.GetComponent<MoneyManager>().MoneyCheck(165);
        if (moneyManager.GetComponent<MoneyManager>().moneyValidate == true)
        {
            if (selectedNode != null)
            {
                HidePanel();
                selectedNode.Paje();
                moneyManager.GetComponent<MoneyManager>().SubtractMoney(165);
            }
        }
    }
    public void CaciqueButton()
    {
        moneyManager.GetComponent<MoneyManager>().MoneyCheck(125);
        if (moneyManager.GetComponent<MoneyManager>().moneyValidate == true)
        {
            if (selectedNode != null)
            {
                HidePanel();
                selectedNode.Cacique();
                moneyManager.GetComponent<MoneyManager>().SubtractMoney(125);
            }
        }
    }

    public void HidePanel()
    {
        towerMenu.SetActive(false);
    }
}
