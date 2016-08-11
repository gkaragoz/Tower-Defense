using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private JSONObject _levelsJSON;
    private JSONObject _wavesJSON;

    public bool onPlay = false;
	public List<GameObject> enemyList;      //Enemies list on scene.

    private int _enemyCount;
    public int enemyCount
    {
        get
        {
            return _enemyCount;
        }
        set
        {
            _enemyCount = value;
            txt_EnemyCount.text = "Enemy Left: " + _enemyCount;
        }
    }

    private int _currentLevel;
    public int currentLevel
    {
        get
        {
            return _currentLevel;
        }
        set
        {
            _currentLevel = value;
            _levelsJSON = _levelsJSON.GetField("Level" + _currentLevel);
        }
    }

    private int _currentWave;
    public int currentWave
    {
        get
        {
            return _currentWave;
        }
        set
        {
            _currentWave = value;
            _wavesJSON = _levelsJSON.GetField("Wave" + _currentWave);
            txt_CurrentWave.text = "Wave: " + _currentWave;
        }
    }
    public int goalWave;

    private Text txt_EnemyCount;
    private Text txt_CurrentWave;

    private Button btn_NextWave;

	void Start () {
        _levelsJSON = new JSONObject(Extensions.LoadResourceTextfile("JSON/Waves"));
        txt_EnemyCount = GameObject.Find("txtEnemyCount").GetComponent<Text>();
        txt_CurrentWave = GameObject.Find("txtCurrentWave").GetComponent<Text>();
        btn_NextWave = GameObject.Find("btnNextWave").GetComponent<Button>();

        btn_NextWave.onClick.AddListener(delegate
        {
            NextWave();
        });

        currentLevel = SceneManager.GetActiveScene().buildIndex;
        currentWave = 1;
        enemyCount = 1;

        gameObject.AddComponent<EnemyGenerator>().SpawnInvokeRepeater(_wavesJSON);
    }

    void NextWave()
    {
        currentWave++;
        gameObject.AddComponent<EnemyGenerator>().SpawnInvokeRepeater(_wavesJSON);
    }
}
