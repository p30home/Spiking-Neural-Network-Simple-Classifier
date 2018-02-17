using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNNClassifier
{
    public static class MyExtensions
    {
        public static void InvokeIfRequired<T>(this T control , Action<T> action) where T: Control
        {
            if (control.Disposing || control.IsDisposed)
                return;
            if (control.InvokeRequired)
            {
                control.Invoke(action,control);
            }
            else
            {
                action(control);
            }
        }
    }
}
