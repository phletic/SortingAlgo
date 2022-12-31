using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class insertionsort : algorithm
{
    List<List<float>> calculatedResult = new List<List<float>>();

    public override List<List<float>> implementation(List<float> unsorted, sort master)
    {
        unsorted = new List<float>(unsorted);
            for (int i = 1; i < unsorted.Count; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if(unsorted[j-1] > unsorted[j])
                    {
                        swap(j,ref unsorted);
                        unsorted = new List<float>(unsorted);
                }
                    else
                    {
                        break;
                    }
                }

            }
        return calculatedResult;
    }
    void swap(int n,ref List<float> inputList)
    {
        float temp = inputList[n-1];
        inputList[n - 1] = inputList[n];
        inputList[n] = temp;
        calculatedResult.Add(inputList);
        Debug.Log("done");
    }
}

