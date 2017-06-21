using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour {

    [SerializeField]
    AudioSource source;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (enabled)
        {
            if (source != null) source.PlayOneShot(source.clip);
            enabled = false;
        }
    }
}
