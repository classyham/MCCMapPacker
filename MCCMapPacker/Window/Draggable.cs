using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCCMapPacker.Window
{
    public static class Draggable
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);


        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public static void Move(Form form)
        {
            Draggable.ReleaseCapture();
            Draggable.SendMessage(form.Handle, 161, new IntPtr(2), IntPtr.Zero);
        }
    }
}
