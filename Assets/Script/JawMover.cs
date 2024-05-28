using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JawMover : MonoBehaviour
{
    Vector2 screenMousePosition = Vector2.zero;
    Vector3 worldMousePositon = Vector3.zero;
    LayerMask lowerJawLayer;
    Vector3 dragDisplacement;
    Collider2D targetCollider;
    [SerializeField] private GameObject allLowerJaw;
    Rigidbody2D allJawRb;
    private bool isMouseBtnLeftDown = false;
    private bool isGetBasement = false;
    [SerializeField] private float velocity = 20f;

    // Start is called before the first frame update
    void Start()
    {
       lowerJawLayer = LayerMask.GetMask("LowerJaw");
        allJawRb = allLowerJaw.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            screenMousePosition = Input.mousePosition;
            worldMousePositon = Camera.main.ScreenToWorldPoint(screenMousePosition);
            Vector2 worldPos2D = new Vector2(worldMousePositon.x, worldMousePositon.y);
            targetCollider = Physics2D.OverlapPoint(worldPos2D, lowerJawLayer);
            if (targetCollider != null)
            {

                if (!isMouseBtnLeftDown)
                {

                    dragDisplacement = allLowerJaw.transform.position - worldMousePositon;
                }

                isMouseBtnLeftDown = true;
                isGetBasement = true;
            }
            else
            {
                isMouseBtnLeftDown = false;
            }
        }
        else 
        {
            isMouseBtnLeftDown = false;
            isGetBasement = false;
        }
        if (isGetBasement)
        {
            Vector3 directon = (worldMousePositon + dragDisplacement - allLowerJaw.transform.position).normalized * velocity * Time.deltaTime;
            allJawRb.velocity = new Vector2(directon.x, directon.y);
        }
    }
}
