using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sheepRenderer;
    [SerializeField]
    private Sprite cutSheepSprite;
    [SerializeField]
    private Wool woolPrefab;

    // 最初の羊の画像
    private Sprite defaultSprite;
    // 移動速度
    private float moveSpeed;
    public SheepData sheepData;
    private int woolCount;

    private void Initialize() {
        sheepRenderer.sprite = defaultSprite;
        transform.position = new Vector3(5, Random.Range(0.0f, 4.0f), 0);
        moveSpeed = -Random.Range(1.01f, 2.0f);

        sheepRenderer.color = sheepData.color;
        woolCount = sheepData.woolCount;
    }

    // Start is called before the first frame update
    void Start()
    {
        defaultSprite = sheepRenderer.sprite;
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(moveSpeed, 0) * Time.deltaTime;
        if (transform.position.x < -5) {
            Initialize();
        }
    }

    private void Shaving()
    {
        if (woolCount <= 0) return;
        var shavingWool = (int)(sheepData.woolCount * Random.Range(0.3f, 0.4f));
        if (woolCount < shavingWool) shavingWool = woolCount;

        woolCount -= shavingWool;
        if (woolCount <= 0) {
            sheepRenderer.sprite = cutSheepSprite;
            sheepRenderer.color = Color.white;
        }
        var wool = Instantiate(woolPrefab, transform.position, transform.rotation);

        // TODO: Woolオブジェクトに今回刈り取った羊毛を渡す
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0) == false) return;
        Shaving();
    }
}
