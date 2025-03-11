using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    public float curValue;
    public float maxValue;
    public float startValue;
    public float passiveValue;
    public bool isFull;
    public Image uiBar;

    private void Start()
    {
        curValue = startValue;
    }

    private void Update()
    {
        uiBar.fillAmount = GetPercentage();
        SetIsFull();
    }

    public void Add(float amount)//값 증가
    {
        curValue = Mathf.Min(curValue + amount, maxValue);
    }

    public void Substract(float amount)//값 감소
    {
        curValue = Mathf.Max(curValue - amount, 0.0f);
    }

    public float GetPercentage()
    {
        return curValue / maxValue;
    }

    public void SetIsFull()//값이 최대치인지 여부
    {
        isFull = (curValue == maxValue);
    }
}
