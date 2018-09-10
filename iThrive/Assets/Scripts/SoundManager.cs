using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioSource _soundSource;
    public AudioSource _dialogSource;
    public AudioSource _musicSource;

    public AudioClip parkMusic;
    public AudioClip coffeeMusic;
    public AudioClip houseMusic;
    public AudioClip metalMusic;
    public AudioClip sadMusic;
    public AudioClip happyMusic;
    public AudioClip relaxingMusic;
    public AudioClip[] voices;
    public AudioClip[] sounds;

    private int listIndex;
    private float currentClipTime;
    private float musicFadeSpeed = 2;

    public float masterVolume = 1f;
    private Dictionary<AudioSource, float> volumes = new Dictionary<AudioSource, float>();


    private void Awake()
    {
        if (SoundManager.Instance == null)
        {
            SoundManager.Instance = this;
        }

        if (SoundManager.Instance != this)
        {
            Object.Destroy(gameObject);
            return;
        }

        Object.DontDestroyOnLoad(this.gameObject);

        this.volumes.Add(_soundSource, 1f);
        this.volumes.Add(_dialogSource, 1f);
        this.volumes.Add(_musicSource, 1f);
        this.PlayMusic();
    }

    public void PlaySingleSound(string clipSubstring)
    {
        var clip = this.sounds.FirstOrDefault(audio => audio.name.IndexOf(clipSubstring, System.StringComparison.OrdinalIgnoreCase) >= 0);

        if (clip != null)
        {
            this.PlaySingleSound(clip);
        }
    }

    public void PlaySingleSound(AudioClip clip)
    {
        this._soundSource.Stop();
        this._soundSource.PlayOneShot(clip);
    }

    public void PlaySingleDialogue(string clipSubstring)
    {
        var clip = this.voices.FirstOrDefault(audio => audio.name.IndexOf(clipSubstring, System.StringComparison.OrdinalIgnoreCase) >= 0);

        if (clip != null)
        {
            this.PlaySingleDialogue(clip);
        }
    }

    public void PlaySingleDialogue(AudioClip clip)
    {
        this._dialogSource.Stop();
        this._dialogSource.PlayOneShot(clip);
    }

    public void PlayRandomSwappingSound()
    {

    }

    public void PlayMusic()
    {
        this._musicSource.Stop();
        this._musicSource.clip = this.houseMusic;
        this._musicSource.loop = true;
        this.UpdateVolume(_musicSource);
        this._musicSource.Play();
    }

    public void ToggleMusic()
    {
        if (this._musicSource.isPlaying)
        {
            this._musicSource.Pause();
        }
        else
        {
            this._musicSource.UnPause();
        }
    }

    public void GoToPark()
    {
        this.StopAllCoroutines();
        this.StartCoroutine(this.FadeTo(this._musicSource, this.parkMusic, this.musicFadeSpeed));
    }

    public void GoToCoffee()
    {
        this.StopAllCoroutines();
        this.StartCoroutine(this.FadeTo(this._musicSource, this.coffeeMusic, this.musicFadeSpeed));
    }

    public void GoToHome()
    {
        this.StopAllCoroutines();
        this.StartCoroutine(this.FadeTo(this._musicSource, this.houseMusic, this.musicFadeSpeed));
    }

    public void PlaySadMusic()
    {
        this.StopAllCoroutines();
        this.StartCoroutine(this.FadeTo(this._musicSource, this.sadMusic, this.musicFadeSpeed));
    }

    public void PlayHappyMusic()
    {
        this.StopAllCoroutines();
        this.StartCoroutine(this.FadeTo(this._musicSource, this.happyMusic, this.musicFadeSpeed));
    }

    public void PlayRelaxingMusic()
    {
        this.StopAllCoroutines();
        this.StartCoroutine(this.FadeTo(this._musicSource, this.relaxingMusic, this.musicFadeSpeed));
    }

    public void PlayMetalMusic()
    {
        this.StopAllCoroutines();
        this.StartCoroutine(this.FadeTo(this._musicSource, this.metalMusic, this.musicFadeSpeed));
    }

    IEnumerator FadeUp(AudioSource source, float fadeTo, float speed)
    {
        var currentVol = this.GetVolume(source);

        while (currentVol < fadeTo)
        {
            currentVol += speed * Time.fixedDeltaTime;
            this.UpdateVolume(source, currentVol);
            yield return new WaitForFixedUpdate();
        }
        this.UpdateVolume(source, fadeTo);
    }

    IEnumerator FadeDown(AudioSource source, float fadeTo, float speed)
    {
        var currentVol = this.GetVolume(source);

        while (currentVol > fadeTo)
        {
            currentVol -= speed * Time.fixedDeltaTime;
            this.UpdateVolume(source, currentVol);
            yield return new WaitForFixedUpdate();
        }
        this.UpdateVolume(source, fadeTo);
        if (fadeTo == 0)
        {
            source.Stop();
        }
    }

    IEnumerator FadeTo(AudioSource source, AudioClip clip, float speed, bool keepTime = false)
    {
        var currentVol = this.GetVolume(source);

        while (currentVol > 0)
        {
            currentVol -= speed * Time.fixedDeltaTime;
            this.UpdateVolume(source, currentVol);
            yield return new WaitForFixedUpdate();
        }
        this.UpdateVolume(source, 0);
        currentVol = 0;
        var previousTime = source.time;

        source.Stop();
        source.clip = clip;
        if (keepTime)
        {
            source.time = previousTime;
        }
        source.Play();
        while (currentVol < 1f)
        {
            currentVol += speed * Time.fixedDeltaTime;
            this.UpdateVolume(source, currentVol);
            yield return new WaitForFixedUpdate();
        }
        this.UpdateVolume(source);
    }

    public void SetVolumes(float master = 1f, float music = 1f, float effects = 1f)
    {
        var musicVol = GetVolume(_musicSource);
        var soundVol = GetVolume(_soundSource);
        var dialogVol = GetVolume(_dialogSource);

        this.masterVolume = master;
        this.volumes[_musicSource] = music;
        this.volumes[_soundSource] = effects;
        this.volumes[_dialogSource] = effects;

        this.UpdateVolume(_musicSource, musicVol);
        this.UpdateVolume(_soundSource, soundVol);
        this.UpdateVolume(_dialogSource, dialogVol);
    }

    private void UpdateVolume(AudioSource audio, float volume = 1f)
    {

        audio.volume = this.volumes[audio] * this.masterVolume * volume;
    }

    private float GetVolume(AudioSource audio)
    {
        return audio.volume / this.volumes[audio] / this.masterVolume;
    }

}


