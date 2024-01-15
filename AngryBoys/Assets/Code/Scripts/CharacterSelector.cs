using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public GameObject character1;
    public GameObject character2;
    public GameObject character1Border;
    public GameObject character2Border;
    private int selectedCharacter = 1;

    void Start()
    {
        HighlightCharacter(selectedCharacter);
    }

    public void SelectCharacter(int characterID)
    {
        selectedCharacter = characterID;
        GameManager.SelectedCharacterID = characterID;

        HighlightCharacter(selectedCharacter);

    }

    private void HighlightCharacter(int characterID)
        {
            character1Border.SetActive(false);
            character2Border.SetActive(false);
        
        if (characterID == 1)
        {
            character1Border.SetActive(true);
        }
        else {
            character2Border.SetActive(true);
        }
    }
    
}