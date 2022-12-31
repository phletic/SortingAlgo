using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleSort : MonoBehaviour
{
    [SerializeField]
    float[] arr;
    [SerializeField]
    bool go,auto;
    public float waitTime;
    public float frames;
    // Start is called before the first frame update
    void Start()
    {    }

    // Update is called once per frame
    void Update()
    {
        arr = GetComponent<numberDisplay>().numberList;

        if (go == true && auto == false)
        {
            if (check() == false)
            {
                swap();
                go = false;
            }
            else
            {
                GetComponent<numberDisplay>().ColorGreen();
            }
        }
        if (auto == true)
        {
            if (check() == false)
            {
                StartCoroutine(SelfSort());
                go = false;
            }
            else
            {
                GetComponent<numberDisplay>().ColorGreen();
            }
        }
    }
    IEnumerator SelfSort()
    {
        yield return new WaitForSeconds(waitTime);
        swap();
    }
    public int a = 0;
    public int b = 1;
    void swap()
    {
        try
        {
            float n1 = arr[a];
            float n2 = arr[b];
            if (n1 > n2)
            {
                GetComponent<numberDisplay>().swapArray(a, b);
                a++;
                b++;
            }
            else
            {
                a++;
                b++;
                return;
            }
        }
        catch(Exception e)
        {
            Debug.Log(e);
            a = 0;
            b = 1;
            swap();
        }
        frames++;
    }
    bool check()
    {
        int a = 0;
        int b = 1;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            if (arr[a] > arr[b])
            {
                return false;
            }
            else
            {
                a += 1;
                b += 1;
            }
        }
        return true;
    }
}
