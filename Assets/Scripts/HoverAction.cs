using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverAction : MonoBehaviour
{
    Text title;
    Color previousColor;
    private void Start()
    {
        title = gameObject.GetComponent<Text>();
    }
    public void OnPointerEnterChangeColor()
    { 
        previousColor = title.color;
        title.color = Color.black;
    }
    public void OnPointerExitChangeColor()
    {
        title.color = previousColor;
    }
}
