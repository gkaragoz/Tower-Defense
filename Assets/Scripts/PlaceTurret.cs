using UnityEngine;
using System.Collections;

public class PlaceTurret : MonoBehaviour {

    public GameObject turretPrefab;
    private GameObject turret;

	void OnMouseUp () {
	    if (CanPlaceTurret())
            turret = Instantiate(turretPrefab, transform.position, Quaternion.identity) as GameObject;
	}

    bool CanPlaceTurret ()
    {
        return turret == null;
    }
}
