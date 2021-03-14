using UnityEngine;

public class GameController : MonoSingleton<GameController>
{
    private const string PLAYER_PATH = "Prefabs/Characters/Bases/Player/Player";
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
        PlayerCharacter player = Instantiate(Resources.Load<PlayerCharacter>(PLAYER_PATH));
        player.transform.SetParent(area.transform);
        player.transform.position = playerPoint.position;
        player.transform.localScale = Vector3.one;

        player.Init();

        
    }
}
