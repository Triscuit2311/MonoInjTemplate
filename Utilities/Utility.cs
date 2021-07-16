using UnityEngine;

namespace MonoInjectionTemplate
{
    partial class HackMain : MonoBehaviour
    {
        DebugConsole m_Console = new DebugConsole();
        DebugLog m_Log = new DebugLog(true);
    }
}
