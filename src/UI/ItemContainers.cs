using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MonoInjectionTemplate.UI
{
    public class ItemContainers
    {
        public class ButtonContainer
        {
            private readonly Rect _loc;
            private readonly string _text;
            private readonly Action _function;
            
            public ButtonContainer(Rect loc, string text, Action function)
            {
                _loc = loc;
                _text = text;
                _function = function;
            }

            public void RenderControl()
            {
                if (GUI.Button(_loc, _text))
                {
                    _function();
                }
            }
        }
        public class ToggleContainer
        {
            private readonly Rect _loc;
            private readonly string _text;
            private readonly Action _function;
            private bool _state;
            
            public ToggleContainer(Rect loc, string text, Action onToggle)
            {
                _loc = loc;
                _text = text;
                _function = onToggle;
            }

            public void RenderControl()
            {
                var last = _state;
                _state = GUI.Toggle(_loc, _state, _text);
                if (_state != last)
                {
                    _function();
                }
            }
        }
        public class SliderContainer
        {
            private readonly Rect _loc;
            private readonly string _text;
            private readonly Action<float> _function;
            private float _value;
            private readonly float _min;
            private readonly float _max;
            private readonly float _increment;

            public SliderContainer(Rect loc, string text,float min,float max,
                Action<float> onAdjust,
                float @default = float.NaN, float increment = 0.01f)
            {
                _loc = loc;
                _text = text;
                _min = min;
                _max = max;
                _function = onAdjust;
                _increment = increment;
                _value =  !float.IsNaN(@default)? @default:min;
            }

            public void RenderControl()
            {
                var last = _value;
                GUI.Label(_loc,$"{_text}: {_value:F2}");
                Rect slidePos = new Rect(_loc);
                slidePos.y += slidePos.height;
                _value = GUI.HorizontalSlider(
                         slidePos,
                    _value, 
                    _min, 
                    _max);
                if (Math.Abs(_value - last) > 0.001)
                {
                    _value = (float)Math.Round(_value/_increment)*_increment;
                    _function(_value);
                }
            }
        }


        public class ObjectScrollContainer
        {
            private readonly Rect _loc;
            private readonly string _text;
            private List<GameObject> _items;
            private readonly Action<GameObject> _function;
            private Vector2 _scrollPosition = Vector2.zero;
            private int _padding;
            private int _controlHeight;
            
            
            public ObjectScrollContainer(Rect loc, string text, List<GameObject> items, Action<GameObject> function, int padding = 5, int controlHeight = 20)
            {
                _loc = loc;
                _text = text;
                _items = items;
                _function = function;
                _padding = padding;
                _controlHeight = controlHeight;
            }

            public void RenderControl()
            {
                GUI.Label(new Rect(_loc.x, _loc.y, _loc.width, _controlHeight), _text);
                _scrollPosition = GUI.BeginScrollView(new Rect(_loc.x, _loc.y+(_controlHeight+_padding), _loc.width, _loc.height), _scrollPosition, new Rect(0, 0, 0, (_controlHeight+_padding)*_items.Count));
                foreach (var item in _items.Select((value,index) => new {index,value}))
                {
                    if (item.value is null)
                    {
                        GUI.Label(new Rect(0, (_controlHeight+_padding)*item.index, _loc.width, _controlHeight),$"Item {item.index} Unloaded");
                        continue;
                    }
                    
                    if (GUI.Button(new Rect(0, (_controlHeight+_padding)*item.index, _loc.width, _controlHeight), $"{item.value.name} [{item.value.tag}]"))
                    {
                        _function(item.value);
                    }
                }
                GUI.EndScrollView();
            }
            
            
            
            
        }
        
        
        
        
        
        
    }
}


/*
 scroll window
 //  GUI.Label(new Rect(100, 100, 300, 100), ConsoleInterface.PassedStr);
          
          scrollPosition = GUI.BeginScrollView(new Rect(10, 300, 200, 100), scrollPosition, new Rect(0, 0, 180, 200));

          // Make four buttons - one in each corner. The coordinate system is defined
          // by the last parameter to BeginScrollView.
          GUI.Button(new Rect(0, 0, 180, 20), "A");
          GUI.Button(new Rect(0, 25, 180, 20), "b");
          GUI.Button(new Rect(0, 50, 180, 20), "c");
          GUI.Button(new Rect(0, 75, 180, 20), "d");
          GUI.Button(new Rect(0, 100, 180, 20), "e");
          GUI.Button(new Rect(0, 125, 180, 20), "f");
          GUI.Button(new Rect(0, 150, 180, 20), "g");
          GUI.Button(new Rect(0, 175, 180, 20), "h");
          GUI.Button(new Rect(0, 200, 180, 20), "i");

          // End the scroll view that we began above.
          GUI.EndScrollView();
*/



// foreach (var buttonContainer in _buttons)
// {
//     buttonContainer.RenderControl();
// }