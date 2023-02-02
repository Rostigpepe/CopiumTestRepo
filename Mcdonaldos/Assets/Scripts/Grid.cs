using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class Cell
{
	Vector3 worldPos;
	bool walkable;
	int gridX;
	int gridY;

	public Cell(Vector3 worldPos, bool walkable, int gridX, int gridY)
	{
		this.worldPos = worldPos;
		this.walkable = walkable;
		this.gridX = gridX;
		this.gridY = gridY;
	}

	public Vector3 WorldPos { get => worldPos; set => worldPos = value; }
	public bool Walkable { get => walkable; set => walkable = value; }
	public int GridX { get => gridX; set => gridX = value; }
	public int GridY { get => gridY; set => gridY = value; }
}

public class Grid : MonoBehaviour
{
	#region Singleton

	[HideInInspector] public static Grid Instance;

	private void OnEnable()
	{
		Instance = this;
	}
	#endregion Singleton

	public Transform from;
	public Transform to;
	Cell[] path;

	[SerializeField] private LayerMask unwalkableMask;
	[SerializeField] private Vector2 gridWorldSize;
	[SerializeField] private float cellRadius;

	private Cell[,] grid;
	private float cellDiameter;
	private int gridSizeX, gridSizeY;

	private void CreateGrid()
	{
		cellDiameter = cellRadius * 2;
		gridSizeX = Mathf.RoundToInt(gridWorldSize.x / cellDiameter);
		gridSizeY = Mathf.RoundToInt(gridWorldSize.y / cellDiameter);

		grid = new Cell[gridSizeY, gridSizeX];
		Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.y / 2;

		for (int y = 0; y < gridSizeY; y++)
		{
			for (int x = 0; x < gridSizeX; x++)
			{
				Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * cellDiameter + cellRadius) + Vector3.forward * (y * cellDiameter + cellRadius);
				bool walkable = !(Physics.CheckSphere(worldPoint, cellRadius, unwalkableMask));
				grid[y, x] = new Cell(worldPoint, walkable, x, y);
			}
		}
	}

	public Cell GetCellFromWorldPoint(Vector3 worldPosition)
	{
		float percentX = (worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x;
		float percentY = (worldPosition.z + gridWorldSize.y / 2) / gridWorldSize.y;
		percentX = Mathf.Clamp01(percentX);
		percentY = Mathf.Clamp01(percentY);

		int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
		int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);
		return grid[y, x];
	}

	private void Start()
	{
		CreateGrid();
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y));

		if (grid != null)
		{
			foreach (Cell cell in grid)
			{
				Gizmos.color = (cell.Walkable) ? Color.white : Color.red;
				Gizmos.DrawCube(cell.WorldPos, Vector3.one * (cellDiameter - 0.1f));
			}
		}
	}
}
