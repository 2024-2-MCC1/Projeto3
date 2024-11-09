using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class MoneyManager : MonoBehaviour
{
    public int money = 300; // Exemplo de variável de dinheiro
    public TextMeshProUGUI moneyCount;
    // Método para adicionar dinheiro
    public void AddMoney(int amount)
    {
        money += amount;
        
    }

    // Método para subtrair dinheiro
    public void SubtractMoney(int amount)
    {
        if (money >= amount)
        {
            money -= amount;
            
        }
        
    }
    public bool moneyValidate;
    public void MoneyCheck(int amount)
    {
        
        if (money < amount) 
        {
            moneyValidate = false;
        }
        else
        {
            moneyValidate = true;
        }
        return;
    }
    private void Update()
    {
        // *alterar quando possivel(muito processamento)
        moneyCount.text = ("R$ " + money);
    }
}
