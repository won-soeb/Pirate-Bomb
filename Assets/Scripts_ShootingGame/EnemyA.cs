using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : EnemyGroup
{
    [SerializeField] private float moveSpeed = 0.01f;
    private void Update()
    {
        transform.Translate(-transform.up * moveSpeed / 10);
        Destroy(gameObject, 7);
    }
}
