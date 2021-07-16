using UnityEngine;

namespace MonoInjectionTemplate
{
    public class Loader
    {
        public static void Load()
        {
            m_GameObject.AddComponent<HackMain>();
            Object.DontDestroyOnLoad(m_GameObject);
        }
        public static void Unload()
        {
            Object.Destroy(m_GameObject);
        }

        private static GameObject m_GameObject = new GameObject();
    }
}