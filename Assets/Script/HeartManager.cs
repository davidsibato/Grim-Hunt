using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    [SerializeField] public Image[] hearts;
    [SerializeField] public Sprite FullHeart;
    [SerializeField] public Sprite emptyHeart;
    [SerializeField] public Sprite halffullHeart;
    [SerializeField] public FloatValue HeartContainer;
    [SerializeField] public FloatValue playerCurrenthealth;


    void Start()
    {
        FillHeart();
    }

    public void FillHeart()
    {
        for (int i = 0; i < HeartContainer.initialValue; i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = FullHeart;
        }
    }
    public void Updatehearts()
    {
        float tempHealth = playerCurrenthealth.RuntimeValue /2;
        for (int i = 0;i < HeartContainer.initialValue; i++)
        {
            if (i <= tempHealth - 1)
            {
                hearts[i].sprite = FullHeart;
            } else if (i > tempHealth)
            {
                hearts[i].sprite= emptyHeart;
            } else 
            {
                hearts[i].sprite = halffullHeart;
            }
        }
    }
}
