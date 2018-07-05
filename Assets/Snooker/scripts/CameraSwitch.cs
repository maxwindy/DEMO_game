using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject cameraOne;
    public GameObject cameraTwo;
    public GameObject cameraThree;

    AudioListener cameraOneAudioLis;
    AudioListener cameraTwoAudioLis;
    AudioListener cameraThreeAudioLis;

    void Start()
    {
        cameraOneAudioLis = cameraOne.GetComponent<AudioListener>();
        cameraTwoAudioLis = cameraTwo.GetComponent<AudioListener>();
        cameraThreeAudioLis = cameraTwo.GetComponent<AudioListener>();

        cameraPositionChange(PlayerPrefs.GetInt("CameraPosition"));
    }
    
    void Update()
    {
        switchCamera();
    }
    
    public void cameraPositonM()
    {
        cameraChangeCounter();
    }
    
    void switchCamera()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cameraChangeCounter();
        }
    }
    
    void cameraChangeCounter()
    {
        int cameraPositionCounter = PlayerPrefs.GetInt("CameraPosition");
        cameraPositionCounter++;
        cameraPositionChange(cameraPositionCounter);
    }
    
    void cameraPositionChange(int camPosition)
    {
        if (camPosition > 2)
        {
            camPosition = 0;
        }
        
        PlayerPrefs.SetInt("CameraPosition", camPosition);
        
        if (camPosition == 0)
        {
            cameraOne.SetActive(true);
            cameraOneAudioLis.enabled = true;

            cameraTwoAudioLis.enabled = false;
            cameraTwo.SetActive(false);

            cameraThreeAudioLis.enabled = false;
            cameraThree.SetActive(false);
        }
        
        if (camPosition == 1)
        {
            cameraOneAudioLis.enabled = false;
            cameraOne.SetActive(false);

            cameraTwoAudioLis.enabled = true;
            cameraTwo.SetActive(true);

            cameraThreeAudioLis.enabled = false;
            cameraThree.SetActive(false);
        }

        if (camPosition == 2)
        {
            cameraOneAudioLis.enabled = false;
            cameraOne.SetActive(false);

            cameraTwoAudioLis.enabled = false;
            cameraTwo.SetActive(false);

            cameraThreeAudioLis.enabled = true;
            cameraThree.SetActive(true);
        }
    }
}
