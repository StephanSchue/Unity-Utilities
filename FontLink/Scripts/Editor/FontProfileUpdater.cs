using UnityEngine;
using UnityEditor;

namespace Schueritz.Applications.Fonts
{
    public class FontProfileUpdater : EditorWindow
    {
        // Add menu item
        [MenuItem("Window/FontProfile/Update Assets")]
        private static void UpdateFontAssets(MenuCommand command)
        {
            Debug.Log("UpdateFontAssets");
            string[] guids = AssetDatabase.FindAssets("FontProfile");
            FontProfile fontProfil = null;
            bool fontProfileFound = false;

            for(int i = 0; i < guids.Length; i++)
            {
                string path = AssetDatabase.GUIDToAssetPath(guids[i]);
                fontProfil = AssetDatabase.LoadAssetAtPath<FontProfile>(path);

                if(fontProfil != null)
                {
                    Debug.Log("UpdateFontAssets: Found");
                    fontProfileFound = true;
                    break;
                }
            }

            // Font Profile
            if(fontProfileFound)
            {
                FontAssetLink[] fontAssetsInScene = FindObjectsOfType<FontAssetLink>();
                Debug.LogFormat("UpdateFontAssets: fontAssetsInScene - {0}", fontAssetsInScene.Length);

                for(int i = 0; i < fontAssetsInScene.Length; i++)
                {
                    if(fontAssetsInScene[i].ValidateAsset(out Component component))
                    {
                        Undo.RecordObject(component, string.Format("UpdateFontAssets '{0}'", fontAssetsInScene[i].name));

                        if(fontAssetsInScene[i].UpdateAsset(fontProfil))
                            Debug.LogFormat("UpdateFontAssets: fontAsset - {0} success.", fontAssetsInScene[i].name);
                        else
                            Debug.LogErrorFormat("UpdateFontAssets: fontAsset - {0} failed.", fontAssetsInScene[i].name);
                    }
                }
            }
        }
    } 
}