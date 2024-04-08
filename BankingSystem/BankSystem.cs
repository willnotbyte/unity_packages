using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankSystem : MonoBehaviour
{
    public float curBal = 500.00f;
    public float maxBal = 99999.99f;
    public string balanceString;

    public class Transaction
    {
        public string merchantName;
        public float transValue;

        public Transaction (string name, float value)
        {
            merchantName = name;
            transValue = value;
        }
    }

    public List<Transaction> transaction = new List<Transaction>();

    private void Update()
    {
        balanceString = ("Balance: " + curBal.ToString("#0.00"));
        if (curBal >= maxBal)
        {
            curBal = maxBal;
        }
        if (curBal <= 0)
        {
            curBal = 0;
        }
        //TransactionTesting(); //Testing-Use Only!
    }

    void TransactionTesting()
    {
        if (Input.GetKeyDown("t"))
        {
            MakeTransaction("test", 100f);
        }
        if (Input.GetKeyDown("y"))
        {
            MakeTransaction("test2", -100);
        }
        Debug.Log(transaction.Count);
        for (int cnt = 0; cnt < transaction.Count; cnt++)
        {
            float abval = Mathf.Abs(transaction[cnt].transValue);
            if (transaction[cnt].transValue >= 0)
            {
                //Positive
                Debug.Log("Name: " + transaction[cnt].merchantName + " Value: " + "+" + abval);
            }
            else
            {
                //Negative
                Debug.Log("Name: " + transaction[cnt].merchantName + " Value: " + "-" + abval);
            }
        }
    }

    public void MakeTransaction(string name, float amount)
    {
        curBal += amount;
        transaction.Add(new Transaction(name, amount));
    }
}
