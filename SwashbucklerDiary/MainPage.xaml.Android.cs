﻿using Microsoft.AspNetCore.Components.WebView;

namespace SwashbucklerDiary
{
    public partial class MainPage
    {
        private partial void BlazorWebViewInitializing(object? sender, BlazorWebViewInitializingEventArgs e)
        {
        }

        private partial void BlazorWebViewInitialized(object? sender, BlazorWebViewInitializedEventArgs e)
        {
            e.WebView.VerticalScrollBarEnabled = false;
        }
    }
}
