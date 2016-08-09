using UnityEngine;
using System.Collections;

public class PlaceTurret : MonoBehaviour {
	//That class holds turrets where can be place.
    public GameObject turretPrefab;		//Turret prefab.
	private GameObject turret;			//Turren gameObject.
    private GameManager _GM;

    void Start()
    {
        _GM = GameObject.Find("GM").GetComponent<GameManager>();
    }

	//When mouse clicked.
	void OnMouseUp () {
        if (_GM.onPlay)
        {
            //Is there any turret on mouse clicked position?
            if (CanPlaceTurret())
            {
                //If there's no turret at clicked point, than Instantiate a turret at clicked position.
                turret = Instantiate(turretPrefab, transform.position, Quaternion.identity) as GameObject;
                turret.transform.SetParent(GameObject.Find("Towers").transform);
            }
        }
	}

	//Checking turret at clicked position.
    bool CanPlaceTurret ()
    {
        return turret == null;
    }
}
