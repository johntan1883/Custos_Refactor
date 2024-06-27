using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject keyGameObjectPrefab;
    [SerializeField] private GameObject nothingUIGameObject;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private bool spawnKey;

    private bool hasInteracted = false;

    private BlindBoyInteractableUI blindBoyInteractableUI;

    private void Awake()
    {
        blindBoyInteractableUI = GetComponent<BlindBoyInteractableUI>();
    }

    public void BlindBoyInteract(BlindBoy blindBoy)
    {
        Debug.Log("Boy Interact");
        
        if (!hasInteracted)
        {
            
            hasInteracted = true;
            blindBoyInteractableUI.HideInteractableIcon();

            if (spawnKey)
            {
                SpawnKey();
            }
            else
            {
                StartCoroutine(ShowNothingUI());
            }

            DisableInteractable();
        }
    }

    public void Interact(Player player)
    {
        
    }

    private void SpawnKey()
    {
        Instantiate(keyGameObjectPrefab, spawnPoint.position, Quaternion.identity);
    }

    private IEnumerator ShowNothingUI()
    {
        nothingUIGameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        nothingUIGameObject.SetActive(false);
    }

    private void DisableInteractable()
    {
        GetComponent<CabinetInteractable>().enabled = false;
    }
}
