using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BriqueDeGameplay : MonoBehaviour
{
    public GameObject pickleBrick;

    private void OnMouseUp()
    {
        pickleBrick.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-7f, -5f, 12f), ForceMode.Impulse);
        Destroy(this.gameObject);
    }
}
