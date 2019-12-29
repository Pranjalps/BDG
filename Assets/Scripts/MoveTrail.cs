using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// move the bullet forward
/// </summary>
public class MoveTrail : MonoBehaviour
{
    public float speed = 230f;//speed of trail
    private void Update()
    {


        transform.Translate(Vector3.right * Time.deltaTime * speed);//move trail forward
        Destroy(gameObject, 3f);//destroy trail after 3 seconds
    }
}
