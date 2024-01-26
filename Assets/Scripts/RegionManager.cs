using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionManager : MonoBehaviour
{
    public GameObject regionUI; // Prefab for the UI to be displayed in the region

    private GameObject uiInstance;
    private bool playerInsideRegion = false;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collision with: " + other.gameObject.name);
            playerInsideRegion = true;

            // Disable player movement and map
            PlayerController playerController = other.GetComponent<PlayerController>();
            //playerController.DisableMovement();
            //MapController.Instance.DisableMap();

            // Instantiate and show region UI
            uiInstance = Instantiate(regionUI, new Vector3(0,0,0), Quaternion.identity);
            //uiInstance.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Exit Collision with: " + other.gameObject.name);

            // Call the ExitRegion method when the player exits the region
            ExitRegion();

            playerInsideRegion = false;
        }
    }

    // Call this method when the player completes the activity and leaves the region
    public void ExitRegion()
    {
            PlayerController playerController = FindObjectOfType<PlayerController>();
            //playerController.EnableMovement();
            Debug.Log("ExitRegion gets called");
            Destroy(uiInstance);
            // MapController.Instance.EnableMap();
    }
}