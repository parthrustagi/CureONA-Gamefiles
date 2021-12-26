using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float timetoDestroy = 2f;

    public void Start()
    {
        Destroy(gameObject, timetoDestroy);
    }

}
