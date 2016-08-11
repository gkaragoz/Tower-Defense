using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEditor;

public class BaseManager : MonoBehaviour {
    private Sprite [] _numberSprites;
    private SpriteRenderer _number;
    //private PlayerManager player;
	private GameManager _GM;

	private int _health;

	public int Health
	{
		get { return _health; }
		set { _health = value;
            _number.sprite = _numberSprites[_health];
            if (_health <= 0)
            {
                Die();
            }
        }
	}

    void Start()
    {
        _health = 9;
        _numberSprites = Resources.LoadAll<Sprite>(@"Sprites/Numbers");
        _number = transform.FindChild("Number").GetComponent<SpriteRenderer>();
        _number.sprite = _numberSprites[_health];

		_GM = GameObject.Find ("GM").GetComponent<GameManager>();
        //player = GameObject.Find("GM").GetComponent<PlayerManager>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy")
        {
			Health--;
            other.GetComponent<EnemyManager>().Destroy();
		}
    }

    void Die()
    {
        //Die utilies will come to here.
    }
}
