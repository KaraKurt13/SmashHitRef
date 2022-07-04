using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneToUndergroundBiome : MonoBehaviour
{
    public Material newSkyBox;
    bool skyBoxIsChanged;

    private void Start()
    {
        skyBoxIsChanged = false;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Main Camera" && skyBoxIsChanged == false)
        {
            skyBoxIsChanged = true;
            RenderSettings.skybox = newSkyBox;
            RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Skybox;
        }
    }
}
