using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenDelay : MonoBehaviour
{
    [SerializeField] GameObject m_titleScreenGO;

    void Start()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2);
        m_titleScreenGO.SetActive(false);
    }
}
