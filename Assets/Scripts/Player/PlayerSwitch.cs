using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the user input tracker")]
    private SO_InputTracker _InputTracker;


    [SerializeField, Tooltip("List of the player characters")]
    private List<Transform> _characters;

    /// <summary>
    /// Count of the playable characters list
    /// </summary>
    private int _charactersListCount;

    private int _currentSelectedCharacter;

    //---------------------------------------------------------------------------------------------


    private void Start()
    {
        _charactersListCount = _characters.Count;
    }
    
    private void OnEnable()
    {
        _InputTracker.OnNextCharacterPressed += GetNextCharacter;
        _InputTracker.OnPreviousCharacterPressed += GetPreviouseCharacter;
    }

    private void OnDisable()
    {
        _InputTracker.OnNextCharacterPressed -= GetNextCharacter;
        _InputTracker.OnPreviousCharacterPressed -= GetPreviouseCharacter;
    }

    
    //---------------------------------------------------------------------------------------------

    /// <summary>
    /// activate the next character and disable the current one
    /// if the last character is selected it overflow to the first one
    /// </summary>
    private void GetNextCharacter()
    {
        Debug.Log("Next Character pressed");
        _currentSelectedCharacter = GetCurrentCharacter();
        
        Debug.Log($"current character index: {_currentSelectedCharacter}");

        // got to the head of the list when in last index
        int nextCharacter = (_currentSelectedCharacter == _charactersListCount - 1) ? 0 : _currentSelectedCharacter + 1;
        Debug.Log($"next character: {nextCharacter}");

        SwapCharacters(_currentSelectedCharacter, nextCharacter);
    }

    /// <summary>
    /// activate the previouse character and disable the current one
    /// if the first character is selected it overflow to the last one 
    /// </summary>
    private void GetPreviouseCharacter()
    {
        Debug.Log("Previous Character pressed");
        _currentSelectedCharacter = GetCurrentCharacter();

        Debug.Log($"current character index: {_currentSelectedCharacter}");

        // got to the back of the list when in first index
        int previousCharacter = (_currentSelectedCharacter == 0) ? _charactersListCount - 1 : _currentSelectedCharacter - 1;
        Debug.Log($"previous character: {previousCharacter}");

        SwapCharacters(_currentSelectedCharacter, previousCharacter);
    }


    /// <summary>
    /// Find the currently selected character in the characters list
    /// </summary>
    /// <returns>The index of the active character</returns>
    private int GetCurrentCharacter() => _currentSelectedCharacter = _characters.IndexOf(_characters.Single(x => x.gameObject.activeInHierarchy));

    /// <summary>
    /// Swap the characters disable the old one and enable the next one
    /// and set the correct location
    /// </summary>
    /// <param name="currentSelection">The currently active character index</param>
    /// <param name="nextSelection">The next selected character index</param>
    private void SwapCharacters(int currentSelection, int nextSelection)
    {
        transform.GetChild(currentSelection).gameObject.SetActive(false);
        
        transform.GetChild(nextSelection).position = transform.GetChild(currentSelection).position;
        transform.GetChild(nextSelection).gameObject.SetActive(true);
    }
}
