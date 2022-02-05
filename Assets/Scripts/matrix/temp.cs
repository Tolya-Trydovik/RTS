using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour
{
    public int[,] matrix = new int[3, 3];
    void Start()
    {
        int value = 1;
        for(int row = 0; row < 3; row++)
            for(int col = 0; col < 3; col++)
            {
                Debug.Log($"Row: {row}\nCol: {col}\nValue: {value}");
                matrix[row, col] = value;
                value++;
            }
    }

    void Update()
    {
        
    }
}
