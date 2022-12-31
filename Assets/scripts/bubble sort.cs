using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubblesort : algorithm
{
    List<List<float>> calculatedResult = new List<List<float>>();

    public override List<List<float>> implementation(List<float> unsorted, sort master)
    {
        unsorted = new List<float>(unsorted);
        bubble(ref unsorted);
        return calculatedResult;
    }
    void bubble(ref List<float> arr)
    {
        int n = arr.Count;
        for (int i = 0; i < n - 1; i++)
            for (int j = 0; j < n - i - 1; j++)
                if (arr[j] > arr[j + 1])
                {
                    // swap temp and arr[i] 
                    float temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    calculatedResult.Add(arr);
                    arr = new List<float>(arr);
                }
    }
}
