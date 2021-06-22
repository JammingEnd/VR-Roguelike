using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public bool showController = true;
    private InputDevice targetDevice;

    public GameObject handModelPrefab;

    private GameObject spawnedHandModel;
    private Animator handAnimation;

    void Start()
    {
        TryInit();
    }


    void UpdateHandAnimation()
    {
        if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggervalue))
        {
            handAnimation.SetFloat("Tigger", triggervalue);
        }
        else
        {
            handAnimation.SetFloat("Tigger", 0);

        }
        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimation.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimation.SetFloat("Grip", 0);

        }
    }

    void TryInit()
    {
       
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacter = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacter, devices);

        foreach (var item in devices)
        {

        }

        if (devices.Count > 0)
        {
            targetDevice = devices[0];

            spawnedHandModel = Instantiate(handModelPrefab, transform);


        }
        handAnimation = spawnedHandModel.GetComponent<Animator>();

    }
    // Update is called once per frame
    void Update()
    {
        if (!targetDevice.isValid)
        {
            TryInit();
        }
        else
        {
            if (!showController)
            {
                spawnedHandModel.SetActive(false);

            }
            else
            {
                spawnedHandModel.SetActive(true);
                UpdateHandAnimation();
            }
        }

       
    }
}
