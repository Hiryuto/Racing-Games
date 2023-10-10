using UnityEngine;
using UnityEngine.UI;

public class ItemBox : MonoBehaviour
{
    public GameObject image_object; // 画像オブジェクト

    public string SelectItem; // 選択されたアイテム名


    string[] ItemName = new string[] { "SpeedDrink", "Attack", "Exp", "ItemGet", "stamina" }; // アイテム名のリスト

    void Start()
    {
        // オブジェクトの取得
        image_object = GameObject.Find("ItemImage");
    }

    // 他のオブジェクトと衝突した時に呼び出される関数
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false); // 自身を非表示にする
            Invoke("ActivateEnemy", 5f);
            Debug.Log("Activate");
            SelectItem = ItemName[Random.Range(0, ItemName.Length)]; // アイテム名からランダムで選ぶ
            Debug.Log(SelectItem); // 選ばれたアイテム名をログに出力する
            // 選ばれたアイテム名に対応する画像を表示する
            image_object.GetComponent<Image>().sprite = Resources.Load<Sprite>(SelectItem);
            // Imageコンポーネントのcolorプロパティを変更して、背景を白にする
            image_object.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            // image_object.GetComponent<Image>().sprite = Resources.Load<Sprite>("SpeedDrink");
        }
    }

    // 敵をアクティブにする関数
    void ActivateEnemy()
    {
        //自分自身を表示する
        gameObject.SetActive(true);
    }
}