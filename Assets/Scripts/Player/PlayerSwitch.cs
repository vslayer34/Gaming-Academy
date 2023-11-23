using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the user input tracker")]
    private SO_InputTracker _InputTracker;


    [SerializeField, Tooltip("List of the player characters")]
    private Transform[] _characters;

    /// <summary>
    /// Count of the playable characters list
    /// </summary>
    private int _charactersListCount;

    //---------------------------------------------------------------------------------------------


    private void Start()
    {
        _charactersListCount = _characters.Length;
        Debug.Log(_charactersListCount);
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

    
    private void GetNextCharacter()
    {
        Debug.Log("Next Character pressed");
    }


    private void GetPreviouseCharacter()
    {
        Debug.Log("Previous Character pressed");
    }
}
