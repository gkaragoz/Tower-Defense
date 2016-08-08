using UnityEngine;
using System.Collections;

public class EnemyHealthBar : MonoBehaviour {
    float _health;
    float _fullHealth;

    RectTransform _rectTransform;
    EnemyManager _enemyManager;

    void Start()
    {
        _enemyManager = transform.parent.gameObject.GetComponent<EnemyManager>();
        _rectTransform = GetComponent<RectTransform>();
        _fullHealth = _enemyManager.Health;
        Debug.Log("ENEMYHEALTHBAR.CS " + _enemyManager.Health);
    }

	void Update () {
        _health = _enemyManager.Health;
        if (_health > 0)
        {
            float healthScale = ((_health * 100) / _fullHealth) / 100f;
            Debug.Log(_health + " * 100 ) / " + _fullHealth + " / 100");
            _rectTransform.localScale = new Vector3(healthScale, 1, 1);
        }

    }
}
