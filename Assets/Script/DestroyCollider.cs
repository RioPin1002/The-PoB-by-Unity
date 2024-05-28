using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // ノードがColliderに触れた場合
        if (other.CompareTag("NodeTagU") || other.CompareTag("NodeTagD") || other.CompareTag("NodeTagR") || other.CompareTag("NodeTagL"))
        {

            float xCoordinate = other.transform.position.x;

            if (xCoordinate < -2){

            }


            // ノードを破棄
            Destroy(other.gameObject);
        }
    }
}
