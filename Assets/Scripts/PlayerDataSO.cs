using UnityEngine;

public class PlayerDataSO : ScriptableObject
{
    public const string PLAYER_MODE_SAVE = "P";
    public enum PLAYER_MODE
    {
        ONE =1, 
        TWO =2,
    }

    public PLAYER_MODE mode;
}
