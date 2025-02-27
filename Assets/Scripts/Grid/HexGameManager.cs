using UnityEngine;
using System.Collections.Generic;

public class HexGameManager : MonoBehaviour
{
    private Camera mainCamera;
<<<<<<< Updated upstream
    [SerializeField]
    private HexGrid grid;

    public static HexGameManager Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
=======
    private HexGrid hexGrid;
    private List<HexTile> highlightedTiles = new List<HexTile>();
>>>>>>> Stashed changes

    void Start()
    {
        mainCamera = Camera.main;
<<<<<<< Updated upstream
        grid.CreateTerraMallaProve();
=======
        hexGrid = FindAnyObjectByType<HexGrid>(); // Get reference to HexGrid
>>>>>>> Stashed changes
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                HexTile clickedTile = hit.collider.GetComponent<HexTile>();
                if (clickedTile != null)
                {
<<<<<<< Updated upstream
                    grid.ClearHexGrid();
                    clickedTile.SetState(HexState.Ants); // Debug: Capture for Ants
=======
                    ClearHighlights(); // Clear previous highlights
                    ShowHexLines(clickedTile);
>>>>>>> Stashed changes
                }
            }
        }
    }

    private void ShowHexLines(HexTile centerTile)
    {
        Vector2Int[] hexDirections = {
            new Vector2Int(1, 0), new Vector2Int(0, 1), new Vector2Int(-1, 1),
            new Vector2Int(-1, 0), new Vector2Int(0, -1), new Vector2Int(1, -1)
        };

        foreach (Vector2Int direction in hexDirections)
        {
            List<HexTile> lineTiles = hexGrid.GetHexLine(centerTile.axialCoords, direction);
            for (int i = 0; i < lineTiles.Count; i++)
            {
                if (i == lineTiles.Count - 1)
                {
                    lineTiles[i].HighlightTile(Color.red); // Last tile before an obstacle
                }
                else
                {
                    lineTiles[i].HighlightTile(Color.green); // Normal path
                }
                highlightedTiles.Add(lineTiles[i]);
            }
        }
    }

    private void ClearHighlights()
    {
        foreach (HexTile tile in highlightedTiles)
        {
            tile.ResetTileColor();
        }
        highlightedTiles.Clear();
    }
}
