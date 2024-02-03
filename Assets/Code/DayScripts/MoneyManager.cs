using Code.GridSystem;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [Header("Cool Values")]
    public float moneyTickTimer;
    public GameObject graveContainer;
    public float lowTierGraveEarnings;
    public float midTierGraveEarnings;
    public float highTierGraveEarnings;
    public static float currentMoney;
    private List<GameObject> LowTierGraves = new List<GameObject>();
    private List<GameObject> MidTierGraves = new List<GameObject>();
    private List<GameObject> HighTierGraves = new List<GameObject>();
    public bool earningMoney;

    void Start()
    {
        currentMoney = 100;
        StartEarningMoney();
        UpdateGraveCount();
        StartCoroutine(MoneyTicks());
    }

    private IEnumerator MoneyTicks()
    {
        while(earningMoney)
        {
            yield return new WaitForSeconds(moneyTickTimer);
            //UpdateGraveCount();
            CalculateMoneyGained();
            Debug.Log(currentMoney);
        }
    }
    

    public void UpdateGraveCount()
    {
        LowTierGraves.Clear();
        MidTierGraves.Clear();
        HighTierGraves.Clear();

        foreach(Transform grave in graveContainer.transform)
        {
            if (!grave.GetComponent<PlaceableObject>().Placed) { return; }
            if(grave.tag == "Grave-Low")
            {
                LowTierGraves.Add(grave.gameObject);
            }  else
            if (grave.tag == "Grave-Mid")
            {
                MidTierGraves.Add(grave.gameObject);
            }  else 
            if (grave.tag == "Grave-High")
            {
                HighTierGraves.Add(grave.gameObject);
            }
        }
    }

    public void AddMoney(float amountToAdd)
    {
        UpdateGraveCount();
        if (amountToAdd > 0)
        {
            FindObjectOfType<PointTextManager>().GetComponent<PointTextManager>().PlayPopup(amountToAdd);
            currentMoney += amountToAdd;
        }
    }

    public void SubtractMoney(float amountToSubtract) 
    { 
        UpdateGraveCount();
        if (amountToSubtract > 0)
        {
            FindObjectOfType<PointTextManager>().GetComponent<PointTextManager>().PlayPopup(-amountToSubtract);
            currentMoney -= amountToSubtract;
        }

    }

    private void CalculateMoneyGained()
    {
        float moneyEarned = 0;
        moneyEarned += LowTierGraves.Count * lowTierGraveEarnings;
        moneyEarned += MidTierGraves.Count * midTierGraveEarnings;
        moneyEarned += HighTierGraves.Count * highTierGraveEarnings;

        AddMoney(moneyEarned);
    }

    public void StartEarningMoney()
    {
        earningMoney = true;
    }

    public void StopEarningMoney()
    {
        earningMoney = false;
    }
}
