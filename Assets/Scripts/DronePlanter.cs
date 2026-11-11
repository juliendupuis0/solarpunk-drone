using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DronePlanter : MonoBehaviour
{
    public InputActionReference inputActionReference;
    public GameObject plantPrefab;
    public float heightPosition; // hauteur de la graine plantée
    public ScoreManager scoreManager;
    
    public AudioSource audioSource;
    public AudioClip plantSound;
    
    void OnPlant(InputAction.CallbackContext context)
    {
        Vector3 positionSeed = new Vector3(transform.position.x, heightPosition, transform.position.z); // toujours même hauteur, position relative au drone (X & Z)
        GameObject newSeed = Instantiate(plantPrefab, positionSeed, Quaternion.identity);
        newSeed.GetComponent<SeedHarvest>().scoreManager = scoreManager;
        audioSource.PlayOneShot(plantSound);
    }
    
    void OnEnable()
    {
        // si performed alors += OnPlant
        inputActionReference.action.Enable();
        inputActionReference.action.performed += OnPlant;
    }
    
    void OnDisable()
    {
        inputActionReference.action.performed -= OnPlant;
        inputActionReference.action.Disable();
    }

}
