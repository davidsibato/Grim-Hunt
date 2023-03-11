using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    [SerializeField] public Image[] hearts;
    [SerializeField] public Sprite ColoredHeart;
    [SerializeField] public FloatValue HeartContainer;


    void Start()
    {

    }

    public void FillHeart()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = ColoredHeart;
        }
    }
}
