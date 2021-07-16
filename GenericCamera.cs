using System;
using UnityEngine;

namespace MonoInjectionTemplate
{
    partial class HackMain : MonoBehaviour
    {
        // Setup a local camera
        Camera _mCamera;
        
        private void AssignCamera()
        { // Set out camera to reference the main (Current) camera in the host game
            _mCamera = Camera.main;
        }

        private Vector2 W2S(Vector3 WorldPosition)
        { // Returns the screen position of a point in 3D space (relative to the camera)
            return _mCamera.WorldToScreenPoint(WorldPosition);
        }

        private float Distance(Vector3 WorldPosition)
        { // Returns the distance from the camera to a point in 3D space
            return Vector3.Distance(_mCamera.transform.position, WorldPosition);
        }
        
        private void Basic_ESP(Transform transform, string text)
        { // Simple ESP function that uses an object transform and retrieves the position in 3D space
            Vector3 pos = _mCamera.WorldToScreenPoint(transform.position);
            if (pos.z > 0)
            {
                float distance = Vector3.Distance(_mCamera.transform.position, transform.position);
                GUI.Label(new Rect(
                            pos.x,
                            Screen.height - pos.y,
                            pos.x + (text.Length * GUI.skin.label.fontSize),
                            Screen.height - pos.y + GUI.skin.label.fontSize*2),
                            text);
            }
        }
        private void Basic_ESP(Vector3 WorldPosition, string text)
        { // Simple ESP function that takes a point in 3D space as a parameter
            Vector3 pos = _mCamera.WorldToScreenPoint(WorldPosition);
            if (pos.z > 0)
            {
                int numLines = text.Split('\n').Length;
                float distance = Vector3.Distance(_mCamera.transform.position, WorldPosition);
                GUI.Label(new Rect(
                            pos.x, 
                            Screen.height - pos.y,
                            pos.x + (text.Length * GUI.skin.label.fontSize),
                            Screen.height - pos.y + GUI.skin.label.fontSize*2),
                            text);
            }
        }
        

    }
}