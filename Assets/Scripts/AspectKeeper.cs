using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class AspectKeeper : MonoBehaviour {
    [SerializeField]
    private Camera targetCamera;
    [SerializeField]
    private Vector2 aspectVec;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        // 画面のアスペクト比
        var screenAspect = Screen.width / (float)Screen.height;
        // 目的のアスペクト比
        var targetAspect = aspectVec.x / aspectVec.y;

        // 目的のアスペクト比にするための倍率
        var magRate = targetAspect / screenAspect;
        // Viewport初期値でRectを作成
        var viewportRect = new Rect(0, 0, 1, 1);

        if (magRate < 1) {
            viewportRect.width = magRate;
        } else {
            viewportRect.height = 1 / magRate;
        }
        viewportRect.x = 0.5f - viewportRect.width * 0.5f;
        targetCamera.rect = viewportRect;
    }
}
