/***
 * Created by: Kami Jurenka
 * Date Created: 9/20/2021
 * 
 * Last Edited: 9/20/2021
 * 
 * Description: Continuously move game object
 * **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    /**Variables**/
    public float MaxSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * MaxSpeed * Time.deltaTime;
    }//End Update()
}
