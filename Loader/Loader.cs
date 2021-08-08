using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MonoInjectionTemplate
{
    public class Loader
    {
        // Create a new GameObject
        // In unity, a GameObject does not have a physical body, it is a parent 'container'
        // The GameObject can be assigned components, 'Children'
        private static readonly GameObject MGameObject = new GameObject();
        
        public static void Load() 
        { // The function that our injector calls inside our target process
            
            // Here, we add a Component 'Child' to our game object.
            // For example is we had the reference to this component we could use functions like:
            // ... HackMain.GetComponentInParent<type>() to retrieve other components attacked to the same object
            // ... aka 'Sibling Components'
            MGameObject.AddComponent<HackMain>();
            
            // We tell Object (Our universal base class) that we do not want this component to need initializing
            // ... on every scene load. Otherwise the object would be destroyed by the engine when we change scenes,
            // ... This assumes that we would make another instance of this object when we change maps,
            // ... go to the main menu, etc. (Change scenes)
            Object.DontDestroyOnLoad(MGameObject);
        }
        public static void Unload() 
        { // Destroys the Created object, again called by our injector to "eject" the assembly.
            Object.Destroy(MGameObject); //Destroys all instances of the object.
        }
    }
}