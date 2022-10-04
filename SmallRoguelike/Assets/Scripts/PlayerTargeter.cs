using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargeter : MonoBehaviour
{
    void Update()
    {
        transform.position = PlayerController.instance.transform.position;
    }
}
