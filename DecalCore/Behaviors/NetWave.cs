using System;
using System.Runtime.InteropServices;
using DecalCore.Extensions;
using DecalCore.Interoperability;
using DecalCore.Tools;
using UnityEngine;

namespace DecalCore.Behaviors;

// TODO: Download the 'NetWave.dll' at runtime and put it in the Gorilla Tag Root Folder.
// TODO: If NetWave version is outdated, replace the DLL in the Gorilla Tag Root Folder.
public class NetWave : MonoBehaviour {
    public static NetWave Singleton { get; private set; }
    private bool _initialized;
    
    private void Start() {
        if (_initialized || Singleton != null && Singleton != this) {
            Logging.Info("Failed to start initialize NetWave");
            return;
        }
        Singleton = this;
        _initialized = true;
        
        Logging.Info("Successfully ended initializing NetWave");
    }

    #region NetWave P/INVOKE
    
    public bool IsMediaSessionAvailable => NetWavePINVOKE.IsMediaSessionAvailable() == 1;
    public bool IsMediaSessionPlaying => NetWavePINVOKE.IsMediaSessionPlaying() == 1;

    public string CurrentMediaSessionTitle => Marshal.PtrToStringAnsi(NetWavePINVOKE.GetMediaSessionTitle());
    public string CurrentMediaSessionArtist => Marshal.PtrToStringAnsi(NetWavePINVOKE.GetMediaSessionArtist());
    public string CurrentMediaSessionAlbum => Marshal.PtrToStringAnsi(NetWavePINVOKE.GetMediaSessionAlbum());
    
    public TimeSpan CurrentMediaSessionStartTime => TimeSpan.FromTicks(NetWavePINVOKE.GetMediaSessionStartTime());
    public string FormattedCurrentMediaSessionStartTime => CurrentMediaSessionStartTime.FormatToString();
    
    public TimeSpan CurrentMediaSessionPosition => TimeSpan.FromTicks(NetWavePINVOKE.GetMediaSessionPosition());
    public string FormattedCurrentMediaSessionPosition => CurrentMediaSessionPosition.FormatToString();
    
    public TimeSpan CurrentMediaSessionEndTime => TimeSpan.FromTicks(NetWavePINVOKE.GetMediaSessionEndTime());
    public string FormattedCurrentMediaSessionEndTime => CurrentMediaSessionEndTime.FormatToString();

    public void PlayMediaSession() => NetWavePINVOKE.PlayMediaSession();

    public void PauseMediaSession() => NetWavePINVOKE.PauseMediaSession();

    public void NextMediaSession() => NetWavePINVOKE.NextMediaSession();

    public void PreviousMediaSession() => NetWavePINVOKE.PreviousMediaSession();
    
    #endregion
}