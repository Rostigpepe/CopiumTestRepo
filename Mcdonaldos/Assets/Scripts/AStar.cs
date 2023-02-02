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

	public AStarNode(int xIndex, int yIndex)
	{
		XIndex = xIndex;
		YIndex = yIndex;
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

	/*public T PathFind(T[,] objectMap, float[,] weightMap)
	{
		if(objectMap.GetLength(0) != weightMap.GetLength(0))
		{

		}

		if(objectMap.GetLength(1) != weightMap.GetLength(1))
		{
			
		}

		List<AStarNode> open = new List<AStarNode>();
		List<AStarNode> closed = new List<AStarNode>();

		
	}*/
}
