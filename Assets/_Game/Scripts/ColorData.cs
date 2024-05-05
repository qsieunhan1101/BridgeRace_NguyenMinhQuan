using UnityEngine;

public enum ColorType
{
    None = 0,
    Red = 1,
    Green = 2,
    Blue = 3,
    Pink = 4,
    Puple = 5
}
[CreateAssetMenu(menuName = "ColorType")]
public class ColorData : ScriptableObject
{
    [SerializeField] private Material[] materials;


    public Material GetMaterial(ColorType colorType)
    {
        return materials[(int)(colorType)];
    }
}


