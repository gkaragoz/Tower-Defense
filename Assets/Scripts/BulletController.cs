using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	public GameObject target;
	public float speed;
	public int damage;

	void Move()
	{
		Vector3 dir = target.transform.position - transform.position;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

	}

	void Update()
	{
		if (target != null)
			Move ();
		else
			Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Enemy")) {
			other.gameObject.GetComponent<EnemyManager> ().Health -=damage;
			Destroy (gameObject);
		}
	}
}
