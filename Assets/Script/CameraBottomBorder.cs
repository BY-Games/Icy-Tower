using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraBottomBorder : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Screen.width " + Screen.width);
        Debug.Log("Screen.height " + Screen.height);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
      //  Debug.Log("debugggggggggggggggg");
        //Destroy(collision.gameObject);
    }


    //Destroy the player object when it touches the bottom border of the camera in the camera 
    //quite the game
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("tag:" + collision.name);
        if (collision.tag == "Player")
        {
            Destroy(collision.gameObject);
           // if (Application.isEditor)
           // {
               // UnityEditor.EditorApplication.isPlaying = false;
          //  }
           // else
           // {
                Application.Quit();
           // }
        }
        else
        {
            Destroy(collision.gameObject);
            RandomPlatform.numOfPlatforms--;
        }
    }
}
