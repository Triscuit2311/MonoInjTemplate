using UnityEngine;

namespace MonoInjectionTemplate
{
    partial class HackMain : MonoBehaviour
    {
        // We setup our console and output log in here
        DebugConsole m_Console = new DebugConsole();
        DebugLog m_Log = new DebugLog(true);
    }
}
