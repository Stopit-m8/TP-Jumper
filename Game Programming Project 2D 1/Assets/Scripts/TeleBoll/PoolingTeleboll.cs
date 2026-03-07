using System.Collections.Generic;
using UnityEngine;

public class PoolingTeleboll : MonoBehaviour
{
    public static PoolingTeleboll instance;
    private List<GameObject> telebollPooling = new List<GameObject>();
    private int amountToPool = 1;

    [SerializeField] private GameObject telebollPrefab;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(telebollPrefab);
            obj.SetActive(false);
            telebollPooling.Add(obj);
        }
    }

    public GameObject getPooledObject()
    {
        for (int i = 0; i < telebollPooling.Count; i++)
        {
            if (!telebollPooling[i].activeInHierarchy)
            {
                return telebollPooling[i];
            }
        }
        return null;
    }

}
