using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Security.Cryptography;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    Material Mat;
    [SerializeField] private float fadeSpeed = 1;
    [SerializeField] private float explosionExpandRate = 5;
    [SerializeField] private float startingSize = 1;
    [SerializeField] private float endingSize = 5;
    private float newScale = 1;
    public bool hasInteractedWithPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        Mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Expand();
        Fade();
    }

    // Controls explosion expansion rate and maximum size.
    private void Expand()
    {
        this.gameObject.transform.localScale = new Vector3(newScale, newScale, newScale);
        newScale += (Time.deltaTime * explosionExpandRate);
    }

    // Controls how fast explosion fades and destroys explosion when finished.
    private void Fade()
    {
        if(Mat.color.a > 0)
        {
            Color currentColor = Mat.color;
            float fadeAmount = currentColor.a - (Time.deltaTime * fadeSpeed);
            
            currentColor = new Color(currentColor.r, currentColor.g, currentColor.b, fadeAmount);
            Mat.color = currentColor;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
