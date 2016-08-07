using UnityEngine;
using System.Collections;

public class BaseManager : MonoBehaviour {

    private PlayerManager player;

    void Start()
    {
        player = GameObject.Find("GM").GetComponent<PlayerManager>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            other.gameObject.GetComponent<EnemyManager>().Hit();
        }
    }
}
