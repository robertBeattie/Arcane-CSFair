using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTransform : MonoBehaviour
{
    [SerializeField] private Transform lookAt;
    [SerializeField] private float boundX = 0.30f;
    [SerializeField] private float boundY = 0.10f;

    void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        //Check is in bounds on X axis
        float deltaX = lookAt.position.x - transform.position.x;
        if (deltaX > boundX || deltaX < -boundX) {
            if (transform.position.x < lookAt.position.x) {
                delta.x = deltaX - boundX;
			} else {
                delta.x = deltaX + boundX;
			}
		}

        //Checkis in bounds on Y axis
        float deltaY = lookAt.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY) {
            if (transform.position.y < lookAt.position.y) {
                delta.y = deltaY - boundY;
            } else {
                delta.y = deltaY + boundY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}
