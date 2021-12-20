using UnityEngine;

namespace MonoInjectionTemplate
{
    partial class HackMain : MonoBehaviour
    {
        // We setup our console and output log in here

        DebugLog m_Log = new DebugLog(true);
    }
}
