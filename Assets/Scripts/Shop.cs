using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {
    [SerializeField]
    // 購入ボタンのプレハブ
    private SheepButton sheepButtonPrefab;
    // 生成元になる羊データの配列
    public SheepData[] sheepDatas;
    // 作成したSheepButtonをListで保持
    public List<SheepButton> sheepButtonList;
    [SerializeField]
    private SheepGenerator sheepGenerator;
    [SerializeField]
    private Wallet wallet;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    void Awake() {
        // sheepDatasの数だけSheepButtonを生成
        foreach (var sheepData in sheepDatas) {
            var sheepButton = Instantiate(sheepButtonPrefab, transform);
            sheepButton.sheepData = sheepData;
            sheepButtonList.Add(sheepButton);
            sheepButton.sheepGenerator = sheepGenerator;
            sheepButton.wallet = wallet;
        }
    }
}
