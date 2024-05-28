using UnityEngine;
using System.Collections;

public class ChangeSpriteAlpha : MonoBehaviour
{
    // 透明度を変更したいSprite Renderer
    public SpriteRenderer spriteRenderer;
    public AudioClip sound1;           // sound1 はインスペクターで設定する
    private AudioSource audioSource;

    // 新しい透明度
    public float newAlpha = 1.0f; // 1.0fで完全に不透明、0.0fで完全に透明
    private bool gogo = false;

    void Start()
    {

        audioSource = GetComponent<AudioSource>();

        // もし指定されたspriteRendererがなければ、自動的に現在のGameObjectからSpriteRendererを探す
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        StartCoroutine(SetVariableTrueAtRandomTime());
        
    }

    // 透明度を変更する関数
    public void ChangeAlpha(float alpha)
    {
        // SpriteRendererのカラーを取得して、透明度だけを変更して、再設定する
        Color color = spriteRenderer.color;
        color.a = alpha;
        spriteRenderer.color = color;
    }


    IEnumerator SetVariableTrueAtRandomTime()
    {
        // ランダムな時間（0秒から180秒の間）を選びます
        float randomTime = Random.Range(0f, 180f);

        // 選ばれた時間だけ待ちます
        yield return new WaitForSeconds(randomTime);

        // 変数をTrueに設定します
        ChangeAlpha(newAlpha);
        audioSource.Play();

        // デバッグ用のログ
        Debug.Log("Variable set to true at: " + Time.time + " seconds");
    }
}
