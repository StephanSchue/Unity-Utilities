using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Schueritz.Applications.Fonts
{
    public class FontAssetLink : MonoBehaviour
    {
        public enum FontAssetType
        {
            Text,
            TextMesh,
            TextMeshPro,
            TextMeshProUI
        }

        public FontCategory fontCategory;

        private Text textComponent;
        private TextMesh textMeshComponent;
        private TextMeshPro textMeshProComponent;
        private TextMeshProUGUI textMeshProUIComponent;

        private FontAssetType textAssetType;

        public bool ValidateAsset(out Component component)
        {
            if(TryGetComponent(out Text textField))
            {
                textComponent = textField;
                textAssetType = FontAssetType.Text;
                component = textField;
                return true;
            }
            else if(TryGetComponent(out TextMesh textMesh))
            {
                textMeshComponent = textMesh;
                textAssetType = FontAssetType.TextMesh;
                component = textMesh;
                return true;
            }
            else if(TryGetComponent(out TextMeshPro textFieldTMPro))
            {
                textMeshProComponent = textFieldTMPro;
                textAssetType = FontAssetType.TextMeshPro;
                component = textFieldTMPro;
                return true;
            }
            else if(TryGetComponent(out TextMeshProUGUI textFieldTMProUI))
            {
                textMeshProUIComponent = textFieldTMProUI;
                textAssetType = FontAssetType.TextMeshProUI;
                component = textFieldTMProUI;
                return true;
            }

            component = null;
            return false;
        }

        public bool UpdateAsset(FontProfile fontProfile)
        {
            if(fontProfile.FindAsset(fontCategory, out FontProfile.FontProfileAsset fontProfileAsset))
            {
                Debug.LogFormat("'{0}': FontAssetLink.UpdateAsset: {1}", name, fontProfileAsset.fontAsset.name);
                switch(textAssetType)
                {
                    case FontAssetType.Text:
                        textComponent.font = fontProfileAsset.fontAsset;
                        return true;
                    case FontAssetType.TextMesh:
                        textComponent.font = fontProfileAsset.fontAsset;
                        return true;
                    case FontAssetType.TextMeshPro:
                        textMeshProComponent.font = fontProfileAsset.tmProFontAsset;
                        return true;
                    case FontAssetType.TextMeshProUI:
                        textMeshProUIComponent.font = fontProfileAsset.tmProFontAsset;
                        return true;
                }
            }
            else
            {
                Debug.LogFormat("'{0}': FontAssetLink.UpdateAsset: NoProfile found for '{1}'!", name, fontCategory);
            }
            
            return false;
        }
    }
}