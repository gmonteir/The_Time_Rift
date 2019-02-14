using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public int y_min, y_max;
    public float camera_speed;
    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPos = cam.WorldToScreenPoint(target.transform.position);
        print(screenPos);

        transform.position = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);

        if (screenPos.y < y_min)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - camera_speed, transform.position.z);
        }

        if (screenPos.y > y_max)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + camera_speed, transform.position.z);
        }

    }
}
