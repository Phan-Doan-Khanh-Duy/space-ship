using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float worldHeight = Camera.main.orthographicSize * 2f; // Same size of Camera Main
        // Debug.Log ( worldHeight); =>10
        float worldWidth = worldHeight * Screen.width / Screen.height; // 10 * Screen.width / Screen.height     

        transform.localScale = new Vector3(worldWidth, worldHeight, 0f);
    }
}
