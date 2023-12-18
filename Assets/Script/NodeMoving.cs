using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMoving : MonoBehaviour
{
    public float nodeSpeed = 20.0f;
    private Material nodeMaterial;  // ノードのマテリアル
    private Light nodeLight;        // ノードのライト

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 force = new Vector3(0.0f, 0.0f, nodeSpeed * -1.0f);
        rb.AddForce(force, ForceMode.Impulse);

        Renderer renderer = GetComponent<Renderer>();
        nodeMaterial = renderer.material;  // ノードのマテリアルを取得して変数に格納

        Transform transform = GetComponent<Transform>();
        transform.Rotate(new Vector3(0, 0, 90));

        // ノードにアタッチされた Light コンポーネントを取得
        nodeLight = GetComponent<Light>();
    }

    public void SetNodeColor(Color color)
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = color;
    }

    // Emissionの色を設定する関数
    public void SetEmissionColor(Color emissionColor)
    {
        if (nodeMaterial != null)
        {
            // Emissionのキーワードを有効化
            nodeMaterial.EnableKeyword("_EMISSION");

            // Emissionの色を設定
            nodeMaterial.SetColor("_EmissionColor", emissionColor);
        }
    }

    // 光度を変更する関数
    public void SetLightIntensity(float intensity)
    {
        if (nodeLight != null)
        {
            // Lightのintensityを変更
            nodeLight.intensity = intensity;
        }
    }
}
