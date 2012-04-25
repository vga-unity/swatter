using UnityEngine;
using System.Collections;

// タッチでキューブを叩く処理

public class Swatter : MonoBehaviour {
    public GameObject missFx;              // 空振りエフェクト
    public float collisionRadius = 0.1f;   // 当たり判定の大きさ。

    void Update() {
        // 各タッチ点を順に処理する。
        foreach (Touch touch in Input.touches) {
            // タッチのフェーズが「開始」であれば……
            if (touch.phase == TouchPhase.Began) {
                // コリジョンのチェックを行う。
                CheckCollision(touch.position);
            }
        }
    }
    
    // 指定されたスクリーン位置でのコリジョンチェックを行う関数。
    private void CheckCollision(Vector3 screenPosition) {
        // ワールド座標への変換を行う。変換後の高さは床の高さとする。
        screenPosition.z = camera.transform.position.y;
        Vector3 worldPosition = camera.ScreenToWorldPoint(screenPosition);
        // 命中フラグ。
        bool hitFlag = false;
        // 指定した座標の球と重なっている Collider を列挙する。
        foreach (Collider collider in Physics.OverlapSphere(worldPosition, collisionRadius)) {
            // 相手のタグが Enemy であれば、ダメージメッセージを送信する。
            if (collider.gameObject.tag == "Enemy") {
                collider.gameObject.SendMessage("ApplyDamage");
                hitFlag = true;
            }
        }
        // 空振りの場合にエフェクトを出す。
        if (!hitFlag) Instantiate(missFx, worldPosition, Quaternion.identity);
    }
}
