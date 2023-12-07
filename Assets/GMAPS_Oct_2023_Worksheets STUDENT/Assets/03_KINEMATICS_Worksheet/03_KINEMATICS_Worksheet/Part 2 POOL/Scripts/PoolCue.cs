 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;

 public class PoolCue : MonoBehaviour
 {
 	public LineFactory lineFactory; //Reference to LineFacetory
 	public GameObject ballObject; //Reference to GameObject

 	private Line drawnLine; //Shows Line Drawn
 	private Ball2D ball; //Reference to Ball2D

 	private void Start()
 	{
        //Get Ball2D component
 		ball = ballObject.GetComponent<Ball2D>();
 	}

 	void Update()
 	{
        //Check if left mouse button is clicked
 		if (Input.GetMouseButtonDown(0))
 		{
            //Convert mouse position from screen to world coordinates
 			var startLinePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Start line drawing
 			if (ball != null && ball.IsCollidingWith(startLinePos.x, startLinePos.y)) //Check if ball exists & mouse is clicked on the ball's position
 			{
                drawnLine = lineFactory.GetLine(ballObject.transform.position, startLinePos, 5, Color.red); //Draw a line from ball's position to mouse's position
 				drawnLine.EnableDrawing(true); //Enable line drawing
 			}
 		}
        //Else check if the mouse is released & a line is drawn
 		else if (Input.GetMouseButtonUp(0) && drawnLine != null)
 		{
            drawnLine.EnableDrawing(false); //Disable line drawing

 			//Calculate the vector between the ball's position and mouse's position
 			HVector2D v = new HVector2D(ball.Position.x - drawnLine.end.x, ball.Position.y - drawnLine.end.y);
 			ball.Velocity = v; //Set balls's velocity based on calculated vector

 			drawnLine = null; // End line drawing            
 		}

 		if (drawnLine != null)
 		{
 			drawnLine.end = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Update line end
 		}
 	}

 	/// <summary>
 	/// Get a list of active lines and deactivates them.
 	/// </summary>
 	public void Clear()
 	{
 		var activeLines = lineFactory.GetActive(); //Retrieve active lines

 		foreach (var line in activeLines)
 		{
 			line.gameObject.SetActive(false); //Deactive each active line
        }
 	}
 }