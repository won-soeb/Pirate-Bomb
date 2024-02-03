using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] items;
    public void GenItem(Vector2 position)
    {
        int rand = Random.Range(0, items.Length);
        Instantiate(items[rand], position, Quaternion.identity);
    }
}
