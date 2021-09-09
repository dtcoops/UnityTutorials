using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab;

    [SerializeField, Range(10, 100)]
    int resolution = 10;

    [SerializeField]
    FunctionLibrary.FunctionName function;

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
        var scale = Vector3.one * step;

        // keep track of points for animation
        points = new Transform[resolution * resolution];

        for (int i = 0, z = 0; i < points.Length; i++)
        {
            Transform point = points[i] = Instantiate(pointPrefab);
            point.localScale = scale;
            point.SetParent(transform, false);
            points[i] = point;
        }
    }
    void Update()
    {
        FunctionLibrary.Function delegateFunction = FunctionLibrary.GetFunction(function);
        float time = Time.time;
        float step = 2f / resolution;
        float v = 0.5f * step - 1f;
        for (int i = 0, x = 0, z = 0; i < points.Length; i++, x++)
        {
            if (x == resolution)
            {
                x = 0;
                z += 1;
                v = (z + 0.5f) * step - 1f;
            }
            float u = (x + 0.5f) * step - 1f;
            points[i].localPosition = delegateFunction(u, v, time);
        }
    }
}
