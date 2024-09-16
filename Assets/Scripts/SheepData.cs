using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SheepData : ScriptableObject{
    /// <summary>
    /// 羊の色
    /// </summary>
    public Color color;
    /// <summary>
    /// 初期値段
    /// </summary>
    public int basePrice;
    /// <summary>
    /// 値段上昇額
    /// </summary>
    public int extendPrice;
    /// <summary>
    /// 購入上限数
    /// </summary>
    public int maxCount;
    /// <summary>
    /// 羊の数
    /// </summary>
    public int woolCount;
}
