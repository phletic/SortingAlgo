using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BongoSort : MonoBehaviour
{
    public int a, b;
    public bool go;
    float[] list;
    public bool auto;
    public float waitTime;
    public int frames;
    public void Start()
    {
        b = a + 1;
    }
    private void Update()
    {
        list = GetComponent<numberDisplay>().numberList;

        if (go == true && auto == false)
        {
            if (check() == false)
            {
                sort();
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
        sort();

    }
    void sort()
    {
        
        for (int i = 0; i < list.Length; i++)
        {
            int a = Random.Range(0, list.Length);
            int b = Random.Range(0  , list.Length);
            GetComponent<numberDisplay>().swapArray(a, b);

        }
        frames += 1;
    }
    bool check()
    {
        int a = 0;
        int b = 1;
        for (int i = 0; i < list.Length - 1; i++)
        {
            if (list[a] > list[b])
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
