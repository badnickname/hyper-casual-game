using UnityEngine;
using UnityEngine.UI;

namespace Source.Scoreboard
{
    public class Board : MonoBehaviour
    {
        private Text _text;
        private AudioSource _audio;

        private void Start()
        {
            _audio = GetComponent<AudioSource>();
            _text = GetComponent<Text>();
            UpdateText();
        }

        private void UpdateText()
        {
            _text.text = $"{Score.value}";
            if (Score.value < 10)
            {
                _text.text = "0" + _text.text;
            }
        }

        public int GetScore()
        {
            return Score.value;
        }
        
        public void Increase(int v)
        {
            Score.value += v;
            _audio.Play();
            UpdateText();
        }

        public void ResetValue()
        {
            Score.value = 0;
            UpdateText();
        }
    }
}