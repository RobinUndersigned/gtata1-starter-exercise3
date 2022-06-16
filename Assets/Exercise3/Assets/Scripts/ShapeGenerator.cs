using UnityEngine;
namespace Exercise3.Assets.Scripts
{
    public class ShapeGenerator
    {
        private ShapeSettings shapeSettings;

        public ShapeGenerator(ShapeSettings shapeSettings)
        {
            this.shapeSettings = shapeSettings;
        }

        public Vector3 CalculatePointOnPlanet(Vector3 pointOnUnitSphere)
        {
            return pointOnUnitSphere * shapeSettings.planetRadius;
        }
    }
}