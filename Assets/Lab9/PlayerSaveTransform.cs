using UnityEngine;

[System.Serializable]
public class PlayerSaveTransform
{
    public float x, y;

    public PlayerSaveTransform(Vector2 position)
    {
        x = position.x;
        y = position.y;
    }

    public Vector2 ToVector2()
    {
        return new Vector2(x, y);
    }
}
