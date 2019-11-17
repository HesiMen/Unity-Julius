using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Line : MonoBehaviour
{
    public List<GameObject> objects;
    //public Transform gameObject1;          // Reference to the first GameObject
    //public Transform gameObject2;          // Reference to the second GameObject
    //public Transform gameObject3;          // Reference to the second GameObject

    public LineRenderer line;                           // Line Renderer
    public float drawSpeed;

    float counter;
    bool line1Done;

    // Use this for initialization
    void Start()
    {
        line1Done = false;
        // Set the width of the Line Renderer
      //  line.startWidth = 0.25f;
      //  line.endWidth = 0.25f;
        // Set the number of vertex fo the Line Renderer
        line.positionCount = objects.Count;


    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, objects[0].transform.position);
        for (int i = 1; i < objects.Count; i++)
        {

            float distance = Vector3.Distance(objects[i - 1].transform.position, objects[i].transform.position);
            Vector3 drawAlongLine = DrawoLineByTime(objects[i - 1].transform, objects[i].transform, distance);
            line.SetPosition(i, drawAlongLine);


        }


    }

    public Vector3 DrawoLineByTime(Transform pointA, Transform pointB, float distance)
    {
        counter += drawSpeed * Time.deltaTime;
        float x = Mathf.Lerp(0, distance, counter);
        Vector3 drawAlongLine = x * Vector3.Normalize(pointB.position - pointA.position) + pointA.position;
        return drawAlongLine;
    }
}