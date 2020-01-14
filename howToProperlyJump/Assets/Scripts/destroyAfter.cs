using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAfter : MonoBehaviour
{
    void Start()
    {
        Object.Destroy(gameObject, 0.5f);
    }
}
