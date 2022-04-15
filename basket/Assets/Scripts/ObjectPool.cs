using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectPool : MonoBehaviour
{
    [Serializable]
    public struct Pool
    {
        public Queue<GameObject> poolObjects;
        public GameObject objectPrefab;
        public int poolSize;
    }

    [SerializeField] private Pool[] pools = null;

    public static int ballType;//and types amount
    
    private void Awake()
    {
        //ballCounter = 1;
        for (int j = 0; j < pools.Length; j++)
        {
            pools[j].poolObjects = new Queue<GameObject>();
            for (int i = 0; i < pools[j].poolSize; i++)
            {
                //create object
                GameObject obj = Instantiate(pools[j].objectPrefab); 
                //set false
                obj.SetActive(false);
                //add to list
                pools[j].poolObjects.Enqueue(obj);
            }
        }
    }
    private void Start()
    {
        ballType = pools.Length;
    }

    //remove the ball from the queue and add it to
    //the end of the queue after use
    public GameObject GetPoolObject(int objectType)
    {
        if(objectType >= pools.Length)
        {
            return null;
        }
        GameObject obj = pools[objectType].poolObjects.Dequeue();
        obj.SetActive(true);
        pools[objectType].poolObjects.Enqueue(obj);
        return obj;
    }
    
}