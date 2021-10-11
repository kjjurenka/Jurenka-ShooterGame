/***
 * Created by: Kami Jurenka
 * Date Created: 9/15/2021
 * 
 * Last Edited: 9/15/2021
 * 
 * Description: Boundery of the game
 * **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsLock : MonoBehaviour
{
    public Rect LevelBounds; //x,y,w,h of the bounding rectangle

    private void LateUpdate()
    {
        transform.position = new Vector3
            (Mathf.Clamp(transform.position.x, LevelBounds.xMin, LevelBounds.xMax),
            transform.position.y,
            Mathf.Clamp(transform.position.z, LevelBounds.yMin, LevelBounds.yMax));
    }//End LastUpdate()

    private void OnDrawGizmosSelected()
    {
        const int cubeDepth = 1;
        Vector3 boundsCenter = new Vector3(LevelBounds.xMin + LevelBounds.width * 0.5f,
            0, LevelBounds.yMin + LevelBounds.height * 0.5f);
        Vector3 boundsHeight = new Vector3(LevelBounds.width, cubeDepth, LevelBounds.height);

        Gizmos.DrawWireCube(boundsCenter, boundsHeight);


    }//End OnDrawGizmoSelected()

}