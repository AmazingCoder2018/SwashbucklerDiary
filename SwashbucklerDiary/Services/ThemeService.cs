﻿using SwashbucklerDiary.IServices;
using SwashbucklerDiary.Models;

namespace SwashbucklerDiary.Services
{
    public class ThemeService : IThemeService
    {
        private bool AlreadySet;
        private ThemeState _themeState = ThemeState.Light;
        public ThemeState ThemeState
        {
            get => GetThemeState();
        }
        public bool Light => ThemeState == ThemeState.Light;
        public bool Dark => ThemeState == ThemeState.Dark;

        public event Action<ThemeState>? OnChanged;

        private ThemeState GetThemeState()
        {
            if (_themeState == ThemeState.System)
            {
                return Application.Current!.RequestedTheme == AppTheme.Dark ? ThemeState.Dark : ThemeState.Light;   
            }
            
            return _themeState;
        }

        /// <summary>
        /// 系统主题切换
        /// </summary>
        public void SetThemeState(ThemeState themeState)
        {
            if(AlreadySet == false)
            {
                AlreadySet = true;
            }
            else
            {
                if(_themeState == themeState)
                {
                    return;
                }
            }

            _themeState = themeState;
            if (themeState == ThemeState.System)
            {
                Application.Current!.RequestedThemeChanged += HandlerAppThemeChanged;
            }
            else
            {
                Application.Current!.RequestedThemeChanged -= HandlerAppThemeChanged;
            }

            OnChanged?.Invoke(ThemeState);
        }

        private void HandlerAppThemeChanged(object? sender, AppThemeChangedEventArgs e)
        {
            OnChanged?.Invoke(ThemeState);
        }
    }
}
