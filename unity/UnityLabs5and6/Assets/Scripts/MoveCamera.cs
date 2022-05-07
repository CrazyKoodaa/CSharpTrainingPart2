using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform Player;
    public float Angle = 0.25f;
    public float ZoomSpeed = 0.25f;

    // Update is called once per frame
    void Update()
    {
        var scrollWheelValue = Input.GetAxis("Mouse ScrollWheel");

        if (scrollWheelValue != 0)
        {
            transform.position *= (1f + scrollWheelValue * ZoomSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(Player.position, Vector2.down, Angle);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(Player.position, Vector2.up, Angle);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.RotateAround(Player.position, Vector2.right, Angle);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.RotateAround(Player.position, Vector2.left, Angle);

        }
       

         transform.LookAt(Player.position);
    }
}
