using System;
using System.Collections;
using System.Collections.Generic;
using SandDefender.Library.Game;
using SandDefender.Library.Settings;
using UnityEngine;
using UnityEngine.UI;

// ReSharper disable once CheckNamespace
namespace SandDefender.Gameplay.Settings
{
    // ReSharper disable once InconsistentNaming
    public class SettingsUI : GameCanvas
    {
        private GameSettingsManager _gameSettingsManager;
        
        private GameSettings _gameSettings;

        private GameSettings _commitedGameSettings;

        private Dropdown _availableResolutions;

        private Slider _musicVolumeSlider;
        
        private Text _musicVolumeSliderText;
        
        private Slider _effectsVolumeSlider;
        
        private Text _effectsVolumeSliderText;

        private Button _applyButton;

        private Button _discardButton;

        
        protected override void Start()
        {
            base.Start();
            
            _gameSettingsManager = gameObject.AddComponent<GameSettingsManager>();
            _commitedGameSettings = _gameSettingsManager.LoadOrDefault();
            _gameSettings = _gameSettingsManager.Copy(_commitedGameSettings);
            
            _applyButton = GameObject.Find("ApplyButton").GetComponent<Button>();
            _discardButton = GameObject.Find("DiscardButton").GetComponent<Button>();

            _availableResolutions = GameObject.Find("Dropdown").GetComponent<Dropdown>();
            _availableResolutions.options.Clear();
            _availableResolutions.options.AddRange(
                VideoSettings.AvailableResolutions.ConvertAll(input => new Dropdown.OptionData(input.ToString())));
            _availableResolutions.RefreshShownValue();
            _availableResolutions.onValueChanged.AddListener(arg0 =>
            {
                _gameSettings.Video.Resolution = VideoSettings.AvailableResolutions[arg0];
                
                _applyButton.enabled = true;
                _discardButton.enabled = true;
            });
            _availableResolutions.value = VideoSettings.AvailableResolutions.IndexOf(_gameSettings.Video.Resolution);

            _musicVolumeSlider = GameObject.Find("MusicVolumeSlider").GetComponent<Slider>();
            _musicVolumeSliderText = GameObject.Find("AudioSettingsPanel").GetComponentsInChildren<Text>()[2];
            _musicVolumeSlider.onValueChanged.AddListener(arg0 =>
            {
                _gameSettings.Audio.MusicVolume = arg0;
                _musicVolumeSliderText.text = "" + arg0;
                
                _applyButton.enabled = true;
                _discardButton.enabled = true;
            });
            _musicVolumeSlider.value = _gameSettings.Audio.MusicVolume;
            
            _effectsVolumeSlider = GameObject.Find("EffectsVolumeSlider").GetComponent<Slider>();
            _effectsVolumeSliderText = GameObject.Find("AudioSettingsPanel").GetComponentsInChildren<Text>()[4];
            _effectsVolumeSlider.onValueChanged.AddListener(arg0 =>
            {
                _gameSettings.Audio.EffectsVolume = arg0;
                _effectsVolumeSliderText.text = "" + arg0;
                
                _applyButton.enabled = true;
                _discardButton.enabled = true;
            });
            _effectsVolumeSlider.value = _gameSettings.Audio.EffectsVolume;

            _applyButton.enabled = false;
            _discardButton.enabled = false;
            Canvas.gameObject.SetActive(Active);
        }

        private void Update() 
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                Controller.SwitchTo("GameMenuCanvas");
        }

        public void Ok()
        {
            Discard();
            Controller.SwitchTo("GameMenuCanvas");
        }

        public void Apply()
        {
            _commitedGameSettings = _gameSettingsManager.Copy(_gameSettings);
            _gameSettingsManager.Apply(_commitedGameSettings);
            _gameSettingsManager.Save(_commitedGameSettings);
          
            _applyButton.enabled = false;
            _discardButton.enabled = false;
        }

        public void Discard()
        {
            _gameSettings = _gameSettingsManager.Copy(_commitedGameSettings);

            _musicVolumeSlider.value = _commitedGameSettings.Audio.MusicVolume;
            _effectsVolumeSlider.value = _commitedGameSettings.Audio.EffectsVolume;
            _availableResolutions.value = VideoSettings.AvailableResolutions
                .IndexOf(_commitedGameSettings.Video.Resolution);
            
            _applyButton.enabled = false;
            _discardButton.enabled = false;
        }
    }
}

