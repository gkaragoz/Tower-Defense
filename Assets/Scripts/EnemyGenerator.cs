using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {

	private int _enemyCount;
	private GameObject _enemyPrefab;
	private Vector3 _spawnLocation;
	private float _spawnTime;
	private float _spawnWaitTime;
	private int _spawnCountControl;
	public GameManager _GM;

	void Start () 
	{
		_spawnLocation = GameObject.Find ("StartPos").transform.position;
		_spawnCountControl = 0;
		_enemyPrefab = Resources.Load ("Enemy")as GameObject;
	}

    public void SpawnInvokeRepeater(JSONObject wavesJSON)
    {
        Debug.Log("Comes wave is: " + wavesJSON);
        _spawnCountControl = 0;
        _enemyCount = int.Parse(wavesJSON.GetField("EnemyCount").ToString());
        _spawnTime = float.Parse(wavesJSON.GetField("SpawnTime").ToString());
        _spawnWaitTime = float.Parse(wavesJSON.GetField("SpawnWaitTime").ToString());
        _GM = GetComponent<GameManager>();
        _GM.enemyCount = _enemyCount;
        InvokeRepeating("Spawn", _spawnWaitTime, _spawnTime);
    }

    void Spawn()
	{
        if (_GM.onPlay)
        {
		    _spawnCountControl++;
		    if (_enemyCount < _spawnCountControl) 
		    {
			    CancelInvoke ("Spawn");
                Destroy(this);
		    }
		    else
		    {
			    GameObject enemy = Instantiate (_enemyPrefab, _spawnLocation, Quaternion.identity)as GameObject;
			    enemy.transform.SetParent (GameObject.Find ("Enemies").transform);
			    enemy.name = "Enemy_" + _spawnCountControl;
			    _GM.enemyList.Add (enemy);
            }
        }
	}
}
