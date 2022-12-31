using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class camControl : MonoBehaviour
{
    private protected Camera mainCam;
    public int multiplyer;
    Vector2 camPos;
    public static Vector2 min;
    public static Vector2 max;
    Vector2 dir;
    float scroll;
    sort _sort;
    void Awake()
    {
        mainCam = Camera.main;
        _sort = GameObject.FindGameObjectWithTag("_GM").GetComponent<sort>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            multiplyer = _sort.ArrayDisplayed.Count;
        else
            multiplyer = _sort.ArrayDisplayed.Count * 20;
        mainCam.transform.position = new Vector3(Mathf.Clamp(mainCam.transform.position.x,min.x, max.x), 
                                                 Mathf.Clamp(mainCam.transform.position.y, min.y, max.y),
                                                 -1);
        mainCam.orthographicSize = Mathf.Clamp(mainCam.orthographicSize, 30, _sort.ArrayDisplayed.Count * 120);
        camPos = mainCam.transform.position;
        scroll = Input.mouseScrollDelta.y;
        mainCam.transform.position = new Vector3(camPos.x,camPos.y,mainCam.transform.position.z);
        dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        try
        {
            mainCam.orthographicSize += scroll * multiplyer * -1 * Time.deltaTime;
            camControl.max.y = camControl.min.y + mainCam.orthographicSize;
        }
        catch {
            mainCam.orthographicSize = 30;
        }
        dir *= multiplyer/1000;
        mainCam.transform.position = new Vector3(mainCam.transform.position.x + dir.x, mainCam.transform.position.y + dir.y, -1);
    }
}
