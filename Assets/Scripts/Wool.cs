using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wool : MonoBehaviour {
    [SerializeField]
    private Rigidbody2D _rigidbody2D;
    // 羊毛の売却価格
    public int price = 100;
    [SerializeField]
    private SpriteRenderer woolSpriteRenderer;
    public Color woolColor;

    public void Sell(Wallet wallet) {
        wallet.money += price;
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start() {
        // 羊毛を上に飛ばす
        _rigidbody2D.AddForce(Quaternion.Euler(0, 0, Random.Range(0, 360)) * Vector2.up * 2, ForceMode2D.Impulse);
        transform.localScale = Vector3.one * Random.Range(0.4f, 1.5f);

        // 羊毛の色を設定
        woolColor.a = 0.9f;
        woolSpriteRenderer.color = woolColor;
    }

    // Update is called once per frame
    void Update() {
        // 羊毛が画面外に出たら削除
        if (transform.position.y < -5) {
            // Destroy(gameObject);
            // 落ちたら売る
            Sell(FindObjectOfType<Wallet>());
        }
    }
}
