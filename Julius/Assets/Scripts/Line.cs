using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Line : MonoBehaviour
{
    public List<Transform> objects;
    public Transform gameObject1;          // Reference to the first GameObject
    public Transform gameObject2;          // Reference to the second GameObject
    public Transform gameObject3;          // Reference to the second GameObject

    public LineRenderer line;                           // Line Renderer
    public float drawSpeed;
    float distance;
    float counter;
    bool line1Done;
    // Use this for initialization
    void Start()
    {
        line1Done = false;
        // Set the width of the Line Renderer
        line.startWidth = 0.25f;
        line.endWidth = 0.25f;
        // Set the number of vertex fo the Line Renderer
        line.positionCount = 2;
        line.SetPosition(0, gameObject1.position);
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(gameObject1.position, gameObject2.position);
        Vector3 drawAlongLine = DrawoLineByTime(gameObject1, gameObject2);
        line.SetPosition(1, drawAlongLine); 

        

    }

    public Vector3 DrawoLineByTime(Transform pointA, Transform pointB)
    {
        counter += drawSpeed * Time.deltaTime;
        float x = Mathf.Lerp(0, distance, counter);
        // Update position of the two vertex of the Line Renderer
        // line.SetPosition(0, gameObject1.transform.position);
        Vector3 drawAlongLine = x * Vector3.Normalize(pointB.position - pointA.position) + pointA.position;
        return drawAlongLine;
    }
}