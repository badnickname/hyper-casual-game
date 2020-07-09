using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.Menu
{
    public class ButtonsListener : MonoBehaviour
    {
        private void Start()
        {
            //Screen.SetResolution(480, 854, FullScreenMode.Windowed);
        }

        public void OnStart()
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}