using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellHandler : MonoBehaviour
{
    [SerializeField] GameObject FlameBallPF;
    private void Start()
    {
        InvokeRepeating("FireFlameBall", FlameBallHandler.globalCooldown, 1);
    }


    public void FireFlameBall()
    {
        GameObject obj = Instantiate(FlameBallPF, transform.position, transform.rotation);
    }
}
