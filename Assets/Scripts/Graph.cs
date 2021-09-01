using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab;

    [SerializeField, Range(10, 100)]
    int resolution = 10;

    Transform[] points;

    private void Awake()
    {
        /*
         int i = 0;
        while(i++ < 10){
            Transform point = Instantiate(pointPrefab);
            point.localPosition = Vector3.right * i;
        }
        */

        float step = 2f / resolution;
        Vector3 position = Vector3.zero;
        var scale = Vector3.one * step;

        // keep track of points for animation
        points = new Transform[resolution];

        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i] = Instantiate(pointPrefab);
            position.x = (i + 0.5f) * step - 1f;

            // graph type
            // linear
            // position.y = position.x;
            // parabola
            position.y = position.x * position.x * position.x;

            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);
        }
    }
    void Update()
    {
        float time = Time.time;
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            position.y = Mathf.Sin(Mathf.PI * (position.x + time));
            point.localPosition = position;
        }
    }
}
