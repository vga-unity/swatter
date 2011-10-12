#pragma strict

// タッチでキューブを叩く処理のスクリプト

// 空振りエフェクト
var missFx : GameObject;

// 当たり判定の大きさ。
var collisionRadius = 0.5;

function Update() {
    // 各タッチ点を順に処理する。
    for (var touch in Input.touches) {
        // タッチのフェーズが「開始」であれば……
        if (touch.phase == TouchPhase.Began) {
            // コリジョンのチェックを行う。
            CheckCollision(touch.position);
        }
    }
}

// 指定されたスクリーン位置でのコリジョンチェックを行う関数。
private function CheckCollision(screenPosition : Vector3) {
    // ワールド座標への変換を行う。変換後の高さは床の高さとする。
    screenPosition.z = camera.transform.position.y;
    var worldPosition = camera.ScreenToWorldPoint(screenPosition);
    // 命中フラグ。
    var hitFlag = false;
    // 指定した座標の球と重なっている Collider を列挙する。
    for (var collider in Physics.OverlapSphere(worldPosition, collisionRadius)) {
        // 相手のタグが Enemy であれば、ダメージメッセージを送信する。
        if (collider.gameObject.tag == "Enemy") {
            collider.gameObject.SendMessage("ApplyDamage");
            hitFlag = true;
        }
    }
    // 空振りの場合にエフェクトを出す。
    if (!hitFlag) Instantiate(missFx, worldPosition, Quaternion.identity);
}
