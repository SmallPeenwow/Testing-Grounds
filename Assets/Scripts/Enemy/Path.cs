using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Path : MonoBehaviour
{
    // The order in which you add waypoints is the order the AI will follow
    public List<Transform> waypoints;
    [SerializeField]
    private bool alwaysDrawPath;
    [SerializeField]
    private bool drawAsLoop;
    [SerializeField]
    private bool drawNumbers;
    public Color debugColour = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrawGizmos()
    {
        if (alwaysDrawPath)
        {
            DrawPath();
        }
    }

    public void DrawPath()
    {
        for (int i = 0; i < waypoints.Count; i++)
        {
            GUIStyle labelStyle = new GUIStyle();
            labelStyle.fontSize = 30;
            labelStyle.normal.textColor = debugColour;

            if (drawNumbers)
            {
                Handles.Label(waypoints[i].position, i.ToString(), labelStyle);
            }
            //Draw Lines Between Points.
            if (i >= 1)
            {
                Gizmos.color = debugColour;
                Gizmos.DrawLine(waypoints[i - 1].position, waypoints[i].position);

                if (drawAsLoop)
                {
                    Gizmos.DrawLine(waypoints[waypoints.Count - 1].position, waypoints[0].position);
                }
            }
        }
    }

    public void OnDrawGizmosSelected()
    {
        if (alwaysDrawPath)
        {
            return;
        }
        else
        {
            DrawPath();
        }
    }

}
