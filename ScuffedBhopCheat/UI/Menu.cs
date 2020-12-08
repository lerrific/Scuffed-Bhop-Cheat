using ScuffedBhopCheat.Utils;
using System.Reflection;
using UnityEngine;

namespace ScuffedBhopCheat.UI
{
    public class Menu : MonoBehaviour
    {
        private SPPlayer player;

        private Rect menu;
        private bool menuVisible = true;

        private float instance = 69f;

        private void Start()
        {
            menu = new Rect(20f, 60f, 250f, 150f);

            player = FindObjectOfType<SPPlayer>();

            instance = Random.Range(1.0f, 100.0f);
        }

        private void Update()
        {
            player = FindObjectOfType<SPPlayer>();

            if (Input.GetKeyDown(KeyCode.Insert))
                menuVisible = !menuVisible;

            if (player != null)
            {
                Cursor.lockState = menuVisible ? CursorLockMode.None : CursorLockMode.Locked;
                Cursor.visible = menuVisible;
                player.enabled = !menuVisible;
                Time.timeScale = menuVisible ? 0.0f : 1.0f;
            }

            if (Input.GetKeyDown(KeyCode.Delete))
            {
                menuVisible = !menuVisible;
                Loader.Unload();
            }

            if (player != null)
            {
                player.xMouseSensitivity = Utils.Settings.xSensitivity;
                player.yMouseSensitivity = Utils.Settings.ySensitivity;
                player.moveSpeed = Utils.Settings.moveSpeed;
                player.jumpSpeed = Utils.Settings.jumpSpeed;
                player.gravity = Utils.Settings.gravity;
                player.friction = Utils.Settings.friction;
            }
        }

        private void OnGUI()
        {
            if (Utils.Settings.watermark)
            {
                GUI.Label(new Rect(0, 50, 300, 60), $"SCUFFED BHOP CHEAT by lerrific");
                GUI.Label(new Rect(0, 60, 300, 60), $"instance " + instance);
            }

            if (menuVisible)
                menu = GUILayout.Window(0, menu, new GUI.WindowFunction(RenderUI), "SCUFFED BHOP CHEAT by lerrific", new GUILayoutOption[0]);
        }

        private void RenderUI(int id)
        {
            switch (id)
            {
                case 0:
                    GUILayout.Label("insert = toggle menu", new GUILayoutOption[0]);
                    GUILayout.Label("delete = eject dll", new GUILayoutOption[0]);

                    Utils.Settings.watermark = GUILayout.Toggle(Utils.Settings.watermark, "draw watermark", new GUILayoutOption[0]);
                    GUILayout.Label("xSensitivity: " + Utils.Settings.xSensitivity, new GUILayoutOption[0]);
                    Utils.Settings.xSensitivity = GUILayout.HorizontalSlider(Utils.Settings.xSensitivity, 1.0f, 256.0f, new GUILayoutOption[0]);
                    GUILayout.Label("ySensitivity: " + Utils.Settings.ySensitivity , new GUILayoutOption[0]);
                    Utils.Settings.ySensitivity = GUILayout.HorizontalSlider(Utils.Settings.ySensitivity, 1.0f, 256.0f, new GUILayoutOption[0]);
                    GUILayout.Label("moveSpeed: " + Utils.Settings.moveSpeed , new GUILayoutOption[0]);
                    Utils.Settings.moveSpeed = GUILayout.HorizontalSlider(Utils.Settings.moveSpeed, 1.0f, 256.0f, new GUILayoutOption[0]);
                    GUILayout.Label("jumpSpeed: " + Utils.Settings.jumpSpeed, new GUILayoutOption[0]);
                    Utils.Settings.jumpSpeed = GUILayout.HorizontalSlider(Utils.Settings.jumpSpeed, 1.0f, 256.0f, new GUILayoutOption[0]);
                    GUILayout.Label("gravity: " + Utils.Settings.gravity , new GUILayoutOption[0]);
                    Utils.Settings.gravity = GUILayout.HorizontalSlider(Utils.Settings.gravity, 1.0f, 256.0f, new GUILayoutOption[0]);
                    GUILayout.Label("friction: " + Utils.Settings.friction , new GUILayoutOption[0]);
                    Utils.Settings.friction = GUILayout.HorizontalSlider(Utils.Settings.friction, 1.0f, 256.0f, new GUILayoutOption[0]);
                    break;
                default:
                    break;
            }

            GUI.DragWindow();
        }
    }
}
