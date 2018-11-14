using UnityEngine;
using UnityEditor;

class SpriteProcessor : AssetPostprocessor
{
    void OnPreprocessTexture()
    {
      TextureImporter ti  = (TextureImporter)assetImporter;
			ti.filterMode = FilterMode.Point;
			ti.spritePixelsPerUnit = 16;
			ti.textureCompression = TextureImporterCompression.Uncompressed;
    }
}
