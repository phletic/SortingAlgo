using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;
//master program for the software
public class sort : MonoBehaviour
{
    public bool go;
    public int n, max;
    public float offset;
    public GameObject parent, cube;
    public static List<GameObject> clones = new List<GameObject>();
    public List<float> ArrayDisplayed { get { return _numbers; }set {
            if(fastVisual == true)
            {
                _numbers = value;
                Background.Visualize(offset, parent, cube, ArrayDisplayed, stats, false);
            }else if(fastVisual == false)
            {
                _numbers = value;
                Background.Visualize(offset, parent, cube, ArrayDisplayed, stats, true);
            }
        } }
    [HideInInspector]
    public  bool fastVisual;
    List<float> _numbers;
    private List<List<float>> calculatedResult = new List<List<float>>();
    public float waitTime;

    public Text readyText;
    public Text stats;
    algorithm[] sortingAlgos = { new mergesort(), new insertionsort(), new bubblesort()};
    private void Start()
    {
        ArrayDisplayed = Background.generateNumbers(n, max);
    }
    bool instance;
    IEnumerator slowlyDisplay()
    {
        if (instance == false)
        {
            instance = true;
            for (int i = 0; i < calculatedResult.Count; i++)
            {
                fastVisual = true;
                readyText.text = "iteration " + i + " of " + (calculatedResult.Count - 1).ToString() + " with waitTime of " + waitTime.ToString("0.##");
                ArrayDisplayed = calculatedResult[i];  
                yield return new WaitForSeconds(waitTime);
            }
            calculatedResult.Clear();
            fastVisual = false;
            readyText.text = "iteration done!";
            instance = false;
        }
    }
    public void Display()
    {
           readyText.text = string.Empty;
           StartCoroutine(slowlyDisplay());
    }
    public void Calculate(int n)
    {
        algorithm sortType = sortingAlgos[n];
        calculatedResult.Clear();
        calculatedResult = sortType.implementation(ArrayDisplayed, this);
        readyText.text = "ready to display. Click Display to see sort";
    }
    public void addNumber(float n, int pos)
    {
        ArrayDisplayed.Insert(pos, n);
    }
   // private float previous;
    public void Update()
    {
        //waitTime = slider.value;
    }
}


