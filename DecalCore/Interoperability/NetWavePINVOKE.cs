using System;
using System.Runtime.InteropServices;

namespace DecalCore.Interoperability;

internal static class NetWavePINVOKE {
    [DllImport("NetWave.dll")]
    public static extern int IsMediaSessionAvailable();
    
    [DllImport("NetWave.dll")]
    public static extern int IsMediaSessionPlaying();

    [DllImport("NetWave.dll")]
    public static extern IntPtr GetMediaSessionTitle();
    
    [DllImport("NetWave.dll")]
    public static extern IntPtr GetMediaSessionArtist();

    [DllImport("NetWave.dll")]
    public static extern IntPtr GetMediaSessionAlbum();

    [DllImport("NetWave.dll")]
    public static extern long GetMediaSessionStartTime();

    [DllImport("NetWave.dll")]
    public static extern long GetMediaSessionPosition();
    
    [DllImport("NetWave.dll")]
    public static extern long GetMediaSessionEndTime();

    [DllImport("NetWave.dll")]
    public static extern void PlayMediaSession();
    
    [DllImport("NetWave.dll")]
    public static extern void PauseMediaSession();
    
    [DllImport("NetWave.dll")]
    public static extern void NextMediaSession();
    
    [DllImport("NetWave.dll")]
    public static extern void PreviousMediaSession();
}