using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlatformMover : MonoBehaviour
{
    [SerializeField] private float velocity = 20f;
    private Rigidbody2D platformRb;
    [SerializeField] private Vector3 direction = Vector3.zero;  
    // Start is called before the first frame update
    void Start()
    {
        platformRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log($"{transform.localPosition}, {transform.TransformDirection(transform.localPosition)}");

        // platformRb.MovePosition(transform.TransformDirection(transform.localPosition) + direction.normalized * velocity * Time.deltaTime);

        Vector3 newPosLocal = transform.localPosition + direction.normalized * velocity * Time.deltaTime;
        transform.localPosition = newPosLocal;
        //Vector3 newPosWorld = transform.localToWorldMatrix * newPosLocal;
        //platformRb.MovePosition(newPosWorld);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BackTriggerZone")) 
        {
            velocity = -velocity;
        }
        if (collision.CompareTag("BingLang"))
        { 
            collision.transform.parent = transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("BingLang"))
        {
            collision.transform.parent = null;
        }
    }
}
