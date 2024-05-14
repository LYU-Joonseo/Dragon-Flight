using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float moveSpeed = 3f;
    // Update is called once per frame
    void Update(){
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;

        if(transform.position.y <= -9){
            transform.position += new Vector3(0, 17.5f, 0);
        }
    }
}
