using System;
using System.Collections;
using System.Collections.Generic;
using Exercise3.Assets.Scripts;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [Range(2, 56)] private int resolution = 10;
    
    private ShapeGenerator shapeGenerator;
    
    private MeshFilter[] meshFilters;
    private TerrainFace[] terrainFaces;
    [SerializeField] private ColorSettings colorSettings;
    [SerializeField] private ShapeSettings shapeSettings;
   
    private void OnValidate()
    {
        GeneratePlanet();
    }

    private void Initialize()
    {
        if (meshFilters == null || meshFilters.Length == 0)
        {
            meshFilters = new MeshFilter[6];
            shapeGenerator = new ShapeGenerator(shapeSettings);
            terrainFaces = new TerrainFace[6];
            Vector3[] directions = { Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back };

            for (int i = 0; i < 6; i++)
            {
                if (meshFilters[i] == null)
                {
                    GameObject meshObject = new GameObject("mesh");
                    meshObject.transform.parent = transform;
                    meshObject.AddComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("DefaultHDMaterial"));
                    meshFilters[i] = meshObject.AddComponent<MeshFilter>();
                    meshFilters[i].sharedMesh = new Mesh();
                }

                terrainFaces[i] = new TerrainFace(shapeGenerator, meshFilters[i].sharedMesh, resolution, directions[i]);
            }
        }
    }

    private void GeneratePlanet()
    {
        Initialize();
        GenerateMesh();
        GenerateColors();
    }
    
    private void OnShapeSettingsUpdated()
    {
        Initialize();
        GenerateMesh();
    }

    private void OnColorSettingsUpdated()
    {
        Initialize();
        GenerateColors();
    }
    private void GenerateMesh()
    {
        foreach(TerrainFace terrainFace in terrainFaces)
        {
            terrainFace.ConstructMesh();
        }
    }

    private void GenerateColors()
    {
        foreach (MeshFilter meshFilter in meshFilters)
        {
            meshFilter.GetComponent<MeshRenderer>().sharedMaterial.color = colorSettings.planetColor;
        }
    }
   
}
