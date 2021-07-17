using UnityEngine;

namespace MonoInjectionTemplate
{
    partial class HackMain : MonoBehaviour
    {
        private void SetGUIFontStyle(int fontSize, Color color)
        { // used to set the GUI font and color style
            GUISkin skin = GUI.skin;
            GUIStyle newStyle = skin.GetStyle("Label");
            newStyle.fontSize = fontSize;
            GUI.color = color;
        }
        
    }
}