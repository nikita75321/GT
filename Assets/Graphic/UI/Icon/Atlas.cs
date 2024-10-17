using UnityEngine;
using UnityEngine.U2D;

public class Atlas : MonoBehaviour
{
    [SerializeField] private SpriteAtlas atlas;
    //[SerializeField] private string spriteName;

    void Start()
    {
        atlas.GetSprite("Heart");
        Debug.Log("1");
        Debug.Log(atlas);
        Debug.Log(atlas.GetSprite("Heart"));
    }
}
