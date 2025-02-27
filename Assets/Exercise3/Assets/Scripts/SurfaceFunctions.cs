using System;
using UnityEngine;
using static UnityEngine.Mathf;

namespace Exercise3.Assets.Scripts
{
    // Robin
    public class KleinBottle : MeshFunction
    {
        public Vector2 UMinMax => new Vector2(0, 2 * PI);
        public Vector2 VMinMax => new Vector2(0, 2 * PI);
        public Vector2Int Subdivisions => new Vector2Int(150, 25);


        public Vector3 Vertex(float u, float v) => new Vector3(
            Cos(u) * (Cos(u / 2) * (Sqrt(2) + Cos(v)) + Sin(u / 2) * Sin(v) * Cos(v)),
            Sin(u) * (Cos(u / 2) * (Sqrt(2) + Cos(v)) + Sin(u / 2) * Sin(v) * Cos(v)),
            -Sin(u / 2) * (Sqrt(2) + Cos(v)) + Cos(u / 2) * Sin(v) * Cos(v)
        );
    }

    // Robin
    public class SeaShellSurface : MeshFunction
    {
        public Vector2 UMinMax => new Vector2(0, 6 * PI);
        public Vector2 VMinMax => new Vector2(0, 6 * PI);
        public Vector2Int Subdivisions => new Vector2Int(150, 25);

        /**
         * x = 2*(1-exp(u/(6*pi))).*cos(u).*cos(v/2).^2;
         * y = 2*(-1+exp(u/(6*pi))).*sin(u).*cos(v/2).^2;
         * z = 1-exp(u/(3*pi))-sin(v)+exp(u/(6*pi)).*sin(v);
         */
        public Vector3 Vertex(float u, float v) => new Vector3(
            2 * (1 - Exp(u / (6 * PI))) * Cos(u) * Pow(Cos(v / 2), 2),
            2 * (-1 + Exp(u / (6 * PI))) * Sin(u) * Pow(Cos(v / 2), 2),
            1 - Exp(u / (3 * PI)) - Sin(v) + Exp(u / (6 * PI)) * Sin(v)
        );
    }

    // Robin
    public class ConeSurface : MeshFunction
    {
        public Vector2 UMinMax => new Vector2(-1, 2 * PI);
        public Vector2 VMinMax => new Vector2(-1, 2 * PI);
        public Vector2Int Subdivisions => new Vector2Int(150, 25);

        public Vector3 Vertex(float u, float v) => new Vector3(
            Sqrt(.25f + Pow(u, 2)) * Cos(v),
            Sqrt(.25f + Pow(u, 2)) * Sin(v),
            u
        );
    }

    public class SnailSurface : MeshFunction
    {
        public Vector2 UMinMax => new Vector2(-1 * PI, 1 * PI);
        public Vector2 VMinMax => new Vector2(-1 * PI, 1 * PI);
        public Vector2Int Subdivisions => new Vector2Int(150, 25);

        public Vector3 Vertex(float u, float v) => new Vector3(
            u * Cos(v) * Sin(u),
            u * Cos(u) * Cos(v),
            -u * Sin(v)
        );
    }

    public class TorusSurface : MeshFunction
    {
        public Vector2 UMinMax => new Vector2(-1 * PI, 1 * PI);
        public Vector2 VMinMax => new Vector2(-1 * PI, 1 * PI);
        public Vector2Int Subdivisions => new Vector2Int(150, 25);

        public Vector3 Vertex(float u, float v) => new Vector3(
            (2 + Cos(v)) * Cos(u),
            (2 + Cos(v)) * Sin(u),
            Sin(v)
        );
    }

    // Oksi
    public class ConeShellSurface : MeshFunction
    {
        public Vector2 UMinMax => new Vector2(-1 * PI, 1 * PI);
        public Vector2 VMinMax => new Vector2(-1 * PI, 1 * PI);
        public Vector2Int Subdivisions => new Vector2Int(150, 25);

        public Vector3 Vertex(float u, float v) => new Vector3(
            (u / (2 * PI * 3)) * Cos(10 * u) * (1 + Cos(v)),
            (u / (2 * PI * 3)) * Sin(10 * u) * (1 + Cos(v)),
            (u / (2 * PI * 1.5f)) * Sin(v) + 7 * (u / (2 * PI))
        );
    }

    // Oksi
    public class HourglassSurface : MeshFunction
    {
        public Vector2 UMinMax => new Vector2(-1 * PI, 1 * PI);
        public Vector2 VMinMax => new Vector2(-1 * PI, 1 * PI);
        public Vector2Int Subdivisions => new Vector2Int(150, 25);

        public Vector3 Vertex(float u, float v) => new Vector3(
            Cos(u) - v * Sin(u),
            Sin(u) + v * Cos(u),
            v
        );

    }

    public class SphereSurface : MeshFunction
    {

        public Vector2 UMinMax => new Vector2(-1 * PI, 1 * PI);
        public Vector2 VMinMax => new Vector2(-1 * PI, 1 * PI);
        public Vector2Int Subdivisions => new Vector2Int(150, 25);

        public Vector3 Vertex(float u, float v) => new Vector3(
            Sin(u) * Sin(v),
            Cos(v),
            Cos(u)*Sin(v)
            
        );

    }
    
    public class PillowSurface : MeshFunction
    {

        public Vector2 UMinMax => new Vector2(-1 * PI, 1 * PI);
        public Vector2 VMinMax => new Vector2(-1 * PI, 1 * PI);
        public Vector2Int Subdivisions => new Vector2Int(150, 25);

        public Vector3 Vertex(float u, float v) => new Vector3(
            Sin(u),
            Cos(v),
            Cos(u)*Sin(v)
            
        );

    }
    
    public class UfoSurface : MeshFunction
    {

        public Vector2 UMinMax => new Vector2(-1 * PI, 1 * PI);
        public Vector2 VMinMax => new Vector2(-1 * PI, 1 * PI);
        public Vector2Int Subdivisions => new Vector2Int(150, 25);

        public Vector3 Vertex(float u, float v) => new Vector3(
            v * Sin(u),
            Sin(u) * Cos(v),
            Cos(u)
            
        );

    }

}
    
