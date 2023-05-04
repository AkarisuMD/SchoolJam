using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "MiddleManEtiquette", menuName = "Data/MiddleManEtiquette")]
public class MiddleManEtiquette : ScriptableObject
{

    #region Singleton

    private static MiddleManEtiquette instance;

    public static MiddleManEtiquette Instance
    {
        get
        {
            instance = instance ?? Resources.Load<MiddleManEtiquette>("ManagerSingleto,/MiddleManEtiquette");
            Debug.Log(instance);
            return instance;
        }
    }
    #endregion

    public string tempText;

}
