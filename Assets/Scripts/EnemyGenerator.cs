using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {

	private int _enemyCount;
	private GameObject _enemyPrefab;
	private Vector3 _spawnLocation;
	private float _spawnTime;
	private float _spawnWaitTime;
	private int _spawnCountControl;
	private GameManager _GM;

	// Use this for initialization
	void Start () 
	{
		_enemyCount = 5;
		_spawnLocation = GameObject.Find ("StartPos").transform.position;
		_GM = GameObject.Find ("GM").GetComponent<GameManager>();
		_spawnTime = 1.5f;
		_spawnWaitTime = 0.5f;
		_spawnCountControl = 0;
		_enemyPrefab = Resources.Load ("Enemy")as GameObject;
		InvokeRepeating("Spawn", _spawnWaitTime, _spawnTime);
	}

	void Spawn()
	{
		_spawnCountControl++;
		if (_enemyCount < _spawnCountControl) 
		{
			CancelInvoke ("Spawn");
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
