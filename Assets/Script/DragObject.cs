using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 offset;

    private void OnMouseDown()
    {
        // マウスクリック時のオブジェクトの位置とマウスカーソルの位置のオフセットを計算
        offset = transform.position - GetMouseWorldPos();
    }

    private void OnMouseDrag()
    {
        // マウスカーソルの位置に応じてオブジェクトを移動
        transform.position = GetMouseWorldPos() + offset;
    }

    private Vector3 GetMouseWorldPos()
    {
        // マウスカーソルの位置をスクリーン座標からワールド座標に変換
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.nearClipPlane; 
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
