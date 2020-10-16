using GoRogue;
using GoRogue.GameFramework;
using GoRogue.MapViews;

namespace Assets.Scripts.Map
{
    public class GameMap : GoRogue.GameFramework.Map
    {
        public GameMap(int width, int height) : base(width, height, 1, Distance.CHEBYSHEV, 4294967295, 4294967295, 0)
        {
        }

        public GameMap(ISettableMapView<IGameObject> terrainLayer, int numberOfEntityLayers, Distance distanceMeasurement,
            uint layersBlockingWalkability = 4294967295, uint layersBlockingTransparency = 4294967295,
            uint entityLayersSupportingMultipleItems = 0) : base(terrainLayer, numberOfEntityLayers,
            distanceMeasurement, layersBlockingWalkability, layersBlockingTransparency,
            entityLayersSupportingMultipleItems)
        {
        }
    }
}
