using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Automation;

namespace AutomationPageRecorder.InspectDesktop
{
    public partial class MainWindow : Window
    {
        private const int WH_MOUSE_LL = 14;
        private LowLevelMouseProc _proc;
        private IntPtr _hookID = IntPtr.Zero;

        private bool isSelecting = true;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            StartMouseHook();
            selectedElementNameTextBlock.Text = "Clique no elemento da aplicação.";
        }

        private void StartMouseHook()
        {
            _proc = HookCallback;
            _hookID = SetHook(_proc);
        }

        private IntPtr SetHook(LowLevelMouseProc proc)
        {
            using (var curProcess = Process.GetCurrentProcess())
            using (var curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_MOUSE_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)0x201 && isSelecting)
            {
                GetCursorPos(out POINT cursorPos);

                if (IsMouseInWindow(cursorPos))
                {
                    return IntPtr.Zero;
                }

                AutomationElement element = GetElementAtMousePosition(cursorPos.X, cursorPos.Y);
                if (element != null)
                {
                    selectedElementNameTextBlock.Text = element.Current.Name;
                    elementTypeTextBlock.Text = element.Current.ControlType.ProgrammaticName;
                    elementIdTextBlock.Text = element.Current.AutomationId;
                    elementClassTextBlock.Text = element.Current.ClassName;
                }
                else
                {
                    selectedElementNameTextBlock.Text = "Nenhum elemento encontrado.";
                    elementTypeTextBlock.Text = elementIdTextBlock.Text = elementClassTextBlock.Text = string.Empty;
                }

                return IntPtr.Zero;
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        private AutomationElement GetElementAtMousePosition(int x, int y)
        {
            return AutomationElement.FromPoint(new System.Windows.Point(x, y));
        }

        private bool IsMouseInWindow(POINT cursorPos)
        {
            Rect windowRect = new Rect(Left, Top, Width, Height);
            return windowRect.Contains(new Point(cursorPos.X, cursorPos.Y));
        }

        private void CopyElementName(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(selectedElementNameTextBlock.Text);
            ResetFocus();
        }

        private void CopyElementType(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(elementTypeTextBlock.Text);
            ResetFocus();
        }

        private void CopyElementId(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(elementIdTextBlock.Text);
            ResetFocus();
        }

        private void CopyElementClass(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(elementClassTextBlock.Text);
            ResetFocus();
        }

        private void RestartSelection(object sender, RoutedEventArgs e)
        {
            isSelecting = true;
            selectedElementNameTextBlock.Text = "Clique no elemento da aplicação.";
            elementTypeTextBlock.Text = elementIdTextBlock.Text = elementClassTextBlock.Text = string.Empty;
            ResetFocus();
        }

        private void ResetFocus()
        {
            this.Focus();
            selectedElementNameTextBlock.Focus();
        }

        // Reiniciar a janela sem fechar a aplicação
        private void RestartWindow(object sender, RoutedEventArgs e)
        {
            this.Hide(); // Esconde a janela atual
            var newWindow = new MainWindow(); // Cria uma nova instância da janela
            newWindow.Show(); // Exibe a nova janela
            this.Close(); // Fecha a janela antiga
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int X;
            public int Y;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(out POINT lpPoint);

        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);
    }
}
