using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [Header("Cool Values")]
    private float currentMoney;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void UpdateGraveCount()
    {

    }

    public void UpdateMoney(float amount)
    {
        currentMoney += amount;
    }
}
