using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBallHandler : MonoBehaviour
{
    public static float globalCooldown = 0.1f;
    private  float duration = 1f;
    private  float speed = 10f;

    private void Awake()
    {
        transform.Rotate(0f,0f,(float)Random.Range(0, 359),0f);
        GetComponent<Rigidbody>().velocity = transform.right * speed;
    }

    private void Update()
    {
        DestroyOnDuration();
    }

    private void DestroyOnDuration()
    {
        duration -= Time.deltaTime;
        if (duration < 0f)
        {
            Destroy(this.gameObject);
        }
    }
}
