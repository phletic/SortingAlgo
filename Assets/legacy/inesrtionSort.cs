using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class inesrtionSort : MonoBehaviour
{
    public List<float> arr = new List<float>();
    public bool go;
    [SerializeField]float _wt;
    public List<float> sortedList;
    public float frames;
    // Start is called before the first frame update
    void Start()
    {
        arr = GetComponent<numberDisplay>().numberList.ToList<float>();
    }

    // Update is called once per frame
    void Update()
    {
        if(go == true)
        {
            StartCoroutine(autoSort());         
       }
    }
    IEnumerator autoSort()
    {
        sort();
        yield return new WaitForSeconds(_wt);
    }
    void sort()
    {
    
        if (sortedList.Count < arr.Count)
        {
            float test = arr[sortedList.Count];
            if (sortedList.Count == 0)
            {
                sortedList.Add(test);
            }
            else if(sortedList.Count > 0)
            {
                bool addAtBack = false;
                for (int i = 0; i < sortedList.Count; i++)
                {
                    if (test < sortedList[i])
                    {
                        addAtBack = false;
                        sortedList.Insert(i, test);
                        break;
                    }
                    addAtBack = true;
                }
                if(addAtBack == true)
                {
                    sortedList.Add(test);                
                }
            }
            GetComponent<numberDisplay>().numberList = sortedList.ToArray();
            GetComponent<numberDisplay>().DisplayNumber();
            frames++;
        }
        else
        {
            GetComponent<numberDisplay>().ColorGreen();
            Debug.Log("done");

        }

        
    }
}
