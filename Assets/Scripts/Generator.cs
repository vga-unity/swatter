using UnityEngine;
using System.Collections;

// キューブを補充するスクリプト

public class Generator : MonoBehaviour {
    public int cubeNumber = 20;           // 補充するターゲット数
    public GameObject cubePrefab = null;  // キューブのプレハブ

    IEnumerator Start() {
        while (true) {
            // ターゲット数から現存する数を引いて生成すべき数を求める。
            int num = cubeNumber - GameObject.FindGameObjectsWithTag("Enemy").Length;
            for (int i = 0; i < num; ++i) {
                // ランダムに位置を決定してインスタンス化する。
                Vector3 position = new Vector3(Random.Range(-1.0f, 1.0f), 1.0f, Random.Range(-1.0f, 1.0f)) * 0.4f;
                Instantiate(cubePrefab, position, Quaternion.identity);
            }
            // ちょっと間を置く。
            yield return new WaitForSeconds(8.0f);
        }
    }
}
