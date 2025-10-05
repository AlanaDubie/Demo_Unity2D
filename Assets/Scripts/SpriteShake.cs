using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteShake : MonoBehaviour
{
    // Step 1: make shakeAmount = 0.1f 
    public float shakeAmount = 0.1f;   // how far it moves
    // Step 2: make shakeSpeed = 25.0f
    public float shakeSpeed = 25.0f;     // how fast it shakes

    private Vector3 originalPos;
    void Start()
    {
        originalPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        // Create random offset each frame
        float offsetX = Mathf.PerlinNoise(Time.time * shakeSpeed, 0f) * 2 - 1;
        float offsetY = Mathf.PerlinNoise(0f, Time.time * shakeSpeed) * 2 - 1;

        Vector3 shakeOffset = new Vector3(offsetX, offsetY, 0f) * shakeAmount;

        transform.localPosition = originalPos + shakeOffset;
    }

    private void OnDisable()
    {
        // Reset position when disabled
        transform.localPosition = originalPos;
    }
}
