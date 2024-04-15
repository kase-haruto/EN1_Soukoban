using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript
    : MonoBehaviour {

    /// <summary>
    /// �z��̕\�����s���܂�
    /// </summary>
    void PrintArray() {
        string debugText = "";
        for (int i = 0; i < map.Length; i++) {
            debugText += map[i].ToString() + ",";
        }
        Debug.Log(debugText);
    }

    /// <summary>
    /// �v���C���[�̍��W�̗v�f�ԍ���Ԃ��܂�
    /// </summary>
    /// <returns>�v���C���[�̂���v�f�ԍ�</returns>
    int GetPlayerIndex() {
      for (int i = 0; i < map.Length; i++) {
            if (map[i]==1) {
                return i;
            }
        }
      return -1;
    }

    /// <summary>
    /// �ړ��������s���܂�
    /// </summary>
    /// <param name="num"></param>
    /// <param name="moveFrom"></param>
    /// <param name="moveTo"></param>
    /// <returns>�ړ��ł��邩�𔻒肵�܂�</returns>
    bool MoveNumber(int num, int moveFrom, int moveTo) {
        // �ړ��悪�͈͊O�Ȃ�ړ��s��
        if (moveTo < 0 || moveTo >= map.Length) {
            return false;
        }

        // �ړ����2��������
        if (map[moveTo] == 2) {
            // �ǂ̕����ֈړ����邩���Z�o
            int velocity = moveTo - moveFrom;

            // ���̈ړ�����moveNumber���\�b�h����moveNumber���\�b�h���Ăя������ċN���Ă���
            bool success = MoveNumber(2, moveTo, moveTo + velocity);

            // �������̈ړ������s������v���C���[�̈ړ������s
            if (!success) {
                return false;
            }
        }

        // �v���C���[���ړ�
        if (map[moveTo] == 0) {
            map[moveTo] = num;
            map[moveFrom] = 0;
            return true;
        }

        return false; // �v���C���[�̈ړ����0���Ȃ��ꍇ�͈ړ��s��
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

        //�E�̃L�[���������Ƃ�
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            Debug.Log(Input.GetKeyDown(KeyCode.RightArrow));
            targetIndex = GetPlayerIndex();
            //�z��map��1�������Ă���v�f�ԍ������߂�
            MoveNumber(1, targetIndex, targetIndex + 1);
            //�z��̕\��
            PrintArray();
        }

        //���̃L�[���������Ƃ�
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {

            targetIndex = GetPlayerIndex();
            //�z��map��1�������Ă���v�f�ԍ������߂�
            MoveNumber(1, targetIndex, targetIndex - 1);
            //�z��̕\��
            PrintArray();
        }

    }

}
