using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    CinemachineVirtualCamera vCamera;
    CinemachineBasicMultiChannelPerlin noise;
    // Start is called before the first frame update
    void Start()
    {
        vCamera = GetComponent<CinemachineVirtualCamera>();
        noise = vCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void Shake(float duracion = 0.1f, float amplitud = 1.5f, float frecuencia = 20){
        StopAllCoroutines();
        StartCoroutine(AplyNoiseRutine(duracion,amplitud,frecuencia));
    }

    IEnumerator AplyNoiseRutine(float duracion = 0.1f, float amplitud = 1.5f, float frecuencia = 20){
        noise.m_AmplitudeGain = amplitud;
        noise.m_FrequencyGain = frecuencia;
        yield return new WaitForSeconds(duracion);
        noise.m_AmplitudeGain = 0;
        noise.m_FrequencyGain = 0;
    }
}
