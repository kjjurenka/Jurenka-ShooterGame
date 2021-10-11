/***
 * Created by: Kami Jurenka
 * Date Created: 9/22/2021
 * 
 * Last Edited: 9/22/2021
 * 
 * Description: Ammo Manager manages the pool of ammo
 * **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    // Start is called before the first frame update
    /***VARIABLES***/
    public static AmmoManager AmmoManagerSingleton = null;
    #region AmmoManager Singleton
    void SetAmmoManager()
    {
        if (AmmoManagerSingleton == null)
        {
            AmmoManagerSingleton = this;
        }
        else
        {
            AmmoManagerSingleton = null;
        }
    }
    #endregion

    public GameObject AmmoPrefab = null;
    public int PoolSize = 100;
    public Queue<Transform> AmmoQueue = new Queue<Transform>();
    private GameObject[] AmmoArray;

    private void Awake()
    {
        SetAmmoManager();
        if (AmmoManagerSingleton == null)
        {
            return;
        }

        AmmoArray = new GameObject[PoolSize];
        for (int ii = 0; ii < PoolSize; ++ii)
        {
            AmmoArray[ii] = Instantiate
                (AmmoPrefab, Vector3.zero, Quaternion.identity, transform) as GameObject;
            Transform ObjTransform = AmmoArray[ii].transform;
            AmmoQueue.Enqueue(ObjTransform);
            AmmoArray[ii].SetActive(false);
        }
    }
    public static Transform SpawnAmmo(Vector3 Position, Quaternion Rotation)
    {
        Transform SpawnedAmmo = AmmoManagerSingleton.AmmoQueue.Dequeue();
        SpawnedAmmo.gameObject.SetActive(true);
        SpawnedAmmo.position = Position;
        SpawnedAmmo.localRotation = Rotation;
        AmmoManagerSingleton.AmmoQueue.Enqueue(SpawnedAmmo);
        return SpawnedAmmo;
    }
}
