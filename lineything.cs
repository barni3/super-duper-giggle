// This is Claude's Script, i inputed "How to draw a line between 2 GameObjects in Unity" and got this

using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public GameObject Queenstown; // Reference to the first GameObject
    public GameObject Toa_Payoh; // Reference to the second GameObject

    private LineRenderer lineRenderer;

    [System.Obsolete]
    void Start()
    {
        // Create a new LineRenderer component
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f; // Set the initial line width
        lineRenderer.endWidth = 0.1f; // Set the final line width
        lineRenderer.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lineRenderer.SetColors(Color.green, Color.green); // Set the line color
    }

    void Update()
    {
        DrawLineBetweenObjects();
    }

    void DrawLineBetweenObjects()
    {
        // Check if the GameObject references are assigned
        if (Queenstown != null && Toa_Payoh != null)
        {
            lineRenderer.SetPosition(0, Queenstown.transform.position);
            lineRenderer.SetPosition(1, Toa_Payoh.transform.position);
        }
    }
}