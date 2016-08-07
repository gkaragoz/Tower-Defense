using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnemyManager : MonoBehaviour {
    [SerializeField]
    private List<GameObject> _path;
    private int _pathIndex;
    private Transform _target;
    private PlayerManager _player;

    public float _speed;

	void Start () {
        _path = GameObject.FindGameObjectsWithTag("Path").Reverse().ToList();
        _pathIndex = 0;
        _target = _path[_pathIndex].transform;
        _player = GameObject.Find("GM").GetComponent<PlayerManager>();
	}
	
	void Update () {
        Move();
	}

    void Move ()
    {
        Vector3 dir = _target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        _target = _path[_pathIndex].transform;

        if (transform.position == _target.position && _pathIndex < _path.Count - 1)
            _pathIndex++;
    }

    public void Hit ()
    {
        _player.Health--;
    }
}

public class EnemyData
{

}