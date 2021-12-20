using System.Collections;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace MonoInjectionTemplate
{
    partial class HackMain : MonoBehaviour
    {
        private IEnumerator EntityUpdate;
        private IEnumerator EntityUpdateFunct(float time)
        {
            yield return new WaitForSeconds(time);
            // Update Entities here //
            
            AssignCamera();

            ///////////////////////////
            EntityUpdate = EntityUpdateFunct(5);
            StartCoroutine(EntityUpdate);
        }
    }
}