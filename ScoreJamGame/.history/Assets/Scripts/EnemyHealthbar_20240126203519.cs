using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Slider slider;
    [SerializaField] private Camera camera;
    [SerializeField] private Transform target;
    [Serialize] private Vector3 offset;
    public void UpdateHealthBar(float currentValue, float maxValue) {
        slider value = currentValue / maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = camera.transform.rotation;
        transform
    }
}
