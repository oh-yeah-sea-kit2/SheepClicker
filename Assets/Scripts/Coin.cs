using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    public int value;
    public Wallet wallet;
    private float waitTime;

    // Start is called before the first frame update
    void Start() {
        waitTime = Random.Range(0.1f, 0.3f);
    }

    // Update is called once per frame
    void Update() {
        waitTime -= Time.deltaTime;
        if (waitTime > 0) return;

        //現在の位置から、Walletオブジェクトまで進むベクトルを計算
        var v = wallet.transform.position - transform.position;
        transform.position += v * Time.deltaTime * 20;

        // コインが財布に入ったら消滅
        if (v.magnitude < 0.5f) {
            wallet.money += value;
            Destroy(gameObject);
            SoundManager.Instance.Play("コイン");
        }
    }
}
