using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    [SerializeField]
    private int _gold;

    public int Gold
    {
        get { return _gold; }
        set { _gold = value; }
    }

    void Start () {
        _gold = 0;
	}
}
