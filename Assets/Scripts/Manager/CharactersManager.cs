using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersManager : MonoBehaviour
{
    public List<GameObject> spawnedCharacters = new();
    public static CharactersManager Instance;
    public int currIndex = 0;
    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            spawnedCharacters[currIndex].GetComponent<Movement>().enabled = false;
            currIndex++;
            if (currIndex == spawnedCharacters.Count)
            {
                currIndex = 0;
            }
            spawnedCharacters[currIndex].GetComponent<Movement>().enabled = true;
        }
    }
}
