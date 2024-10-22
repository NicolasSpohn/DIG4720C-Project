using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.IO;
using UnityEngine.Networking;
using System;


public class SongManager : MonoBehaviour
{
    public static SongManager Instance;
    public AudioSource audioSource;

    // determine how many lanes are going to be used publically
    public Lane[] lanes;

    // time until song starts
    public float songDelayInSeconds;

    // account for input delay
    public int inputDelayInMilliseconds;
    public double marginOfError; // in seconds
    public string fileLocation;

    // time the note is on screen
    public float noteTime;

    // Where the note spawns. Offscreen.
    public float noteSpawnY;

    // moment where the note can be tapped
    public float noteTapY;

    // when the note despawns using math, wow. Despawned off screen
    public float noteDespawnY
    {
        get
        {
            return noteTapY = (noteSpawnY - noteTapY);
        }
    }

    // where the MIDI file loads.
    public static MidiFile midiFile;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        ReadFromFile();
    }

    private void ReadFromFile()
    {
        midiFile = MidiFile.Read(Application.streamingAssetsPath + "/" + fileLocation);
        GetDataFromMidi();
    }

    public void GetDataFromMidi()
    {
        var notes = midiFile.GetNotes();
        var array = new Melanchall.DryWetMidi.Interaction.Note[notes.Count];
        notes.CopyTo(array, 0);

        //Reads lane array to set notes to them.
        foreach (var lane in lanes) lane.SetTimeStamps(array);

        Invoke(nameof(StartSong), songDelayInSeconds);
    }

    public void StartSong()
    {
        audioSource.Play();
    }

    public static double GetAudioSourceTime()
    {
        return (double)Instance.audioSource.timeSamples / Instance.audioSource.clip.frequency;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
