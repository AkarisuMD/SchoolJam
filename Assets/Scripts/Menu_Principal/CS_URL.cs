using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_URL : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }
        public string Url;

    public void Open()
    {
        Application.OpenURL(Url);
    }
}
