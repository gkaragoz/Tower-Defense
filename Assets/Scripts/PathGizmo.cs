using UnityEngine;
using System.Collections;

public class PathGizmo : MonoBehaviour {
    private int _childCount;

    void Start()
    {
        _childCount = transform.childCount;
    }

    void OnDrawGizmos()
    {
        int i = 0;
        Transform prevChild = null;

        foreach(Transform child in transform)
        {
            if (i > 0 && i < transform.childCount && prevChild != null)
            {
                Gizmos.DrawLine(prevChild.position, child.position);
                Debug.Log("Drawing");
            }
            i++;
            prevChild = child;
        }
    }
}
