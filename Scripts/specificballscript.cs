using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class specificballscript : MonoBehaviour {

    public Scene current;
    public string sceneName;

    void Start()
    {
        current = SceneManager.GetActiveScene();
        sceneName = current.name;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("floor"))
        {
            Debug.Log("Floor");
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Goal"))
        {
            if (sceneName == "Level-1-")
            {
                SteamVR_LoadLevel.Begin("Level-1-");
            }
            if (sceneName == "Level-2-")
            {
                SteamVR_LoadLevel.Begin("Level-2-");
            }
            if (sceneName == "Level-3-")
            {
                SteamVR_LoadLevel.Begin("Level-3-");
            }
            if (sceneName == "Level-4-")
            {
                SteamVR_LoadLevel.Begin("Level-4-");
            }
        }
    }
}
