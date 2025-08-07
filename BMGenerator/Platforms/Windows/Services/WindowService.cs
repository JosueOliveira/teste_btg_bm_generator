using Microsoft.UI;
using Microsoft.UI.Windowing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics;
using WinRT.Interop;

namespace BMGeneratorTest.Platforms.Windows.Services;
public partial class WindowService
{
    public static void CenterAndResize(IWindow window, int width, int height)
    {
        var nativeWindow = window.Handler.PlatformView as Microsoft.UI.Xaml.Window;
        var hWnd = WindowNative.GetWindowHandle(nativeWindow);
        var windowId = Win32Interop.GetWindowIdFromWindow(hWnd);
        var appWindow = AppWindow.GetFromWindowId(windowId);

        var displayArea = DisplayArea.GetFromWindowId(windowId, DisplayAreaFallback.Primary);

        int x = (displayArea.WorkArea.Width - width) / 2;
        int y = (displayArea.WorkArea.Height - height) / 2;

        appWindow.MoveAndResize(new RectInt32(x, y, width, height));
    }
}
