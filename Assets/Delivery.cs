using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    SpriteRenderer spriteRenderer;

    [SerializeField]
    float destroyDelay;

    [SerializeField]
    Color32 hasPackageColor = new Color32(1, 1, 1, 1);

    [SerializeField]
    Color32 noPackageColor = new Color32(1, 1, 1, 1);

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
            Debug.Log("Package picked up");
        }

        if (other.tag == "Customer" && hasPackage)
        {
            spriteRenderer.color = noPackageColor;
            hasPackage = false;
            Debug.Log("Package delivered");
        }
    }
}
