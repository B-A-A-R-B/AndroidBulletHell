using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float minGroundNormalY = .65f;

	protected Vector2 moves;
	protected Rigidbody2D rigBod;
	//public GameObject playerLaser;
	protected ContactFilter2D cntcFltr;
	protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
	protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D> (16);

	protected const float minMoveDistance = 0.001f;
	protected const float shellRadius = 0.01f;
	// Use this for initialization

	void OnEnable() {

		rigBod = GetComponent<Rigidbody2D> ();

	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if ((Input.GetMouseButtonDown (0))) {

			GameObject laserProj = (GameObject)Instantiate (Resources.Load ("PlayerLaser"));
			laserProj.transform.position = rigBod.position;
			CreateGlobals.batterChargeLevel -= 3;

		}

	}

	void FixedUpdate() {

		moves = Vector2.zero;



		if( Input.GetKey("up") || Input.GetKey("w") )
			moves.y += 2;
				
		if( (Input.GetKey("down")) || (Input.GetKey("s")) )
			moves.y -= 2;

				
		if( (Input.GetKey("left")) || (Input.GetKey("a")) )
			moves.x -= 2;
					
		if( (Input.GetKey("right")) || (Input.GetKey("d")) )
			moves.x += 2;
	
		if (Mathf.Abs (moves.y + rigBod.position.y)	> 39)
			moves.y -= (rigBod.position.y/ Mathf.Abs(rigBod.position.y)) * 2;
		moves = moves / 2;
		if (moves.x + rigBod.position.x	> 79)
			moves.x = 0;
		if (moves.x + rigBod.position.x < -79)
			moves.x = 0;

		Movement (moves);

	}

	void Movement(Vector2 moveing) {

		rigBod.position = rigBod.position + moveing;

	}
}
