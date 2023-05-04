using Akarisu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CafeData", menuName = "Data/CafeData")]
public class CafeObject : ScriptableObject
{
    #region Singleton

    private static CafeObject instance;

    public static CafeObject Instance
    {
        get
        {
            instance = instance ?? Resources.Load<CafeObject>("ManagerSingleto,/CafeData");
            Debug.Log(instance);
            return instance;
        }
    }
    #endregion

    public int Level;
    public string cafename;
    public Sprite spriteResource;
    public Sprite sprite;
    public float cafeStorage;
    public float cafeMaxCapacity;

}
 