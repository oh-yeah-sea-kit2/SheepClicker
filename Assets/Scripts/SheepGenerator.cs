using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepGenerator : MonoBehaviour {
    [SerializeField]
    private Sheep sheepPrefab;

    public void CreateSheep(SheepData sheepData) {
        var sheep = Instantiate(sheepPrefab);
        sheep.sheepData = sheepData;
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    // void Update() {
    //     if (Input.GetKeyDown(KeyCode.S)) {
    //         CreateSheep();
    //     }
    // }
}
