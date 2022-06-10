using System;
using System.Collections;
using System.Collections.Generic;
using Exercise3.Assets.Scripts;
using UnityEngine;


public interface MeshFunction
{
    Vector2 UMinMax { get; }
    Vector2 VMinMax { get; }
        
    Vector2Int Subdivisions { get; }
    Vector3 Vertex(float u, float v);
}

public enum MeshType
{
    Snail,
    Cone,
    SeaShell,
    KleinBottle
}


[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    private Mesh mesh;
    [SerializeField] private MeshType meshType;

    

    // Start is called before the first frame update
    void Start()
    {
        Generate(SelectMeshFunction());
    }
    
    private void Generate(MeshFunction meshFunction)
    {
        mesh = new Mesh();
        var subdivisions = meshFunction.Subdivisions;
        var vertexSize = subdivisions + new Vector2Int(1, 1);
        var vertices = new Vector3[vertexSize.x * vertexSize.y];
        var uvs = new Vector2[vertices.Length];

        var uDelta = meshFunction.UMinMax.y - meshFunction.UMinMax.x;
        var vDelta = meshFunction.VMinMax.y - meshFunction.VMinMax.x;
        
        for (int y = 0; y < vertexSize.y; y++)
        {
            var v = (1f / subdivisions.y) * y;
            
            for (int x = 0; x < vertexSize.x; x++)
            {
                var u = (1f / subdivisions.x) * x;
                var uvScaled = new Vector2(u * uDelta - meshFunction.UMinMax.x, v * vDelta - meshFunction.VMinMax.y);
                var vertex = meshFunction.Vertex(uvScaled.x, uvScaled.y);

                var arrayIndex = x + y * vertexSize.x;
                vertices[arrayIndex] = vertex;
                uvs[arrayIndex] = new Vector2(u , v);
            }
        }
        
        
        var triangles = new int[subdivisions.x * subdivisions.y * 6];
        for (int i = 0; i < subdivisions.x * subdivisions.y; i++)
        {
            var triangleIndex = (i % subdivisions.x) + (i / subdivisions.x) * vertexSize.x;
            var indexer = i * 6;
            triangles[indexer + 0] = triangleIndex + 0;
            triangles[indexer + 1] = triangleIndex + subdivisions.x + 1;
            triangles[indexer + 2] = triangleIndex + 1;
        
            triangles[indexer + 3] = triangleIndex + 1;
            triangles[indexer + 4] = triangleIndex + subdivisions.x + 1;
            triangles[indexer + 5] = triangleIndex + subdivisions.x + 2;
        }

        mesh.vertices = vertices;
        mesh.uv = uvs;
        mesh.triangles = triangles;

        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();

        GetComponent<MeshFilter>().mesh = mesh;
    }

    private MeshFunction SelectMeshFunction() => meshType switch
    {
        MeshType.Snail => new SnailSurface(),
        MeshType.Cone => new ConeSurface(),
        MeshType.SeaShell => new SeaShellSurface(),
        MeshType.KleinBottle => new KleinBottle(),
        _ => throw new ArgumentOutOfRangeException(nameof(meshType))
    };
    
}
