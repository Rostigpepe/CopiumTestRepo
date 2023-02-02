using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarNode
{
	public float GCost;
	public float HCost;
	public float FCost;
	public int XIndex;
	public int YIndex;
	public AStarNode Parent;

	public AStarNode(float gCost, float hCost, int xIndex, int yIndex, AStarNode parent = null)
	{
		GCost = gCost;
		HCost = hCost;
		FCost = gCost + hCost;
		XIndex = xIndex;
		YIndex = yIndex;
		Parent = parent;
	}

	public AStarNode(int xIndex, int yIndex, AStarNode parent = null)
	{
		XIndex = xIndex;
		YIndex = yIndex;
		Parent = parent;
	}

	public void SetParrent(AStarNode parent)
	{
		Parent = parent;
	}

	public void SetCosts(float gCost, float hCost)
	{
		GCost = gCost;
		HCost = hCost;
		FCost = gCost + hCost;
	}

	public override int GetHashCode()
	{
		return XIndex.GetHashCode() ^ YIndex.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		//Check for null and compare run-time types.
		if ((obj == null) || !this.GetType().Equals(obj.GetType()))
		{
			return false;
		}
		else
		{
			AStarNode node = (AStarNode)obj;
			return (this.XIndex == node.XIndex) && (this.YIndex == node.YIndex);
		}
	}
}

public class AStar <T>
{
	private static bool IsInBounds(int x, int y, float[,] weightMap)
	{
		return x >= 0 && x < weightMap.GetLength(1) && y >= 0 && y < weightMap.GetLength(1);
	}

	private static AStarNode[] GetNeighbours(AStarNode aStarNode, float[,] weightMap)
	{
		List<AStarNode> neighbours = new List<AStarNode>();

		for (int y = -1; y <= 1; y++)
		{
			for (int x = -1; x <= 1; x++)
			{
				if(x == 0 && y == 0)
				{
					continue;
				}

				if(!IsInBounds(aStarNode.XIndex + x, aStarNode.YIndex + y, weightMap))
				{
					continue;
				}

				float neighbourWeight = weightMap[aStarNode.XIndex + x, aStarNode.YIndex + y];

				if(neighbourWeight != -1)
				{
					AStarNode newNeighbour = new AStarNode(aStarNode.XIndex + x, aStarNode.YIndex + y, aStarNode);
					if(Mathf.Abs(x) == 1 && Mathf.Abs(y) == 1)
					{
						neighbourWeight *= Mathf.Sqrt(2);
					}

					newNeighbour.GCost = aStarNode.GCost + neighbourWeight;
					newNeighbour.FCost = newNeighbour.GCost + newNeighbour.HCost;

					neighbours.Add(newNeighbour);
				}
			}
		}

		return neighbours.ToArray();
	}

	private static T[] BacktracePath(AStarNode goal, T[,] objectMap)
	{
		List<T> path = new List<T>();
		AStarNode current = goal;

		while(current != null)
		{
			path.Add(objectMap[current.XIndex, current.YIndex]);
			current = current.Parent;
		}

		path.Reverse();
		return path.ToArray();
	}

	public static T[] PathFind(T[,] objectMap, float[,] weightMap, int startX, int startY, int goalX, int goalY)
	{
		PriorityQueue<AStarNode> open = new PriorityQueue<AStarNode>();
		List<AStarNode> closed = new List<AStarNode>();

		AStarNode startNode = new AStarNode(0, 0, startX, startY);
		open.Insert(0, startNode);

		List<T> lookedAt = new List<T>();

		while (!open.IsEmpty)
		{
			AStarNode current = open.RemoveMax();
			lookedAt.Add(objectMap[current.XIndex, current.YIndex]);

			AStarNode[] neighbours = GetNeighbours(current, weightMap);
			//Debug.Log($"open: {open.Size}, Neighbours: {neighbours.Length}");

			foreach (AStarNode neighbour in neighbours)
			{
				if(neighbour.XIndex == goalX && neighbour.YIndex == goalY)
				{
					return lookedAt.ToArray();
					return BacktracePath(neighbour, objectMap);
				}

				neighbour.HCost = Vector2.Distance(new Vector2(goalX, goalY), new Vector2(neighbour.XIndex, neighbour.YIndex));
				neighbour.FCost = neighbour.HCost + neighbour.GCost;

				int dupIndex = -1;

				for (int i = 0; i < closed.Count; i++)
				{
					if (closed[i].XIndex == neighbour.XIndex && closed[i].YIndex == neighbour.YIndex)
					{
						dupIndex = i;
						Debug.Log("Earth is flat");
						break;
					}
				}

				if(dupIndex != -1)
				{
					Debug.Log("AHHHH");
					continue;
					if (closed[dupIndex].FCost > neighbour.FCost)
					{
						closed[dupIndex] = neighbour;
						Debug.Log("we gaming");
					}
					else
					{
						continue;
					}
				}
				else
				{
					open.Insert(neighbour.FCost, neighbour);
				}
			}

			closed.Add(current);
		}

		return lookedAt.ToArray();
		return new T[0];
	}
}
