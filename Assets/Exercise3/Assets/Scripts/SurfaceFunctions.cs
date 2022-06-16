using System;
using UnityEngine;
using static UnityEngine.Mathf;

namespace Exercise3.Assets.Scripts
{
    public class KleinBottle : MeshFunction
    {
        public Vector2 UMinMax => new Vector2(0, 2 * PI);
        public Vector2 VMinMax => new Vector2(0 , 2 * PI);
        public Vector2Int Subdivisions => new Vector2Int(150, 25);


        public Vector3 Vertex(float u, float v) => new Vector3(
            -(2/15)*Cos(u)*(3*Cos(v)-30*Sin(u)+90*Pow(Cos(u), 4)*Sin(u)-60*Pow(Cos(u), 6)*Sin(u)+5*Cos(u)*Cos(v)*Sin(u)),
            -(1/15)*Sin(u)*(3*Cos(v)-3*Pow(Cos(u), 2)*Cos(v)-48*Pow(Cos(u), 4)*Cos(v)+48*Pow(Cos(u), 6)*Cos(v)-60*Sin(u)+5*Cos(u)*Cos(v)*Sin(u)-5*Pow(Cos(u), 3)*Cos(v)*Sin(u) -80*Pow(Cos(u), 5)*Cos(v)*Sin(u)+80*Pow(Cos(u), 7)*Cos(v)*Sin(u)),
            (2/15)*(3+5*Cos(u)*Sin(u))*Sin(v)
        );
    }
    
    public class SeaShellSurface : MeshFunction
    {
        public Vector2 UMinMax => new Vector2(0, 6 * PI);
        public Vector2 VMinMax => new Vector2(0 , 6 * PI);
        public Vector2Int Subdivisions => new Vector2Int(150, 25);

        /**
         * x = 2*(1-exp(u/(6*pi))).*cos(u).*cos(v/2).^2;
         * y = 2*(-1+exp(u/(6*pi))).*sin(u).*cos(v/2).^2;
         * z = 1-exp(u/(3*pi))-sin(v)+exp(u/(6*pi)).*sin(v);
         */
        public Vector3 Vertex(float u, float v) => new Vector3(
            2*(1-Exp(u/(6*PI)))*Cos(u)*Pow(Cos(v/2), 2),
            2*(-1+Exp(u/(6*PI)))*Sin(u)*Pow(Cos(v/2), 2),
            1-Exp(u/(3*PI)) - Sin(v)  +Exp(u/(6*PI)) * Sin(v)
        );
    }
    public class ConeSurface : MeshFunction
    {
        public Vector2 UMinMax => new Vector2(-1, 2 * PI);
        public Vector2 VMinMax => new Vector2(-1 , 2 * PI);
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

    public class Doughnut : MeshFunction
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
    
    public class Poop : MeshFunction
    {
        public Vector2 UMinMax => new Vector2(-1 * PI, 5 * PI);
        public Vector2 VMinMax => new Vector2(-1 * PI, 5 * PI);
        public Vector2Int Subdivisions => new Vector2Int(50, 5);
        
        private float r = 1.5f;
        
        // public Vector3 Vertex(float u, float v) => new Vector3(
        //     5/4 * (1 - v/(2*PI)) * Cos(2 * v) * (1 + Cos(u)) + Cos(2 * v),
        //     5/4 * (1 - v/(2*PI)) * Sin(2 * v) * (1 + Cos(u)) + Sin(2 * v),
        //     10 * v / 2 * PI + 5/4 * (1 - v/(2*PI)) * Sin(u) + 15
        // );

        public Vector3 Vertex(float u, float v) => new Vector3(
            Sin(v) + 2 * Sin(2 * u),
            (2 + Cos(v)) * Sin(u),
            Sin(v) - (u/2)
        );
    }
}