using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;


public class SheepButton : MonoBehaviour {
    [SerializeField]
    private Button button;
    public SheepData sheepData;
    public SheepGenerator sheepGenerator;

    // 羊画像
    [SerializeField]
    private Image sheepImage;
    // 金額Text
    [SerializeField]
    private Text priceText;
    // 頭数Text
    [SerializeField]
    private Text countText;
    // 販売可否Text
    [SerializeField]
    private Text infoText;
    // 所持金オブジェクト
    [SerializeField]
    public Wallet wallet;
    // 現在の頭数
    public int currentCount;

    public BigInteger GetPrice() {
        return sheepData.basePrice + sheepData.extendPrice * currentCount;
    }

    public void CreateSheep() {
        sheepGenerator.CreateSheep(sheepData);
        var price = GetPrice();
        wallet.money -= price;
        currentCount++;
    }


    // Start is called before the first frame update
    void Start() {
        button.onClick.AddListener(CreateSheep);
    }

    // Update is called once per frame
    void Update() {
        var price = GetPrice();

        sheepImage.color = sheepData.color;
        priceText.text = price.ToString("C0");
        countText.text = $"{currentCount}頭/{sheepData.maxCount}頭";

        if (currentCount >= sheepData.maxCount) {
            infoText.text = "完売";
            button.interactable = false;
        } else if (wallet.money >= price) {
            infoText.text = "購入可";
            button.interactable = true;
        } else {
            infoText.text = "お金が足りません";
            button.interactable = false;
        }
    }
}
