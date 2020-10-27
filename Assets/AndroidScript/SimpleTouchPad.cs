using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class SimpleTouchPad : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public float smoothing;
    private Vector2 origin;
    private Vector2 direction;
    private Vector2 smoothDirection;
    private bool touched;
    private int pointerID;
    // Use this for initialization
    void Awake()
    {
        direction = Vector2.zero;
        touched = false;
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnPointerDown(PointerEventData data)
    {
        //set our start point
        if(!touched)
        {
            touched = true;
            pointerID = data.pointerId;
            origin = data.position;
        }
    }
    public void OnDrag(PointerEventData data)
    {
        //compare the differnce between our start point and current pos
        if(data.pointerId==pointerID)
        {
            Vector2 currentPosition = data.position;
            Vector2 directionRaw = currentPosition - origin;
            direction = directionRaw.normalized;
        }
    }
    public void OnPointerUp(PointerEventData data)
    {
        if (data.pointerId == pointerID)
        {
            direction = Vector2.zero;
            touched = false;
        }
    }
    public Vector2 GetDirection()
    {
        smoothDirection = Vector2.MoveTowards(smoothDirection, direction, smoothing);
        return smoothDirection;
    }
}
