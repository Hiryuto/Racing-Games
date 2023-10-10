using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public GameObject CoinObject;
    public GameObject CoinObj;
    public Text TextFrame;
    public float rotationSpeed = 150f;
    private static int coinCount;

    void Start()
    {
        coinCount = 0;
    }

    void Update()
    {
        TextFrame.text = string.Format("Coin: {0:000}", coinCount);
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CoinObj.SetActive(false);
            Invoke("ActivateEnemy", 5f);
            coinCount += 1;
            TextFrame.text = string.Format("Coin: {0:000}", coinCount);
        }
    }

    void ActivateEnemy()
    {
        CoinObject.SetActive(true);
    }
}
