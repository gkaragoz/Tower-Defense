using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnemyManager : MonoBehaviour {
    private List<GameObject> _path;		//Enemy move points list.
    private int _pathIndex;				//Counter of which point on now.
    private Transform _target;			//Enemy's next movement point.
	private int _health;
	//    private PlayerManager _player;
	public int Health
	{
		get { return _health; }
		set { _health = value; }
	}



    public float _speed;				//Enemy movement speed.

	void Start () {
		//Before adding path on scene, it's orderBy.
        _path = GameObject.FindGameObjectsWithTag("Path").OrderBy(a => a.name).ToList();
		//Initializing next movement counter.
        _pathIndex = 0;
		//First point set.
        _target = _path[_pathIndex].transform;
//        _player = GameObject.Find("GM").GetComponent<PlayerManager>();
		_health=10;
	}

	void Update () {
        Move();
		if (isDeath())
			Destroy (gameObject);
	}

    void Move ()
    {
		//Enemy look at to target point.
        Vector3 dir = _target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		//Makes enemy movement to target point.
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        _target = _path[_pathIndex].transform;

		//When enemy came to target point, target point changed with next point.
        if (transform.position == _target.position && _pathIndex < _path.Count - 1)
            _pathIndex++;
    }

	public bool isDeath()
	{
		if (Health <= 0 || !gameObject.activeSelf)
			return true;
		else
			return false;
	}


}