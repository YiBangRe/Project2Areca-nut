using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawMover : MonoBehaviour
{
    Vector2 screenMousePosition = Vector2.zero;
    Vector3 worldMousePositon = Vector3.zero;
    LayerMask lowerJawLayer;
    Vector3 dragDisplacement;
    Collider2D targetCollider;
    [SerializeField] private GameObject allLowerJaw;
    private bool isMouseBtnLeftDown = false;

    // Start is called before the first frame update
    void Start()
    {
       lowerJawLayer = LayerMask.GetMask("LowerJaw");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
                allLowerJaw.transform.position = worldMousePositon + dragDisplacement;
            }
            else
            {
                isMouseBtnLeftDown = false;
            }
        }
        else 
        {
            isMouseBtnLeftDown = false;
        }
        
    }
}
