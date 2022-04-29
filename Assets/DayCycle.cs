using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    [Range(0, 1)]
    public float timeOfDay;
    public float dayDuration = 30f;
    public AnimationCurve sunCurve;
    float sunIntensity;

    public Transform sun;
    Light sunLight;

    void Start()
    {
        sunLight = sun.GetComponent<Light>();
        sunIntensity = sunLight.intensity;
    }

    void Update()
    {
        timeOfDay += Time.deltaTime / dayDuration;
        if (timeOfDay >= 1) timeOfDay = 0;

        sun.localRotation = Quaternion.Euler(timeOfDay * 360f, sun.position.y, sun.position.z);
        sunLight.intensity = sunIntensity * sunCurve.Evaluate(timeOfDay);
    }
}
