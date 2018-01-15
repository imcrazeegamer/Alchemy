using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BarScript : MonoBehaviour {
    [SerializeField]
    private float fillAmount = 1;
    [SerializeField]
    private float lerpSpeed;
    [SerializeField]
    private Image content;
    [SerializeField]
    private Color fullColor,lowColor;

    public float MaxValue { get; set; }
    public float Value { set { fillAmount = QuickMathz(value, 0, MaxValue, 0, 1); }}
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        HandleBar();

    }
    private void HandleBar()
    {
        if (fillAmount != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
            content.color = Color.Lerp(lowColor, fullColor, fillAmount);
        }
        

    }
    private float QuickMathz(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
