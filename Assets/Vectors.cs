using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector
{
    public float x = 0f;
    public float y = 0f;

    public Vector()
    { }
    public Vector(float x_value, float y_value)
    {
        this.x = x_value;
        this.y = y_value;
    }
}

public class Vectors : MonoBehaviour
{
    //public float y = 0;
    //float YSpeed = -9.8f;


    //public float x = 0;
    //float XSpeed = 5f;

    Vector gravity = new Vector(0, -9.8f);
    Vector wind = new Vector(5f, 0);



    Vector location = new Vector();
    Vector velocity = new Vector();

    Vector input = new Vector();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
        input = Multiply(input, 12);
        Debug.Log("nyan cat's input magnitude: " + Magnitude(input));
        /* 
         y += YSpeed;
         x += XSpeed;
         transform.position = new Vector3(x, y, transform.position.z);
         */

        velocity = Add(gravity, wind);
        velocity = Add(velocity, input); // for input
        location = Add(location, velocity); // for input
        transform.position = new Vector3(location.x, location.y, transform.position.z);
    }

    Vector Add(Vector v1, Vector v2)
    {
        Vector result = new Vector();

        result.x = v1.x + v2.x;
        result.y = v1.y + v2.y;
        return result;
    }

    Vector Subtract(Vector v1, Vector v2)
    {
        Vector result = new Vector();

        result.x = v1.x - v2.x;
        result.y = v1.y - v2.y;
        return result;
    }

    Vector Multiply(Vector v1, float scalar)
    {
        Vector result = new Vector();

        result.x = v1.x * scalar;
        result.y = v1.y * scalar;
        return result;
    }

    float Magnitude(Vector v1)
    {
        float result = Mathf.Sqrt((v1.x * v1.x) + (v1.y * v1.y));
        return result;

    }
}
