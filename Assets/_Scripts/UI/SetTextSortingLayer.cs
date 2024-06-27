using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetTextSortingLayer : MonoBehaviour
{
    [SerializeField] private string sortingLayerName = "Front";
    [SerializeField] private int sortingOrder = 0;

    private void Awake()
    {
        TextMeshPro tmp = GetComponent<TextMeshPro>();

        if (tmp != null)
        {
            MeshRenderer meshRenderer = tmp.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.sortingLayerName = sortingLayerName;
                meshRenderer.sortingOrder = sortingOrder;
            }
        }
    }
}
