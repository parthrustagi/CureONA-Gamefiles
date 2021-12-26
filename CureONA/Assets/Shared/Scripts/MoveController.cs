using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    void Update()
    {
        print("Move Controller");    
    }

    public void Move(Vector2 direction)
    {
	    transform.position += transform.forward * direction.x * Time.deltaTime + transform.right * direction.y * Time.deltaTime;
    }
}
