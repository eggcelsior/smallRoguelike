using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    private GameObject target;
    public Camera cam;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        CameraController.instance.transform.SetParent(target.transform);
    }
    public void ChangeTarget(GameObject newTarget)
    {
        target = newTarget;
        CameraController.instance.transform.SetParent(target.transform);
    }
    private void Update()
    {
        if(cam.transform.position.z != -10)
        {
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, -10);
        }
    }
}
