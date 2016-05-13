using UnityEngine;
using System.Collections.Generic;

namespace Just.For.Testing
{
    [RequireComponent(typeof(LineRenderer))]
    public class GestureRenderer : MonoBehaviour
    {
        [SerializeField]
        private Color beginColor = Color.cyan;

        [SerializeField]
        private Color endColor = Color.magenta;

        [SerializeField]
        private float lineWidth = 0.2f;

        private List<Vector3> verts = new List<Vector3>();

        private LineRenderer lr;


        void Start()
        {
            lr = GetComponent<LineRenderer>();
            lr.SetColors(beginColor, endColor);
            lr.SetWidth(lineWidth, lineWidth);
            lr.SetVertexCount(0);
            lr.sortingLayerName = "ForeGround";
            lr.sortingOrder = 2000;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                verts.Clear();
            }

            if (Input.GetMouseButton(0))
            {
                // add vertices
                var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10);
                if (verts.Count == 0 || pos != verts[verts.Count - 1])
                {
                    verts.Add(pos);
                }

            }

            // set LineRenderer
            if (verts.Count > 1)
            {
                lr.SetVertexCount(verts.Count);
                lr.SetPositions(verts.ToArray());
            }
        }

    }
}