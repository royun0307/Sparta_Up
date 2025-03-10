using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpStation : MonoBehaviour
{
    public float jumpPower;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerController>(out PlayerController controller))
        {
            controller.GetComponent<Rigidbody>().AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
            Debug.Log(1);
        }
    }
}
