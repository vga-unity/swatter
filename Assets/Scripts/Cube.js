#pragma strict

// キューブを制御するスクリプト

var power = 4.0;                // 動きの強さ
var interval = 0.8;             // 動きを発動する間隔
var explosionFx : GameObject;   // 破壊時のエフェクト

function Start() {
    while (true) {
        // ランダムに力の方向を決める。
        var direction = Vector3(Random.Range(-1.0, 1.0), Random.Range(0.0, 1.0), Random.Range(-1.0, 1.0));
        // インパルスとして力を加える。
        rigidbody.AddForce(direction * power, ForceMode.Impulse);
        // 間隔をおく。
        yield WaitForSeconds(interval);
    }
}

// ダメージメッセージの処理。
function ApplyDamage() {
    // 爆発エフェクトを現在位置に生成する。
    Instantiate(explosionFx, transform.position, transform.rotation);
    // ゲームオブジェクトを破棄する。
    Destroy(gameObject);
}
