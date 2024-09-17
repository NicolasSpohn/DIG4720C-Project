using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject notePrefab;
    [SerializeField] private float noteSpawnTimer = 2f;
    [SerializeField] private int howManyNotes;

    void Start()
    {
        StartCoroutine(SpawnNote());
    }

    // Will spawn 10 enemy prefabs every 7 seconds
    private IEnumerator SpawnNote()
    {
        for(int i = 0; i < howManyNotes; i++)
        {
            WaitForSeconds wait = new WaitForSeconds(noteSpawnTimer);

            yield return new WaitForSeconds(noteSpawnTimer);
        
            Instantiate(notePrefab, transform.position, Quaternion.identity);

            if (i == (howManyNotes - 1))
            {
                Destroy(gameObject);
            }
        }
    }
}
