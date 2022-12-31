using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class numberDisplay : MonoBehaviour
{
    public int numberSort;
    public float[] numberList;
    public float offset;
    public GameObject cube;
    public Transform parent;
    public float maxRange;
    public Vector2 first, last;
    Camera mainCam;
    // Start is called before the first frame update
    void Awake()
    {
        generateNumbers();
        DisplayNumber();
    }
    void generateNumbers()
    {
        mainCam = Camera.main;
        numberList = new float[numberSort];
        for (int i = 0; i < numberSort; i++)
        {
            numberList[i] = Random.Range(0, maxRange);
        }
    }
    Vector3 location;
    List<GameObject> clones = new List<GameObject>();
    public void DisplayNumber()
    {
        location = Vector3.zero;
        float[] lerpedNumbers = converToPercent();

        GameObject clone;
        for (int i = 0; i < lerpedNumbers.Length; i++)
        {
            float yPos = (lerpedNumbers[i] - 1) * 0.5f;
            location.y = yPos;
            clone = Instantiate(cube, location, Quaternion.identity);
            clone.transform.localScale = new Vector3(1, lerpedNumbers[i], 1);
            clone.transform.parent = parent;
            location.x += 1.5f;
            clones.Add(clone);
        }
        first = clones[0].transform.position;
        last = clones[clones.Count - 1].transform.position;
    }

    float[] converToPercent()
    {
        for (int i = 0; i < clones.Count; i++)
        {
            Destroy(clones[i]);
        }
        clones.Clear();
        float max = float.MinValue;
        float min = float.MaxValue;
        float[] lerpedNumbers = new float[numberList.Length];
        for (int i = 0; i < numberList.Length; i++)
        {
            if (numberList[i] > max)
            {
                max = numberList[i];
            }
            
            if (numberList[i] < min)
            {
                min = numberList[i];
            }
        }
        for (int i = 0; i < numberList.Length; i++)
        {

            lerpedNumbers[i] = Mathf.InverseLerp(min, max, numberList[i])* offset + 1;

        }
        return lerpedNumbers;
    }
    public void swapArray(int a,int b)
    {
        float temp = 0;
        temp = numberList[a];
        numberList[a] = numberList[b];
        numberList[b] = temp;
        DisplayNumber();
    }
    public void ColorGreen()
    {
        for (int i = 0; i < clones.Count; i++)
        {
            clones[i].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
        }
    }
}
