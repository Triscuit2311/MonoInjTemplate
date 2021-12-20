using System;
using System.Collections.Generic;
using UnityEngine;

namespace MonoInjectionTemplate.UI
{
    public class GuiWindow : MonoBehaviour
    {
        private static int _rollingIndex;
        
        private int _windowIndex;
        private Rect _windowSpace;
        private string _windowTitle = "";
        
        private int _controlIndex;
        
        //TODO: implement columns
        private int _columns = 1;

        private static int _headerPad = 20;
        private static int _pad = 5;
        private static int _controlHeight = 20;
        private static int _controlWidth = 100;

        public void Start()
        {
            _windowSpace = new Rect(100,100,100, 50);
            this._windowIndex = _rollingIndex;
            _rollingIndex += 1;
            if(_windowTitle == "") // SetWindowTitle() can be called remote before local Start()
                _windowTitle = $"Window[{_windowIndex.ToString()}]";
        }



        public void SetParameters(int controlHeight, int controlWidth, int headerPad = 20,int pad = 5 )
        {
            _headerPad = headerPad;
            _pad = pad;
            _controlHeight = controlHeight;
            _controlWidth = controlWidth;
        }

        public void SetWindowTitle(string title)
        {
            _windowTitle = title;
        }

        private void ResizeWindowToFitControls()
        {
            _windowSpace.width = _controlWidth + _pad * (1 + _columns);
            _windowSpace.height = (_controlHeight + _pad) * _controlIndex + _headerPad;
        }

        private readonly List<ItemContainers.ButtonContainer> _buttons = new();
        private readonly List<ItemContainers.ToggleContainer> _toggles = new();
        private readonly List<ItemContainers.SliderContainer> _sliders = new();
        private readonly List<ItemContainers.ObjectScrollContainer> _scrollers = new();
        
        public void AddButton(string text, Action function)
        {
            _buttons.Add(
                new ItemContainers.ButtonContainer(
                    new Rect(
                        _pad,
                        _controlIndex * (_controlHeight + _pad) + _headerPad,
                        _controlWidth,
                        _controlHeight),
                    text,
                    function));
            _controlIndex++;
        }
        public void AddToggle(string text, Action onToggle)
        {
            _toggles.Add(
                new ItemContainers.ToggleContainer(
                    new Rect(
                        _pad,
                        _controlIndex * (_controlHeight + _pad) + _headerPad,
                        _controlWidth,
                        _controlHeight),
                    text,
                    onToggle));
            _controlIndex++;
        }
        
        public void AddSlider(string text,float min,float max,
            Action<float> onAdjust,float @default = float.NaN, float increment = 0.01f)
        {
            _sliders.Add(
                new ItemContainers.SliderContainer(
                    new Rect(
                        _pad,
                        _controlIndex * (_controlHeight + _pad) + _headerPad,
                        _controlWidth,
                        _controlHeight),
                    text,
                    min,
                    max,
                    onAdjust,
                    @default,
                    increment));
            _controlIndex+=2;
        }
        
        public void AddGameObjectViewer(string text,List<GameObject> objects,
           Action<GameObject> onClick, int viewerSizeModifier = 10)
        {
            _scrollers.Add(
                new ItemContainers.ObjectScrollContainer(
                    new Rect(
                        _pad,
                        _controlIndex * (_controlHeight + _pad) + _headerPad,
                        _controlWidth,
                        _controlHeight * viewerSizeModifier),
                    text,
                    objects,
                    onClick,
                    5,
                    20));
            _controlIndex += viewerSizeModifier;
        }

        

        void WindowCore()
        {
            foreach (var buttonContainer in _buttons)
            {
                buttonContainer.RenderControl();
            }
            foreach (var toggle in _toggles)
            {
                toggle.RenderControl();
            }
            foreach (var slider in _sliders)
            {
                slider.RenderControl();
            }
            foreach (var scroller in _scrollers)
            {
                scroller.RenderControl();
            }
        }
        
        
        private void WindowWrapper(int id)
        {
            this.WindowCore();
            GUI.DragWindow(new Rect(0, 0, Screen.width, Screen.height));
        }

        public void Update()
        {
            ResizeWindowToFitControls();
        }

        public void OnGUI()
        {
            //for GUI.depth, every window needs a unique OnGUI
            _windowSpace = GUI.Window(
                _windowIndex,
                _windowSpace,
                this.WindowWrapper,
                _windowTitle
                );
        }
         
    }
}
