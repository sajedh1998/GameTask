using UnityEngine;

namespace Sound
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager instance;
        private AudioSource audioSource;
        [SerializeField] private AudioClip[] clips;

        private void Awake()
        {
            instance = this;
            audioSource = GetComponent<AudioSource>();
        }

        public void PlayClip(int index)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(clips[index]);
        }
        public void PlayClip(AudioClip clip)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(clip);
        }

        void SetValue(bool mute)
        {
            audioSource.mute = mute;
        }
    }
}