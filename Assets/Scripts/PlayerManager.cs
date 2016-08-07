using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    [SerializeField]
    private int _health, _gold;

    public int Health
    {
        get { return _health; }
        set { _health = value;}
    }
    public int Gold
    {
        get { return _gold; }
        set { _gold = value; }
    }

    void Start () {
        _health = 10;
        _gold = 0;
	}
}
