using UnityEngine;

[CreateAssetMenu (menuName = "SO/Agent/Train/TrainData")]
public class TrainData : ScriptableObject
{
    public int Damage;
    public float CoolTime;
    public GameObject Visual;
    public RenderTexture Texture;
    public string Name;
    public string Info;
}
