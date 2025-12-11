using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChestDrop : MonoBehaviour
{


    public ChestItem[] items;
    [HideInInspector]
    public ChestItem droppedItem;
    float[] table;

    private void Start()
    {
        table = new float[items.Length];
        items = items.OrderByDescending(x => x.dropchancePrecentage).ToArray();
        for (int i = 0; i < items.Length; i++)
        {
            table[i] = items[i].dropchancePrecentage;
        }

    }
    public void Open()
    {
        float total = 0;
        foreach (float chance in table)
        {
            total += chance;
        }
        float randomNumber = Random.Range(0, total);
        for (int i = 0; i < table.Length; i++)
        {
            if (randomNumber <= table[i])
            {
                Debug.Log(items[i].name);
                droppedItem = items[i];
                return;
            }
            else
            {
                randomNumber -= table[i];
            }

        }

    }
}
