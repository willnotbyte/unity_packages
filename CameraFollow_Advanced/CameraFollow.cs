using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float smoothTime = 0.3f;
	public float smoothLookTime = 0.1f;

	private Vector3 velocity = Vector3.zero;

	public bool looking = false;
	public float maxDistance = 10f;

    void Start()
	{
		target = GameObject.FindWithTag("Player").transform;
	}

    private void Update()
    {
		Vector3 goalPos = target.position;
		goalPos.y = transform.position.y;
		Vector3 mousePos = Input.mousePosition;
		Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

		var difference = worldPos - goalPos;
		var direction = difference.normalized;
		var distance = Mathf.Min(maxDistance, difference.magnitude);
		var endPosition = goalPos + direction * distance;

		if (looking)
        {
			transform.position = Vector3.SmoothDamp(transform.position, endPosition, ref velocity, smoothLookTime);
		}
        else
        {
			transform.position = Vector3.SmoothDamp(transform.position, goalPos, ref velocity, smoothTime);
		}

		if (Input.GetKey(KeyCode.LeftShift))
        {
			looking = true;
        }
        else
        {
			looking = false;
        }
	}
}
