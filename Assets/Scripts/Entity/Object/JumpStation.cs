using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpStation : MonoBehaviour
{
    public float jumpPower;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerController>(out PlayerController controller))//PlayerController를 가지고 있으면 점프
        {
            controller.GetComponent<Rigidbody>().AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
        }
    }
}
