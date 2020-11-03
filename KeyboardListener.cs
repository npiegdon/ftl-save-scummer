using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class KeyboardListener : Component
{
   [StructLayout(LayoutKind.Sequential)] struct KeyMessage { public int VirtualKeyCode, ScanCode, Flags, Time, ExtraInfo; }

   event KeyEventHandler Up;
   event KeyEventHandler Down;

   public event KeyEventHandler KeyUp { add { EnsureSubscribed(); Up += value; } remove { Up -= value; TryUnsubscribe(); } }
   public event KeyEventHandler KeyDown { add { EnsureSubscribed(); Down += value; } remove { Down -= value; TryUnsubscribe(); } }

   // This must have the same lifetime as the event subscription
   HookProc proc;
   int hookHandle;

   int KeyProc(int code, int wParam, IntPtr lParam)
   {
      int NextHook() => CallNextHookEx(hookHandle, code, wParam, lParam);
      if (code < 0) return NextHook();

      bool shift = (GetKeyState(0x10) & 0x80) == 0x80;
      bool ctrl = (GetKeyState(0x11) & 0x80) == 0x80;
      Keys modifiers = (shift ? Keys.Shift : Keys.None) | (ctrl ? Keys.Control : Keys.None);

      KeyMessage message = (KeyMessage)Marshal.PtrToStructure(lParam, typeof(KeyMessage));
      KeyEventArgs e = new KeyEventArgs((Keys)message.VirtualKeyCode | modifiers);

      switch (wParam)
      {
         case 0x100: // WM_KEYDOWN
         case 0x104: // WM_SYSKEYDOWN
            if (Down != null) Down.Invoke(null, e);
            if (e.Handled) return -1;
            break;

         case 0x101: // WM_KEYUP
         case 0x105: // WM_SYSKEYUP
            if (Up != null) Up.Invoke(null, e);
            if (e.Handled) return -1;
            break;
      }

      return NextHook();
   }

   void EnsureSubscribed()
   {
      if (hookHandle != 0) return;

      const int WH_KEYBOARD_LL = 13;

      proc = KeyProc;
      hookHandle = SetWindowsHookEx(WH_KEYBOARD_LL, proc, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]), 0);
      if (hookHandle == 0) throw new Win32Exception(Marshal.GetLastWin32Error());
   }

   void TryUnsubscribe()
   {
      if (Down != null || Up != null) return;
      if (hookHandle == 0) return;

      int result = UnhookWindowsHookEx(hookHandle);
      hookHandle = 0;
      proc = null;
      if (result == 0) throw new Win32Exception(Marshal.GetLastWin32Error());
   }

   protected override bool CanRaiseEvents => true;

   delegate int HookProc(int nCode, int wParam, IntPtr lParam);

   [DllImport("user32", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)] static extern int CallNextHookEx(int idHook, int nCode, int wParam, IntPtr lParam);
   [DllImport("user32", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)] static extern short GetKeyState(int vKey);
   [DllImport("user32", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)] static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, int dwThreadId);
   [DllImport("user32", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)] static extern int UnhookWindowsHookEx(int idHook);
}
