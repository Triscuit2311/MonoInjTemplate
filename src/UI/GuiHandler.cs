using System.Collections.Generic;
using MonoInjectionTemplate.Utilities;
using UnityEngine;

namespace MonoInjectionTemplate.UI
{
    public class GuiHandler : MonoBehaviour
    {
        private GuiWindow _window1;
        private GuiWindow _window2;
        private bool _toggleState = false;
        private float someFloat1 = 0;
        private float someFloat2 = 0;

        private List<GameObject> someObjects;

        public void Start()
        {
            _window1 = gameObject.AddComponent<GuiWindow>();
            _window1.SetWindowTitle("Test Window");
            _window1.SetParameters(20,200);
            _window1.AddButton("Button 1", () => ConsoleBase.WriteLine("Button 1 Was Pressed"));
            _window1.AddButton("Button 2", () => ConsoleBase.WriteLine("Button 2 Was Pressed"));
            _window1.AddButton("Button 3", () => ConsoleBase.WriteLine("Button 3 Was Pressed"));
            _window1.AddToggle("Toggle 1", () => _toggleState = !_toggleState);
            _window1.AddSlider("Slider 1",0,10, (float x) => someFloat1 = x, 3);
            _window1.AddSlider("Slider, thresh 2f", 2,100, (float x) => someFloat2 = x,18,2.0f);
        }

        public void OnGUI()
        {
            GUI.Label(new Rect(100,200,200,300),
                $"Toggle State: {(_toggleState? "true":"false")}");
            GUI.Label(new Rect(100,230,200,300),
                $"Sliders: [someFloat1:{someFloat1}] [someFloat2:{someFloat2}]");
        }
    }
}