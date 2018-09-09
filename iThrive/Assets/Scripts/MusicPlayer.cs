using Assets.Scripts.Definitions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : Window {

    public Text musicInfo;
    public Button happyButton;
    public Button sadButton;
    public Button relaxButton;
    public Button metalButton;
    public Button playButton;
    public Image AlbumArt;

    private MusicPlaying MusicPlaying { get; set; }
    private float timer;

    protected override Action OnStart
    {
        get
        {
            return () =>
            {
                this.MusicPlaying = MusicPlaying.None;
                this.IsCurrentWindow = true;
                this.happyButton.onClick.AddListener(() => this.ButtonClick(this.HappyButtonClick));
                this.sadButton.onClick.AddListener(() => this.ButtonClick(this.SadButtonClick));
                this.relaxButton.onClick.AddListener(() => this.ButtonClick(this.RelaxButtonClick));
                this.metalButton.onClick.AddListener(() => this.ButtonClick(this.MetalButtonClick));
                this.playButton.onClick.AddListener(() => this.ButtonClick(SoundManager.Instance.ToggleMusic));
            };
        }
    }

    protected override Action OnClose
    {
        get
        {
            return SoundManager.Instance.GoToHome;
        }
    }

    protected override Action OnUpdate
    {
        get
        {
            return () =>
            {
                this.timer += Time.deltaTime;
                if (this.timer > 1f)
                {
                    var musicEffect = 0.0;

                    switch (this.MusicPlaying)
                    {
                        case MusicPlaying.Happy:
                            musicEffect = Player.Energy > 60
                                ? 0.5
                                : -0.2;

                            break;

                        case MusicPlaying.Sad:
                            musicEffect = Player.Energy < 40
                                ? 0.5
                                : -0.2;

                            break;

                        case MusicPlaying.Relax:
                            musicEffect = 0.3;
                            break;

                        case MusicPlaying.Metal:
                            musicEffect = Player.Energy > 50
                                ? -0.5
                                : 0.5;

                            break;
                    };

                    this.timer = 0f;
                    Player.ModifyEnergy(musicEffect);
                }
            };
        }
    }

    private void ButtonClick(Action musicPlay)
    {
        SoundManager.Instance.PlaySingleSound("click");
        musicPlay();
    }

    private void HappyButtonClick()
    {
        SoundManager.Instance.PlayHappyMusic();
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("Sparkling blimp");
        stringBuilder.AppendLine();
        stringBuilder.AppendLine("Super happy squad");
        stringBuilder.AppendLine();
        stringBuilder.AppendLine("Ultimate happy time 2");

        this.musicInfo.text = stringBuilder.ToString();
        this.MusicPlaying = MusicPlaying.Happy;
    }

    private void SadButtonClick()
    {
        SoundManager.Instance.PlaySadMusic();
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("Grief-striken serenade");
        stringBuilder.AppendLine();
        stringBuilder.AppendLine("No more hope clan");
        stringBuilder.AppendLine();
        stringBuilder.AppendLine("Saddest of times");

        this.musicInfo.text = stringBuilder.ToString();
        this.MusicPlaying = MusicPlaying.Sad;
    }

    private void RelaxButtonClick()
    {
        SoundManager.Instance.PlaySadMusic();
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("Coffee shop quartet");
        stringBuilder.AppendLine();
        stringBuilder.AppendLine("Elevator riders");
        stringBuilder.AppendLine();
        stringBuilder.AppendLine("Music for those quiet times");

        this.musicInfo.text = stringBuilder.ToString();
        this.MusicPlaying = MusicPlaying.Relax;
    }

    private void MetalButtonClick()
    {
        SoundManager.Instance.PlayMetalMusic();
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("Carnage by words");
        stringBuilder.AppendLine();
        stringBuilder.AppendLine("Death panda attack");
        stringBuilder.AppendLine();
        stringBuilder.AppendLine("The apocalypse is now, I swear it guys");

        this.musicInfo.text = stringBuilder.ToString();
        this.MusicPlaying = MusicPlaying.Metal;
    }
}
