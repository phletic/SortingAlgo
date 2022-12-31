using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
public class mergesort : algorithm {
    private List<List<float>> Arrays = new List<List<float>>();
    public override List<List<float>> implementation(List<float> unsorted,sort master)
    {
        Arrays.Clear();
        Debug.Log("here");
        MergeSort(unsorted.ToArray(), 0, unsorted.Count - 1,master);
        return Arrays;
    }
    private void Merge(float[] input, int left, int middle, int right)
    {
        float[] leftArray = new float[middle - left + 1];
        float[] rightArray = new float[right - middle];

        Array.Copy(input, left, leftArray, 0, middle - left + 1);
        Array.Copy(input, middle + 1, rightArray, 0, right - middle);

        int i = 0;
        int j = 0;
        for (int k = left; k < right + 1; k++)
        {
            if (i == leftArray.Length)
            {
                input[k] = rightArray[j];
                j++;
            }
            else if (j == rightArray.Length)
            {
                input[k] = leftArray[i];
                i++;
            }
            else if (leftArray[i] <= rightArray[j])
            {
                input[k] = leftArray[i];
                i++;
            }
            else
            {
                input[k] = rightArray[j];
                j++;
            }
        }

    }
    private void MergeSort(float[] input, int left, int right,sort master)
    {
        if (left < right)
        {
            int middle = (left + right) / 2;
            MergeSort(input, left, middle,master);
            MergeSort(input, middle + 1, right,master);
            Merge(input, left, middle, right);
            Arrays.Add(input.ToList());
        }

    }
}
