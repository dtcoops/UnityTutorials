using UnityEngine;
using static UnityEngine.Mathf;

public static class FunctionLibrary
{

    public delegate Vector3 Function(float x, float z,  float time);

    public enum FunctionName { Wave, MultiWave, Ripple, Sphere, Torus, Trefoil }

    static Function[] functions = { Wave, MultiWave, Ripple, Sphere, Torus, Trefoil };

    public static Function GetFunction(FunctionName name)
    {
        return functions[(int)name];
    }

    // f(x,t) = sin(pi(x + t))
    public static Vector3 Wave(float u, float v, float time)
    {
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (u + v + time));
        p.z = v;
        return p;
    }

    public static Vector3 MultiWave(float u, float v, float time)
    {
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (u + 0.5f * time));
        p.y += 0.5f * Sin(2f * PI * (v + time));
        p.y += Sin(PI * (u + v + 0.25f * time));
        p.y *= 1f / 2.5f;
        p.z = v;
        return p;
    }

    public static Vector3 Ripple(float u, float v, float t)
    {
        float d = Sqrt(u * u + v * v);
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (4f * d - t));
        p.y /= 1f + 10f * d;
        p.z = v;
        return p;
    }

    public static Vector3 Sphere (float u, float v, float time)
    {
        float radius = 0.9f + 0.1f * Sin(PI * (6f * u + 4f * v + time));
        float s = radius * Cos(0.5f * PI * v);
        Vector3 p;
        p.x = s * Sin(PI * u);
        p.y = radius * Sin(PI * 0.5f * v);
        p.z = s * Cos(PI * u);
        return p;

    }

    public static Vector3 Torus (float u, float v, float time)
    {
        float r1 = 0.7f + 0.1f * Sin(PI * (6f * u + 0.5f * time));
        float r2 = 0.15f + 0.05f * Sin(PI * (8f * u + 4f * v + 2f * time));
        float s = r1 + r2 * Cos(PI * v);
        Vector3 p;
        p.x = s * Sin(PI * u);
        p.y = r2 * Sin(PI * v);
        p.z = s * Cos(PI * u);
        return p;
    }

    public static Vector3 Trefoil(float u, float v, float time)
    {
        Vector3 p;
        p.x = Sin(time) + (2 * Sin(2 * time));
        p.y = Cos(time) - (2 * Cos(2 * time));
        p.z = -1 * (Sin(3 * time));
        return p;
    }
}
