#pragma strict

// キューブを補充するスクリプト

// 補充するターゲット数
var cubeNumber = 60;

// キューブのプレハブ
var cubePrefab : GameObject;

function Start() {
    while (true) {
        // ターゲット数から現存する数を引いて生成すべき数を求める。
        var num = cubeNumber - GameObject.FindGameObjectsWithTag("Enemy").Length;
        for (var i = 0; i < num; ++i) {
            // ランダムに位置を決定してインスタンス化する。
            var position = Vector3(Random.Range(-1.0, 1.0), 1.0, Random.Range(-1.0, 1.0)) * 0.4;
            Instantiate(cubePrefab, position, Quaternion.identity);
        }
        // ちょっと間を置く。
        yield WaitForSeconds(8.0);
    }
}
