using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship : MonoBehaviour
{
    float moveUnitsPerSecond = 5;
    Rigidbody2D rigidbody2DforShip;
	float shipColliderRadius;
    Vector2 currentAngle = new Vector2(1, 0);
    const float ForceOfThrust = 5;
    const float rotation = 45;
    Vector2 Direction;
    // Update is called once per frame
    void OnCrossingBorder()
    {
        float cd = GetComponent<CircleCollider2D>().radius;

        Vector2 position = transform.position;
        if (position.x + cd > ScreenUtils.ScreenRight)
        {
            position.x = ScreenUtils.ScreenLeft + cd;
            transform.position = position;
        }
        if (position.x - cd < ScreenUtils.ScreenLeft)
        {
            position.x = ScreenUtils.ScreenRight - cd;
            transform.position = position;
        }
        if (position.y + cd > ScreenUtils.ScreenTop)
        {
            position.y = ScreenUtils.ScreenBottom + cd;
            transform.position = position;
        }
        if (position.y - cd < ScreenUtils.ScreenBottom)
        {
            position.y = ScreenUtils.ScreenTop - cd;
            transform.position = position;
        }
    }
void Start () 
	{
		rigidbody2DforShip = GetComponent<Rigidbody2D> ();
		shipColliderRadius = GetComponent<CircleCollider2D> ().radius;
	}
    	void Update()
	{
		float rotationInput = Input.GetAxis ("Horizontal");

		if (rotationInput != 0) 
		{
			float rotationAmount = rotation * Time.deltaTime * rotationInput;
			transform.Rotate (Vector3.forward, -rotationAmount);
			float deegreeRotaion = transform.eulerAngles.z; 
            print(deegreeRotaion);
			float rads = Mathf.Deg2Rad * deegreeRotaion; 
			Direction.x = Mathf.Cos (rads); 
			Direction.y = Mathf.Sin (rads);
		}
        OnCrossingBorder();
	}
    void FixedUpdate () 
	{
		if (Input.GetAxis ("Jump") != 0) 
		{
			rigidbody2DforShip.AddForce(ForceOfThrust*thrustDirection, ForceMode2D.Force);
		}
	}
}
