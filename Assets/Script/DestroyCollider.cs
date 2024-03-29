using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // ノードがColliderに触れた場合
        if (other.CompareTag("NodeTagEX") || other.CompareTag("NodeTagIN"))
        {
            // ノードを破棄
            Destroy(other.gameObject);
        }
    }
}
