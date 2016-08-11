using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private EnemyGenerator enemyGenerator;

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
            txt_CurrentWave.text = "Wave: " + _currentWave;
        }
    }
    public int goalWave;

    private Text txt_EnemyCount;
    private Text txt_CurrentWave;

	void Start () {
        enemyGenerator = GetComponent<EnemyGenerator>();
        enemyGenerator._GM = this;
        txt_EnemyCount = GameObject.Find("txtEnemyCount").GetComponent<Text>();
        txt_CurrentWave = GameObject.Find("txtCurrentWave").GetComponent<Text>();

        currentWave = 1;
        enemyCount = 5;
        enemyGenerator.SpawnInvokeRepeater(enemyCount, 1.5f, 0.5f);
    }
}
