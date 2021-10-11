/***
 * Created by: Kami Jurenka
 * Date Created: 9/20/2021
 * 
 * Last Edited: 9/20/2021
 * 
 * Description: GameObject Health
 * **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    /**Variables**/

    public bool DestroyOnDeath = true;
    public GameObject DeathParticlesPrefab = null;
    [SerializeField] private float _HealthPoints = 100f;

    public float HealthPoints
    {
        get { return _HealthPoints; }//End Get
        set
        {
            _HealthPoints = value;
            if (HealthPoints <= 0)
            {
                SendMessage("Die", SendMessageOptions.DontRequireReceiver);
                if (DeathParticlesPrefab != null)
                {
                    Instantiate(DeathParticlesPrefab, transform.position, transform.rotation);
                }
                if (DestroyOnDeath == true)
                {
                    Destroy(gameObject);
                }
            }
        }//End Set
    }// End HealthPoints

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug Health test
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            HealthPoints = 0;
        }*///end Debug
    }
}