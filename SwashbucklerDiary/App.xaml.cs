﻿using SwashbucklerDiary.IServices;

namespace SwashbucklerDiary
{
    public partial class App : Application
    {
        private ISystemService SystemService { get; set; }
        private ISettingsService SettingsService { get; set; }
        public App(ISystemService systemService, ISettingsService settingsService)
        {
            InitializeComponent();

            MainPage = new MainPage();
            SystemService = systemService;
            SettingsService = settingsService;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            Window window = base.CreateWindow(activationState);

            window.Created += (s, e) =>
            {
                SettingsService.InitDefault<bool>(Models.SettingType.FirstSetLanguage);
                SettingsService.InitDefault<bool>(Models.SettingType.FirstAgree);
                SettingsService.InitDefault<int>(Models.SettingType.ThemeState);
            };
            window.Resumed += (s, e) => SystemService.OnResume();
            window.Stopped += (s, e) => SystemService.OnStop();
            return window;
        }
    }
}