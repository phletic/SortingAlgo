using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class Background : MonoBehaviour
{
    static float min, max, lerpedNumber;
    public static void Visualize(float offset, GameObject parent, GameObject cube, List<float> numbers, Text stats,bool minMax)
    {
        float[] _numbers = numbers.ToArray();
        for (int i = 0; i < sort.clones.Count; i++)
        {
            Destroy(sort.clones[i]);
        }
        sort.clones.Clear();
        Vector3 location = Vector3.zero;
        if(minMax == true)
            lerpedNumber = new float();
            min = _numbers.Min();
            max = _numbers.Max();
        GameObject clone;
        for (int i = 0; i < _numbers.Length; i++)
        {
            lerpedNumber = Mathf.InverseLerp(min, max, _numbers[i]) * offset + 1;
            float yPos = (lerpedNumber - 1) * 0.5f;
            location.y = yPos;
            clone = Instantiate(cube, location, Quaternion.identity);
            clone.transform.localScale = new Vector3(1, lerpedNumber, 1);
            clone.transform.parent = parent.transform;
            location.x += 1f;
            sort.clones.Add(clone);
        }
        camControl.min.y = 0.04f * offset + 26;
        camControl.max.x = sort.clones[sort.clones.Count - 1].transform.position.x;
        if(minMax == true)
        {
            string mean = CalculateMean(_numbers).ToString();
            string med = CalculateMedian(_numbers).ToString();
            string mode = CalculateMode(_numbers) > 0 ? CalculateMode(_numbers).ToString() : "NA";
            stats.text = "mean = " + mean + "\nmedian = " + med + "\nmode = " + mode + "\nn =" + _numbers.Length;
        }
    }

    public static List<float> generateNumbers(int n,float maxRange)
    {
        Debug.Log("ArrayDisplayed generated!");
        float[] numberList = new float[n];
        for (int i = 0; i < n; i++)
        {
            numberList[i] = UnityEngine.Random.Range(0, maxRange);
        }
        return numberList.ToList();
    }
    public static float CalculateMean(float[] input)
    {
        float mean = 0;
        for (int i = 0; i < input.Length; i++)
        {
            mean += input[i];
        }
        mean /= input.Length ;
        return mean;
    }
    public static float CalculateMedian(float[] input)
    {
        if (input.Length == 1)
            return input[0];
        if (input.Length == 2)
            return (input[0] + input[1]) / 2;
        float med = 0;
        med = input.Length / 2;
        if((med % 1) == 0)
        {
            med = (input[(int)med] + input[(int)med + 1]) / 2;
            return med;
        }
        else
        {
            med += 0.5f;
            return input[(int)med];
        }
    }
    public static float CalculateMode(float[] input)
    {
        int n = input.Length;
        float mode = 0;
        float max = input.Max();
        int t = (int)max + 1;
        float[] count = new float[t];
        for (int i = 0; i < t; i++)
            count[i] = 0;

        for (int i = 0; i < n; i++)
            count[(int)input[i]]++;
        float k = count[0];
        for (int i = 1; i < t; i++)
        {
            if (count[i] > k)
            {
                k = count[i];
                mode = i;
            }
        }
        return mode;
    }

}
