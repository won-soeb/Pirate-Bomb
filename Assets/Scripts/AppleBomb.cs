using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleBomb : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        transform.Translate(Vector3.down * speed);
        if (transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }
}
