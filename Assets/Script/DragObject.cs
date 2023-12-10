using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 offset;

    private void OnMouseDown()
    {
        // �}�E�X�N���b�N���̃I�u�W�F�N�g�̈ʒu�ƃ}�E�X�J�[�\���̈ʒu�̃I�t�Z�b�g���v�Z
        offset = transform.position - GetMouseWorldPos();
    }

    private void OnMouseDrag()
    {
        // �}�E�X�J�[�\���̈ʒu�ɉ����ăI�u�W�F�N�g���ړ�
        transform.position = GetMouseWorldPos() + offset;
    }

    private Vector3 GetMouseWorldPos()
    {
        // �}�E�X�J�[�\���̈ʒu���X�N���[�����W���烏�[���h���W�ɕϊ�
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.nearClipPlane; 
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
