﻿Imports System.Runtime.InteropServices
Imports WinPaletter.XenonCore

Namespace NativeMethods

    Public Class Dwmapi

        <DllImport("dwmapi.dll", EntryPoint:="#131", PreserveSig:=False)>
        Public Shared Sub DwmSetColorizationParameters(ByRef parameters As DWM_COLORIZATION_PARAMS, ByVal unknown As Boolean)
        End Sub

        <DllImport("dwmapi.dll")>
        Public Shared Sub DwmEnableComposition(ByVal uCompositionAction As CompositionAction)
        End Sub


        <DllImport("dwmapi.dll")>
        Public Shared Function DwmIsCompositionEnabled(ByRef enabled As Boolean) As Integer
        End Function

        <Runtime.InteropServices.DllImport("dwmapi")> Public Shared Function DwmExtendFrameIntoClientArea(ByVal hWnd As IntPtr, ByRef pMarInset As MARGINS) As Integer
        End Function

        <Runtime.InteropServices.DllImport("dwmapi")> Friend Shared Function DwmSetWindowAttribute(ByVal hwnd As IntPtr, ByVal attr As Integer, ByRef attrValue As Integer, ByVal attrSize As Integer) As Integer
        End Function

        Public Const CS_DROPSHADOW As Integer = &H20000
        Public Const WM_NCPAINT As Integer = &H85

        Public Enum CompositionAction As Integer
            DWM_EC_DISABLECOMPOSITION = 0
            DWM_EC_ENABLECOMPOSITION = 1
        End Enum

        Public Structure MARGINS
            Public leftWidth As Integer
            Public rightWidth As Integer
            Public topHeight As Integer
            Public bottomHeight As Integer
        End Structure

        Public Structure DWM_COLORIZATION_PARAMS
            Public clrColor As Integer
            Public clrAfterGlow As Integer
            Public nIntensity As Integer
            Public clrAfterGlowBalance As Integer
            Public clrBlurBalance As Integer
            Public clrGlassReflectionIntensity As Integer
            Public fOpaque As Boolean
        End Structure

    End Class

    Public Class User32
        <DllImport("user32.dll")>
        Public Shared Function AnimateWindow(ByVal hWnd As IntPtr, ByVal time As Integer, ByVal flags As AnimateWindowFlags) As Boolean
        End Function

        <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
        Public Shared Function SendMessageTimeout(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As UIntPtr, ByVal lParam As IntPtr, ByVal fuFlags As SendMessageTimeoutFlags, ByVal uTimeout As UInteger, <Out> ByRef lpdwResult As UIntPtr) As IntPtr
        End Function

        Declare Function SHChangeNotify Lib "Shell32.dll" (ByVal wEventID As Int32, ByVal uFlags As Int32, ByVal dwItem1 As Int32, ByVal dwItem2 As Int32) As Int32

        Friend Declare Function SetWindowCompositionAttribute Lib "user32.dll" (ByVal hwnd As IntPtr, ByRef data As WindowCompositionAttributeData) As Integer

        Private Declare Auto Function FindWindow Lib "user32.dll" (ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr

        <StructLayout(LayoutKind.Sequential)>
        Friend Structure AccentPolicy
            Public AccentState As AccentState
            Public AccentFlags As Integer
            Public GradientColor As Integer
            Public AnimationId As Integer
        End Structure

        Friend Structure WindowCompositionAttributeData
            Public Attribute As WindowCompositionAttribute
            Public Data As IntPtr
            Public SizeOfData As Integer
        End Structure

        Friend Enum WindowCompositionAttribute
            WCA_ACCENT_POLICY = 19
        End Enum

        Friend Enum AccentState
            ACCENT_DISABLED = 0
            ACCENT_ENABLE_GRADIENT = 1
            ACCENT_ENABLE_TRANSPARENTGRADIENT = 2
            ACCENT_ENABLE_BLURBEHIND = 3
            ACCENT_ENABLE_TRANSPARANT = 6
            ACCENT_ENABLE_ACRYLICBLURBEHIND = 4
        End Enum

        Enum SendMessageTimeoutFlags As UInteger
            SMTO_NORMAL = &H0
            SMTO_BLOCK = &H1
            SMTO_ABORTIFHUNG = &H2
            SMTO_NOTIMEOUTIFNOTHUNG = &H8
        End Enum

        Shared WM_DWMCOLORIZATIONCOLORCHANGED As Integer = &H320
        Shared WM_DWMCOMPOSITIONCHANGED As Integer = &H31E
        Shared WM_THEMECHANGED As Integer = &H31A
        Shared WM_SYSCOLORCHANGE As Integer = &H15
        Shared WM_PALETTECHANGED As Integer = &H311
        Shared WM_WININICHANGE As UInteger = &H1A
        Shared WM_SETTINGCHANGE As UInteger = WM_WININICHANGE
        Shared HWND_MESSAGE As Int32 = -&H3
        Shared HWND_BROADCAST As IntPtr = New IntPtr(&HFFFF)
        Shared MSG_TIMEOUT As Integer = 5000
        Shared RESULT As UIntPtr

        <Flags>
        Enum AnimateWindowFlags
            AW_HOR_POSITIVE = &H0
            AW_HOR_NEGATIVE = &H2
            AW_VER_POSITIVE = &H4
            AW_VER_NEGATIVE = &H8
            AW_CENTER = &H10
            AW_HIDE = &H10000
            AW_ACTIVATE = &H20000
            AW_SLIDE = &H40000
            AW_BLEND = &H80000
        End Enum

    End Class

    Public Class Kernel32
        <DllImport("kernel32.dll", SetLastError:=True)>
        Public Shared Function LoadLibraryEx(ByVal lpFileName As String, ByVal hFile As IntPtr, ByVal dwFlags As UInteger) As IntPtr
        End Function
        <DllImport("Kernel32.dll", EntryPoint:="LockResource")>
        Public Shared Function LockResource(ByVal hGlobal As IntPtr) As IntPtr
        End Function
        <DllImport("kernel32.dll")>
        Public Shared Function FindResource(ByVal hModule As IntPtr, ByVal lpID As Integer, ByVal lpType As String) As IntPtr
        End Function
        <DllImport("kernel32.dll", SetLastError:=True)>
        Public Shared Function LoadResource(ByVal hModule As IntPtr, ByVal hResInfo As IntPtr) As IntPtr
        End Function
        <DllImport("kernel32.dll", SetLastError:=True)>
        Public Shared Function SizeofResource(ByVal hModule As IntPtr, ByVal hResInfo As IntPtr) As UInteger
        End Function
    End Class


End Namespace
