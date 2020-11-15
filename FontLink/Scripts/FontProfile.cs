using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Schueritz.Applications.Fonts
{
    public enum FontCategory
    {
        FontType01,
        FontType02,
        FontType03
    }

    [CreateAssetMenu(fileName = "FontProfile", menuName = "Configs/Font Profile", order = 2)]
    public class FontProfile : ScriptableObject
    {
        [System.Serializable]
        public struct FontProfileAsset
        {
            public Font fontAsset;
            public TMP_FontAsset tmProFontAsset;

            public bool IsSet => (fontAsset != null || tmProFontAsset != null);
        }

        public FontProfileAsset[] assets;

        public bool FindAsset(FontCategory fontCategory, out FontProfileAsset fontProfileAsset)
        {
            if((int)fontCategory < assets.Length && assets[(int)fontCategory].IsSet)
            {
                fontProfileAsset = assets[(int)fontCategory];
                return true;
            }

            fontProfileAsset = new FontProfileAsset();
            return false;
        }
    }
}