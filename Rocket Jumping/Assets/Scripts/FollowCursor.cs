using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    Vector3 worldPosition;
    public Transform playerOffset;
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, -Camera.main.transform.position.z));

        worldPosition.z = 0f;
        
        transform.position = worldPosition;

    }
}
