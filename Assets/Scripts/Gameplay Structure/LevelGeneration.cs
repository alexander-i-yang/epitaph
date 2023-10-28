using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using NavMeshPlus.Components;
using UnityEngine.AI;
public class LevelGeneration : MonoBehaviour
{
    private GoLAutomaton automaton;
    private EnemyPlacement enemyPlacement;
    private int[,] terrain;
    [SerializeField] private Tilemap topMap;
    [SerializeField] private Tilemap baseMap;
    [SerializeField] private Tile obstacleTile;
    [SerializeField] private NavMeshSurface surface2D;
    [SerializeField] private int bufferSize;
    private int width;
    private int height;
    private Vector3Int origin;

    // Start is called before the first frame update
    public void Start()
    {
        automaton = gameObject.GetComponent<GoLAutomaton>();
        enemyPlacement = gameObject.GetComponent<EnemyPlacement>();
        origin = baseMap.origin;
        width = baseMap.size.x;
        height = baseMap.size.y;
        terrain = automaton.Simulate(width, height, bufferSize);
        RenderMap();
        surface2D.BuildNavMeshAsync();
    }

    public void PlaceEnemies() {
        enemyPlacement.PlaceEnemies(terrain, bufferSize);
    }

    void RenderMap() {
        topMap.ClearAllTiles();
        topMap.gameObject.GetComponent<RenderObstacleMap>().Render(terrain, baseMap.origin);
        baseMap.gameObject.GetComponent<RenderBaseMap>().Render(terrain, baseMap.origin);
        topMap.GetComponent<Collider2D>().enabled = false;
        topMap.GetComponent<Collider2D>().enabled = true;

    }
}
