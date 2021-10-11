/***
 * Created by: Kami Jurenka
 * Date Created: 9/13/2021
 * 
 * Last Edited: 9/15/2021
 * 
 * Description: Player control movements
 * **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SelectionBase]
public class PlayerController : MonoBehaviour
{
    /***VARIABLES***/
    public bool MouseLook = true; //are we looking at the mouse
    public string HorzAxis = "Horizontal";
    public string VertAxis = "Vertical";
    public string FireAxis = "Fire1";
    public float MaxSpeed = 5f; //speed
    public float ReloadDelay = 0.3f;
    public bool CanFire = true;
    public Transform[] TurretTransforms;

    private Rigidbody ThisBody = null; //variable for the ship's rigidbody

    //Awake is called before start
    private void Awake()
    {
        ThisBody = GetComponent<Rigidbody>(); //sets the object's rigidBody to variable
    }//end Awake()

    private void FixedUpdate()
    {
        float Horz = Input.GetAxis(HorzAxis);
        float Vert = Input.GetAxis(VertAxis);

        Vector3 MoveDirection = new Vector3(Horz, 0.0f, Vert);
        ThisBody.AddForce(MoveDirection.normalized * MaxSpeed);

        ThisBody.velocity = new Vector3(
            Mathf.Clamp(ThisBody.velocity.x, -MaxSpeed, MaxSpeed),
            Mathf.Clamp(ThisBody.velocity.y, -MaxSpeed, MaxSpeed),
            Mathf.Clamp(ThisBody.velocity.z, -MaxSpeed, MaxSpeed));

        //Look at mouse
        if (MouseLook)
        {
            Vector3 MousePosWorld = Camera.main.ScreenToWorldPoint
                (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));
            MousePosWorld = new Vector3(MousePosWorld.x, 0.0f, MousePosWorld.z);
            Vector3 LookDirection = MousePosWorld - transform.position;
            transform.localRotation = Quaternion.LookRotation(LookDirection.normalized, Vector3.up);

        }

    }//end FixedUpdate()

    private void Update()
    {
        if (Input.GetButtonDown(FireAxis) && CanFire)
        {
            foreach (Transform T in TurretTransforms)
            {
                AmmoManager.SpawnAmmo(T.position, T.rotation);
            }
            CanFire = false;
            Invoke("EnableFire", ReloadDelay);
        }
    }

    void EnableFire()
    {
        CanFire = true;
    }
    void OnDestroy()
    {
        GameManager.IsPlayerDead = true;
    }

}