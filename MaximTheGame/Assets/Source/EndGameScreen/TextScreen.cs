using UnityEngine;
using UnityEngine.UI;

namespace Source.EndGameScreen
{
    public class TextScreen : MonoBehaviour
    {
        private Text _text;
        private void Start()
        {
            _text = GetComponent<Text>();
            _text.enabled = false;
        }

        public void SetText(string text)
        {
            _text.text = text;
        }

        public void Enable()
        {
            _text.enabled = true;
        }
    }
}