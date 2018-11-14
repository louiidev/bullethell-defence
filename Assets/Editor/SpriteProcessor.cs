using UnityEngine;
using UnityEditor;

// Automatically convert any texture file with "_bumpmap"
// in its file name into a normal map.

class MyTexturePostprocessor : AssetPostprocessor
{
    void OnPreprocessTexture()
    {
      TextureImporter ti  = (TextureImporter)assetImporter;
			ti.filterMode = FilterMode.Point;
			ti.spritePixelsPerUnit = 16;
			ti.compressionQuality = 0;
    }
}
