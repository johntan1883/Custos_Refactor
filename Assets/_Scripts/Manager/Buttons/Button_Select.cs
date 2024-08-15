using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject objectToEnable;

    void Start()
    {
        objectToEnable.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        objectToEnable.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        objectToEnable.SetActive(false);
    }
}
