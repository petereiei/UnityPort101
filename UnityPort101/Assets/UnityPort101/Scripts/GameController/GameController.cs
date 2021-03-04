using UnityEngine;

public class GameController : MonoSingleton<GameController>
{
    private const string PLAYER_PATH = "Prefabs/Characters/Player";
    private GameObject area;


    public Transform playerPoint;

    

    private void Awake()
    {
        if (area == null)
        {
            area = new GameObject();
            area.name = "AreaCharacters";
        }
    }

    private void Start()
    {
        GetPlayer();
    }

    private void GetPlayer()
    {
        GameObject player = Instantiate(Resources.Load<GameObject>(PLAYER_PATH));
        player.transform.SetParent(area.transform);
        player.transform.position = playerPoint.position;
        player.transform.localScale = Vector3.one;
    }
}
