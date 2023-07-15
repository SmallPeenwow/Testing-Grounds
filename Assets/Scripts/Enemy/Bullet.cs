using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Transform hitTransfomr = collision.transform;

        if (hitTransfomr.CompareTag("Player"))
        {
            Debug.Log("Hit Player");
            hitTransfomr.GetComponent<PlayerHealth>().TakeDamage(10);
        }

        Destroy(gameObject);
    }
}
