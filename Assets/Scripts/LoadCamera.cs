using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCamera : MonoBehaviour
{
    [SerializeField] Canvas canvas;

    private void OnEnable()
    {
        canvas.worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void OnDisable()
    {
        canvas.worldCamera = null;
    }
}
