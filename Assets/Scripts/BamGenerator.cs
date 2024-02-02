using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamGenerator : MonoBehaviour
{
    [SerializeField] private GameObject Bamsongi;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(Bamsongi, transform.position, Quaternion.identity);
        }
    }
}
