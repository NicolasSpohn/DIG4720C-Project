using Melanchall.DryWetMidi.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    //reads notes from midi files.
    //Lane 1=A 
    //Lane 2=G 
    //Lane 3=F
    //Lane 4=E
    public Melanchall.DryWetMidi.MusicTheory.NoteName noteRestriction;

    //put blank prefab here
    public GameObject notePrefab;
    List<Note> notes = new List<Note>();
    public List<double> timeStamps = new List<double>();

    // keeps tracks of timestamps spawned and notes spawned 
    int spawnIndex = 0;
    int inputIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetTimeStamps(Melanchall.DryWetMidi.Interaction.Note[] array)
    {
        // checks which note (of 4) is played from midi at specific point. Communicates to SM to trigger asset at certain interval.
        foreach (var note in array)
        {
            // filters notes
            if (note.NoteName == noteRestriction)
            {
                var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, SongManager.midiFile.GetTempoMap());
                timeStamps.Add((double)metricTimeSpan.Minutes * 60f + metricTimeSpan.Seconds + (double)metricTimeSpan.Milliseconds / 1000f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnIndex < timeStamps.Count)
        {
            if (SongManager.GetAudioSourceTime() >= timeStamps[spawnIndex] - SongManager.Instance.noteTime)
            {
                var note = Instantiate(notePrefab, transform);
                notes.Add(note.GetComponent<Note>());
                note.GetComponent<Note>().assignedTime = (float)timeStamps[spawnIndex];
                spawnIndex++;
            }
        }

        if (inputIndex < timeStamps.Count)
        {
            double timeStamp = timeStamps[inputIndex];
            double marginOfError = SongManager.Instance.marginOfError;
            double audioTime = SongManager.GetAudioSourceTime() - (SongManager.Instance.inputDelayInMilliseconds / 1000.0);

            // detects if player is touching screen
            if (Input.touchCount > 0)
            {
                // gets SPECIFIC touch location
                Touch t = Input.GetTouch(0);

                Vector2 touchpos = Camera.main.ScreenToWorldPoint(t.position);

                // reads if the player's touching location is on one of the buttons/lanes.
                if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchpos))
                {
                    if (Math.Abs(audioTime - timeStamp) < marginOfError)
                    {
                        Hit();
                        Destroy(notes[inputIndex].gameObject);
                        inputIndex++;
                    }
                }
            }
            if (timeStamp + marginOfError <= audioTime)
            {
                 Miss();
                 inputIndex++;
            }
                
        }
    }

    private void Hit()
    {
        ScoreManager.Hit();
    }

    private void Miss()
    {
        ScoreManager.Miss();
    }
}
