using UnityEngine;
using System.Collections;

// キューブの制御

public class Cube : MonoBehaviour {
    public float power = 4.0f;             // 動きの強さ
    public float interval = 0.8f;          // 動きを発動する間隔
    public GameObject explosionFx = null;  // 破壊時のエフェクト

    IEnumerator Start () {
        while (true) {
            // ランダムに力の方向を決める。
            Vector3 direction = new Vector3(Random.Range(-1.0f, 1.0f),
                                            Random.Range(0.0f, 1.0f),
                                            Random.Range(-1.0f, 1.0f));
            // インパルスとして力を加える。
            rigidbody.AddForce(direction * power, ForceMode.Impulse);
            // 間隔をおく。
            yield return new WaitForSeconds(interval);
        }
    }

    // ダメージメッセージの処理。
    void ApplyDamage() {
        // 爆発エフェクトを現在位置に生成する。
        Instantiate(explosionFx, transform.position, transform.rotation);
        // ゲームオブジェクトを破棄する。
        Destroy(gameObject);
    }
}
