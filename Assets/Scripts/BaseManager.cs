using UnityEngine;
using System.Collections;
using System.Linq;

public class BaseManager : MonoBehaviour {

    //private PlayerManager player;
	private GameManager _GM;

	private int _health;

	public int Health
	{
		get { return _health; }
		set { _health = value; }
	}

    void Start()
    {
		_health = 10;
		_GM = GameObject.Find ("GM").GetComponent<GameManager>();
        //player = GameObject.Find("GM").GetComponent<PlayerManager>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy")
        {
			Health--;
			other.gameObject.SetActive(false);
			_GM.enemyList.RemoveAt (_GM.enemyList.IndexOf(other.gameObject));
		}
    }
}
