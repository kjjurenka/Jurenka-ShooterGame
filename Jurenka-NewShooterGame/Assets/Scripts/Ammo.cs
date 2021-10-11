/***
 * Created by: Kami Jurenka
 * Date Created: 9/22/2021
 * 
 * Last Edited: 9/22/2021
 * 
 * Description: Ammo Damage
 * **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    //***VARIABLES***//
    public float Damage = 100f;
    public float LifeTime = 2f;

    private void OnEnable()
    {
        CancelInvoke();
        Invoke("Die", LifeTime);

    }//end onEnable()

    void Die()
    {
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        Health HH = other.gameObject.GetComponent<Health>();
        if (other.tag != "Player")
        {
            HH.HealthPoints -= Damage;
            Die();
        }
        //HH.HealthPoints -= Damage;
    }//end OnTriggerEnter
}
