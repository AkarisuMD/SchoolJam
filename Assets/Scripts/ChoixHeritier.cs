using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChoixHeritier : MonoBehaviour
{

    [SerializeField] private List<Sc_Heritier> alreadyUsed = new();

    [SerializeField] private GameObject parent;

    private void Start()
    {
        alreadyUsed.Clear();

        GameObject resources_Heritier_Panel = Resources.Load<GameObject>("Menu/Heritier");
        Sc_Heritier[] sc_heritiers = Resources.LoadAll<Sc_Heritier>("Heritier");

        Debug.Log(sc_heritiers.Length);

        for (int i = 0; alreadyUsed.Count < 3; i++)
        {
            Sc_Heritier sc_Heritier = sc_heritiers[Random.Range(0, sc_heritiers.Length)];

            if (!alreadyUsed.Contains(sc_Heritier))
            {
                GameObject heritier = Instantiate(resources_Heritier_Panel, parent.transform);
                heritier.GetComponent<Obj_Heritier>().SetHeritier(sc_Heritier);
                alreadyUsed.Add(sc_Heritier);
            }
        }
    }
}
