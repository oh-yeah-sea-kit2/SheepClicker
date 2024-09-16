using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    [System.Serializable]
    public class SoundData {
        public string name;
        public AudioClip audioClip;
        public float playedTime;
    }

    [SerializeField]
    private SoundData[] soundDatas;

    // AudioSource（スピーカー）を同時に鳴らしたい音の数だけ用意
    private AudioSource[] audioSourceList = new AudioSource[20];
    // 別名(name)をキーとして管理用Dictionary
    private Dictionary<string, SoundData> soundDictionary = new Dictionary<string, SoundData>();

    [SerializeField]
    private float playableDistance = 0.2f;

    public static SoundManager Instance {
        private set;
        get;
    }

    private void Awake() {
        if (Instance == null)
        {
            Instance = this;
        } else if (Instance != this) {
            Destroy(gameObject);
            return;
        }
        
        // audioSourceListにAudioSourceをセット
        for (var i=0; i<audioSourceList.Length; i++) {
            audioSourceList[i] = gameObject.AddComponent<AudioSource>();
        }
        // soundDictionaryにSoundDataをセット
        foreach (var soundData in soundDatas) {
            soundDictionary.Add(soundData.name, soundData);
        }
    }

    // 未使用のAudioSourceを取得, 全て使用中の場合はnullを返す
    private AudioSource GetUnusedAudioSource() {
        foreach (var audioSource in audioSourceList) {
            if (!audioSource.isPlaying) return audioSource;
        }
        return null;
    }

    // 指定されたAudioClipを未使用のAudioSourceで再生
    public void Play(AudioClip clip) {
        var audioSource = GetUnusedAudioSource();
        if (audioSource == null) return;
        audioSource.clip = clip;
        audioSource.Play();
    }

    // 指定された別名で登録されたAudioClipを再生
    public void Play(string name) {
        if (soundDictionary.TryGetValue(name, out var soundData)) {
            if (Time.realtimeSinceStartup - soundData.playedTime < playableDistance) return;
            soundData.playedTime = Time.realtimeSinceStartup;
            Play(soundData.audioClip);
        } else {
            Debug.LogWarning($"指定された名前{name}のサウンドは登録されていません");
        }
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }
}
