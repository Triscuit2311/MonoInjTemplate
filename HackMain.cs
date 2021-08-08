using System.Collections;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace MonoInjectionTemplate
{
    [SuppressMessage("ReSharper", "Unity.RedundantEventFunction")]
    partial class HackMain : MonoBehaviour
    {
        /* - Initializing Methods - */
        public void Awake()
        {
            // This function is called when the class is loaded by the game (prior to attachment)
        }

        public void OnEnable()
        {
            // This function is called when the script is enabled by the parent object
        }

        public void Start()
        {
            // This function is called once for each instance of this class,
            // when it starts execution (in this case, attached to an object)
            m_Console.WriteLine("Start()");
            m_Log.Log("Start()");
            m_Log.Error("Example Error");
            m_Log.Info("Information!");
            EntityUpdate = EntityUpdateFunct(0);
            StartCoroutine(EntityUpdate);
        }

        /* - Game Loop Methods - */
        public void Update()
        {
            // This function is called once per frame, it's frequency depends on the frame rate.
            // This is at the beginning of the game logic cycle.
        }

        public void LateUpdate()
        {   // This function is called once per frame, it's frequency depends on the frame rate.
            // This is at the end of the game logic cycle.
        }
        public void OnGUI()
        {   // This function is called at the end of the frame, after all game logic.
            // It is called twice per frame: Once for rendering, and once for GUI Events

            GUI.Label(new Rect(100, 100, 300, 100), "Hello World!");
        }
        
        /* - Physics Method - */
        public void FixedUpdate()
        {   // This function is called at a fixed frequency (Typically 100hz) and is independent of the frame rate.
            // For physics operations.
        }

        /* - Closing Methods - */
        public void OnDisable()
        {   // This function is called when the instance of the class is disabled by it's parent.
            // The component remains attached, but disabled (Component.ENABLED = false)
        }
        public void OnDestroy()
        {   // This function is called when the instance of the class is destroyed by it's parent.
            // The component and all it's data are destroyed and must be created again.
        }

    }
}