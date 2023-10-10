using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarTrigger : MonoBehaviour
{
    public GameObject enemy1; // 敵オブジェクト

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ItemBox")) // アイテムボックスに触れた場合
        {
            other.gameObject.SetActive(false); // アイテムボックスを非表示にする
            Invoke("ActivateItemBox", 5f); // 5秒後にアイテムボックスを出現させる

        }
    }

    void ActivateItemBox()
    {
        // ItemBoxタグがついたオブジェクトを再度表示する
        GameObject[] itemBoxes = GameObject.FindGameObjectsWithTag("ItemBox");
        foreach (GameObject itemBox in itemBoxes)
        {
            if (!itemBox.activeSelf) // オブジェクトが非表示の場合のみ表示する
            {
                itemBox.SetActive(true);
            }
        }
    }
}
