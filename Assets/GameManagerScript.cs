using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript
    : MonoBehaviour {

    /// <summary>
    /// 配列の表示を行います
    /// </summary>
    void PrintArray() {
        string debugText = "";
        for (int i = 0; i < map.Length; i++) {
            debugText += map[i].ToString() + ",";
        }
        Debug.Log(debugText);
    }

    /// <summary>
    /// プレイヤーの座標の要素番号を返します
    /// </summary>
    /// <returns>プレイヤーのいる要素番号</returns>
    int GetPlayerIndex() {
      for (int i = 0; i < map.Length; i++) {
            if (map[i]==1) {
                return i;
            }
        }
      return -1;
    }

    /// <summary>
    /// 移動処理を行います
    /// </summary>
    /// <param name="num"></param>
    /// <param name="moveFrom"></param>
    /// <param name="moveTo"></param>
    /// <returns>移動できるかを判定します</returns>
    bool MoveNumber(int num, int moveFrom, int moveTo) {
        // 移動先が範囲外なら移動不可
        if (moveTo < 0 || moveTo >= map.Length) {
            return false;
        }

        // 移動先に2がいたら
        if (map[moveTo] == 2) {
            // どの方向へ移動するかを算出
            int velocity = moveTo - moveFrom;

            // 箱の移動処理moveNumberメソッド内でmoveNumberメソッドを呼び処理が再起している
            bool success = MoveNumber(2, moveTo, moveTo + velocity);

            // もし箱の移動が失敗したらプレイヤーの移動も失敗
            if (!success) {
                return false;
            }
        }

        // プレイヤーを移動
        if (map[moveTo] == 0) {
            map[moveTo] = num;
            map[moveFrom] = 0;
            return true;
        }

        return false; // プレイヤーの移動先に0がない場合は移動不可
    }



    // Start is called before the first frame update
    int[] map;
    string debugText = "";
    void Start() {
        map = new int[] { 0, 0, 0, 1, 0, 2, 0, 0, 0 };
        PrintArray();
    }



    // Update is called once per frame
    void Update() {
        int targetIndex = -1;

        //右のキーを押したとき
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            Debug.Log(Input.GetKeyDown(KeyCode.RightArrow));
            targetIndex = GetPlayerIndex();
            //配列mapの1が入っている要素番号を求める
            MoveNumber(1, targetIndex, targetIndex + 1);
            //配列の表示
            PrintArray();
        }

        //左のキーを押したとき
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {

            targetIndex = GetPlayerIndex();
            //配列mapの1が入っている要素番号を求める
            MoveNumber(1, targetIndex, targetIndex - 1);
            //配列の表示
            PrintArray();
        }

    }

}
