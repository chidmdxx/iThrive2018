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
    public Sprite happySprite;
    public Sprite sadSprite;
    public Sprite relaxSprite;
    public Sprite metalSprite;
    public Sprite blankSprite;

    private static string HappyText
    {
        get
        {
            return MusicPlayer.SongInfoBuilder("Sparkling blimp", "Super happy squad", "Ultimate happy time 2");
        }
    }

    private static string SadText
    {
        get
        {
            return MusicPlayer.SongInfoBuilder("Grief-striken serenade", "No more hope clan", "Saddest of times");
        }
    }

    private static string RelaxText
    {
        get
        {
            return MusicPlayer.SongInfoBuilder("Coffee shop quartet", "Elevator riders", "Music for those quiet times");
        }
    }

    private static string MetalText
    {
        get
        {
            return MusicPlayer.SongInfoBuilder("Carnage by words", "Death panda attack", "The apocalypse is now, I swear it guys");
        }
    }

    private MusicPlaying MusicPlaying { get; set; }
    private float timer;

    protected override Action OnStart
    {
        get
        {
            return () =>
            {
                this.MusicPlaying = MusicPlaying.None;
                this.AlbumArt.sprite = this.blankSprite;
                this.IsCurrentWindow = true;
                this.happyButton.onClick.AddListener(() => this.ButtonClick(this.HappyButtonClick));
                this.sadButton.onClick.AddListener(() => this.ButtonClick(this.SadButtonClick));
                this.relaxButton.onClick.AddListener(() => this.ButtonClick(this.RelaxButtonClick));
                this.metalButton.onClick.AddListener(() => this.ButtonClick(this.MetalButtonClick));
                this.playButton.onClick.AddListener(() => this.ButtonClick(this.PauseButtonClick));
            };
        }
    }

    protected override Action OnClose
    {
        get
        {
            return () =>
            {
                if (this.MusicPlaying != MusicPlaying.None)
                {
                    SoundManager.Instance.GoToHome();
                }

                this.MusicPlaying = MusicPlaying.None;
                this.AlbumArt.sprite = this.blankSprite;
                this.musicInfo.text = string.Empty;
            };
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
        this.musicInfo.text = MusicPlayer.HappyText;
        this.AlbumArt.sprite = this.happySprite;
        this.MusicPlaying = MusicPlaying.Happy;
    }

    private void SadButtonClick()
    {
        SoundManager.Instance.PlaySadMusic();
        this.musicInfo.text = MusicPlayer.SadText;
        this.AlbumArt.sprite = this.sadSprite;
        this.MusicPlaying = MusicPlaying.Sad;
    }

    private void RelaxButtonClick()
    {
        SoundManager.Instance.PlaySadMusic();
        this.musicInfo.text = MusicPlayer.RelaxText;
        this.AlbumArt.sprite = this.relaxSprite;
        this.MusicPlaying = MusicPlaying.Relax;
    }

    private void MetalButtonClick()
    {
        SoundManager.Instance.PlayMetalMusic();
        this.musicInfo.text = MusicPlayer.MetalText;
        this.AlbumArt.sprite = this.metalSprite;
        this.MusicPlaying = MusicPlaying.Metal;
    }

    private void PauseButtonClick()
    {
        if (this.MusicPlaying != MusicPlaying.None)
        {
            SoundManager.Instance.ToggleMusic();
        }
    }

    private static string SongInfoBuilder(string songName, string bandName, string albumName)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(songName);
        stringBuilder.AppendLine();
        stringBuilder.AppendLine(bandName);
        stringBuilder.AppendLine();
        stringBuilder.AppendLine(albumName);

        return stringBuilder.ToString();
    }
}
