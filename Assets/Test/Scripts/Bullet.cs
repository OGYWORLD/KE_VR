using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody bulletRig;

    private void OnEnable()
    {
        bulletRig.AddForce(0f, 0f, 500f);
        StartCoroutine(HideBullet());
    }

    IEnumerator HideBullet()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
