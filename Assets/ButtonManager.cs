using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    int i = 0;


    public void changeScale()
    {
        Debug.Log(i);
        int[] scales = new int[9] { 1, 2, 4, 8, 10, 50, 100, 500, 1000 };
        Text t = transform.Find("Text").GetComponent<Text>();


        if(i < 8)
        {
            i++;
        }
        else
        {
            i = 0;
        }
        Time.timeScale = scales[i];

        t.text = scales[i].ToString() + "X";
    }
}
