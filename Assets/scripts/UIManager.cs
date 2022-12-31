using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button sort, number;
    public GameObject GM_number, GM_sort;
    public InputField N, max;
    public Text debugText;
    public GameObject iterationText,offsetText;
    private Text _iterationText,_offsetText;
    public Slider sliderIteration,sliderOffset;
    public GameObject sortObj; sort _sort;
    public Text fpsText;
    float deltaTime;
    public Text warningText;
    public GameObject stats;
    public DisplayInfo[] displayInfosForSort;
    public GameObject sortingAlgosPlaceholder;
    public Text sortingAlgosPlaceholderText;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (stats.activeSelf == true){
                stats.SetActive(false);
            }
            else
            {
                stats.SetActive(true);
            }
        }
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = Mathf.Ceil(fps).ToString();
        if (fps < 30 && _sort.fastVisual == true)
        {
            warningText.text = "Performance drop due to rendering of large array and short iteration time.";
            Debug.LogWarning("low fps warning");
        }
        else
        {
            warningText.text = string.Empty;
        }
        if (_sort.ArrayDisplayed.Count > 100)
        {
            sliderOffset.maxValue = _sort.ArrayDisplayed.Count / 2;
        }

    }
    private void Start()
    {
        _sort = sortObj.GetComponent<sort>();
        _iterationText = iterationText.GetComponent<Text>();
        _offsetText = offsetText.GetComponent<Text>();
        iterationText.SetActive(false);
        GM_number.SetActive(false);
        GM_sort.SetActive(false);
        ActivateSort();
        sliderOffset.value = _sort.offset;
    }
    public void ActivateSort()
    {
        GM_number.SetActive(false);
        GM_sort.SetActive(true);
        number.interactable = true;
        sort.interactable = false;
    }
    public void ActivateNumbers()
    {
        GM_number.SetActive(true);
        GM_sort.SetActive(false);
        number.interactable = false;
        sort.interactable = true;
    }
    public void GenerateNumber(GameObject master)
    {
        List<float> history = master.GetComponent<sort>().ArrayDisplayed;
        try
        {
            Debug.Log(N.text + max.text);
            if(int.Parse(N.text) < 10000 || int.Parse(max.text) < 10009)
            {
                master.GetComponent<sort>().ArrayDisplayed = Background.generateNumbers(int.Parse(N.text), int.Parse(max.text));
            }
            else
            {
                throw new System.OverflowException("overflow");
            }
            
        }
        catch (InvalidOperationException)
        {
            master.GetComponent<sort>().ArrayDisplayed = history;
            debugText.text = "Please input a non-zero interger under 'Number in list'.";
        }
        catch (OverflowException)
        {
            master.GetComponent<sort>().ArrayDisplayed = history;
            debugText.text = "Number unsuitable for an 32 bit data type. accepting (0>x>10000)";
        }catch (FormatException)
        {
            master.GetComponent<sort>().ArrayDisplayed = history;
            debugText.text = "Please give an input";
        }
        catch (Exception e)
        {
            master.GetComponent<sort>().ArrayDisplayed = history;
            debugText.text = "Undiscovered error found";
        }
    }
    public void OnSliderEnter_iteration()
    {
        Debug.Log("activateText");
        iterationText.SetActive(true);
        _iterationText.text = sliderIteration.value.ToString("0.##");
        _sort.waitTime = sliderIteration.value;
}
    public void OnSliderExit_iteration()
    {
        Debug.Log("deActivateText");
        iterationText.SetActive(false);
    }
    public void OnSliderEnter_Offset()
    {
        offsetText.SetActive(true);
        _offsetText.text = sliderOffset.value.ToString("0.##");
        _sort.offset = sliderOffset.value;
    }
    public void OnSliderExit_Offset()
    {
        _sort.ArrayDisplayed = _sort.ArrayDisplayed;
        offsetText.SetActive(false);
    }
    public void DisplayInfoEnter(int infoType)
    {
        sortingAlgosPlaceholder.SetActive(true);
        sortingAlgosPlaceholderText.text = "<b>brief description:</b> " + displayInfosForSort[infoType].brief+ 
                                                            "\n<b>average complexity:</b> " + displayInfosForSort[infoType].averageComplexity+
                                                            "\n<b>best case:</b> " + displayInfosForSort[infoType].BestCase+
                                                            "\n<b>worst case:</b> " + displayInfosForSort[infoType].WorstCase;
    }
    public void DisplayInfoExit()
    {
        sortingAlgosPlaceholder.SetActive(false);
        Debug.Log("exit");
    }
}
[System.Serializable]
public class DisplayInfo
{
    [TextArea]
    public string brief;
        
    public string averageComplexity, BestCase, WorstCase;
    public string whatItIs;
}