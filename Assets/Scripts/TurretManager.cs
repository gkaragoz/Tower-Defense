using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurretManager : MonoBehaviour {

	private float _range;					//Turret's range.
	private int _damage;					//Turret's damage.
	private float _bulletSpeed;
	private float _attackSpeed;
	private float _currentTime;

	private BulletController _bullet;		//Turret's bullet.
	private GameObject _bulletPrefab;
	private GameObject _targetEnemy;		//Enemy which is inside of range.
	private List<GameObject> _entryList = new List<GameObject>();	//Enemies list which is inside of range.
	private GameManager _GM;
	private CircleCollider2D _collider;

	private float _distance;


	void Start()
	{
		_attackSpeed=0.25f;
		_currentTime = _attackSpeed;
		_range = 5f;
		_damage = 1;
		_bulletSpeed = 10f;
		_bulletPrefab = Resources.Load ("Bullet") as GameObject;
		_GM = GameObject.Find ("GM").GetComponent<GameManager>();
		_collider = gameObject.AddComponent<CircleCollider2D> ();
        _collider.isTrigger = true;
		_collider.radius = _range;
	}

	void Update ()
	{
		if (_entryList.Count > 0) {
			_targetEnemy = _entryList [0];
			if (!_targetEnemy.GetComponent<EnemyManager> ().isDeath ()) {
				Look (_targetEnemy.transform.position);
				if (_currentTime >= _attackSpeed) {
					Fire ();
					_currentTime = 0;
				}
			} else {
				_entryList.Remove (_targetEnemy);
				_targetEnemy = null;
			}
		} else {
			_targetEnemy = null;
		}
		_currentTime += Time.deltaTime;

	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Enemy")) {
			_entryList.Add (other.gameObject);
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Enemy")) 
		{
			_entryList.Remove (other.gameObject);
		}
	}

	void Look (Vector3 target)
	{
		Vector3 dir = target - transform.position;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
	
	void Fire() 
	{
        _bullet = (Instantiate (_bulletPrefab, transform.position, Quaternion.identity)as GameObject).GetComponent<BulletController>();
		_bullet.speed = _bulletSpeed;
		_bullet.target = _targetEnemy;
		_bullet.damage = _damage;
    }
}