using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class mergeSort : MonoBehaviour
{
    [SerializeField]
    float[] arr;
    public bool go;
    public float frames;
    public float _wt;
    // Start is called before the first frame update
    void Start()
    {
        arr = GetComponent<numberDisplay>().numberList;
        if (go == true)
        {
            Sort(0, arr.Length - 1);
            go = false;
        }
        GetComponent<numberDisplay>().numberList = arr;
        GetComponent<numberDisplay>().DisplayNumber();
        GetComponent<numberDisplay>().ColorGreen();
    }

    // Update is called once per frame
    void Update()
    {

     
   
    }
    
    void Sort(int l, int r)
    {
        if (l < r)
        {
            // Same as (l+r)/2, but avoids overflow for 
            // large l and h 
            int m = l + (r - l) / 2;
            // Sort first and second halves 
            Sort(l, m);
            Sort(m + 1, r);
            merge(l, m, r);
            frames ++;
        }
    }
    void merge(int l, int m, int r)
    {
        int i, j, k;
        int n1 = m - l + 1;
        int n2 = r - m;

        /* create temp arrays */
        float[] L = new float[n1];
        float[] R = new float[n2];

        /* Copy data to temp arrays L[] and R[] */
        for (i = 0; i < n1; i++)
            L[i] = arr[l + i];
        for (j = 0; j < n2; j++)
            R[j] = arr[m + 1 + j];

        /* Merge the temp arrays back into arr[l..r]*/
        i = 0; // Initial index of first subarray 
        j = 0; // Initial index of second subarray 
        k = l; // Initial index of merged subarray 
        while (i < n1 && j < n2)
        {
            if (L[i] <= R[j])
            {
                arr[k] = L[i];
                i++;
            }
            else
            {
                arr[k] = R[j];
                j++;
            }
            k++;
        }

        /* Copy the remaining elements of L[], if there 
           are any */
        while (i < n1)
        {
            arr[k] = L[i];
            i++;
            k++;
        }

        /* Copy the remaining elements of R[], if there 
           are any */
        while (j < n2)
        {
            arr[k] = R[j];
            j++;
            k++;
        }
    }

}
