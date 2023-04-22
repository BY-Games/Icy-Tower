using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{

    [SerializeField] GameObject leftWall;
    [SerializeField] GameObject rightWall;
    [SerializeField] Vector3 leftWallPos;
    [SerializeField] Vector3 rightWallPos;
    [SerializeField] Transform player;
    [SerializeField] float wallBuildDistance = 20f;

    

    // Start is called before the first frame update
    void Start()
    {
        //leftWallPos = leftWall.transform.position;
        //rightWallPos = rightWall.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       
            BuildWalls();
        
    }

    void BuildWalls()
    {
        leftWallPos.y += 1;
        rightWallPos.y += 1;
        Instantiate(leftWall, leftWallPos, Quaternion.identity);
        Instantiate(rightWall, rightWallPos, Quaternion.identity);
    }
}

