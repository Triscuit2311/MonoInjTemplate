using UnityEngine;

namespace MonoInjectionTemplate
{
    partial class HackMain : MonoBehaviour
    {
        // Setup a timer and a set time to reset to
        private readonly float entityUpdateInterval = 5f;
        private float entityUpdateTimer;
        
        private void EntityUpdate()
        {   // This function uses a tick to refresh entity lists at a given interval,
            // Updating the entities are expensive functions, so calling them in Update()
            // ..every frame would create game lag
            if (entityUpdateTimer <= 0f)
            {
                ///////////////////////////////////////////
                // Entity updates go here
                AssignCamera();

                
                ///////////////////////////////////////////
                SetEntityUpdate();
            }
            entityUpdateTimer -= Time.deltaTime;
        }

        private void SetEntityUpdate()
        { // This function resets the entity update timer
            entityUpdateTimer = entityUpdateInterval;
        }
    }
}