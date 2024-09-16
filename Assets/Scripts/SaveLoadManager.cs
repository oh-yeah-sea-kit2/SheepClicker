using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour {
    // 保存対象：所持金、羊の頭数
    [SerializeField]
    private Wallet wallet;
    [SerializeField]
    private Shop shop;

    private void OnApplicationQuit() {
        Debug.Log("セーブ");

        // 所持金を保存
        PlayerPrefs.SetString("MONEY", wallet.money.ToString());
        // すべての羊の頭数を保存
        for (var index=0; index < shop.sheepButtonList.Count; index++) {
            var sheepButton = shop.sheepButtonList[index];
            PlayerPrefs.SetInt($"SHEEP{index}", sheepButton.currentCount);
        }
    }

    // Start is called before the first frame update
    void Start() {
        Debug.Log("ロード");

        // 所持金をロード
        wallet.money = BigInteger.Parse(PlayerPrefs.GetString("MONEY", "0"));
        // すべての羊の頭数をロード
        for (var index=0; index < shop.sheepButtonList.Count; index++) {
            var sheepButton = shop.sheepButtonList[index];
            var sheepCount = PlayerPrefs.GetInt($"SHEEP{index}", 0);
            sheepButton.currentCount = sheepCount;
            for (var i=0; i<sheepCount; i++) {
                sheepButton.sheepGenerator.CreateSheep(sheepButton.sheepData);
            }
        }
    }

}
