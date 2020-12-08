using UnityEngine;

namespace ScuffedBhopCheat
{
    public class Loader
    {
        public static GameObject Load;

        public static void Init()
        {
            Load = new GameObject();

            Load.AddComponent<UI.Menu>();

            Object.DontDestroyOnLoad(Load);
        }

        public static void Unload()
        {
            Object.Destroy(Load);
        }
    }
}
