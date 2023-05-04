using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Heritier", menuName = "Game/Heritier")]
public class Sc_Heritier : ScriptableObject
{
    /// <summary>
    /// GameObject du personnnage.
    /// </summary>
    public GameObject go;

    /// <summary>
    /// sprite du heritier.
    /// </summary>
    public Sprite sprite;

    /// <summary>
    /// statistique du personnage.
    /// </summary>
    public GameStats stats;

    /// <summary>
    /// Quelle bonus donne le personnage (en fonction des stats)
    /// </summary>
    public string bonus;

    /// <summary>
    /// Quelle malus donne le personnage (en fonction des stats)
    /// </summary>
    public string malus;
}
