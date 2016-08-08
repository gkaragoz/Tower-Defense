using UnityEngine;
using System.Collections;

public class FixHealthBarRotation : MonoBehaviour {
    public float verticalOffset = 0.35f;
    Quaternion rotation;
    RectTransform _rectTransform;

    void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        rotation = _rectTransform.rotation;
    }

    void LateUpdate()
    {
        _rectTransform.rotation = rotation;
        transform.position = new Vector3(transform.parent.position.x, 
                                        transform.parent.position.y + verticalOffset, 
                                        transform.parent.position.z) ;
    }
}
