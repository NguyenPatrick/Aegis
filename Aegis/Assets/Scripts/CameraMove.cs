using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

    public GameObject target;
    private Vector3 newPosition;
    private const float minX = 18f;
    private const float maxX = 45f;
    private const float minY = -24.5f;
    private const float maxY = -19.5f;


    void Start()
    {
        //newPosition.y = target.transform.position.y;
        newPosition.z = -1;
    }
    void Update()
    {
       
        newPosition.y = target.transform.position.y;

        if (target.transform.position.x >= minX && target.transform.position.x <= maxX)
        {
            newPosition.x = target.transform.position.x;
        }

        if (target.transform.position.y >= minY && target.transform.position.y <= maxY)
        {
            newPosition.y = target.transform.position.y;
        }

        transform.position = newPosition;
        
    }
}
