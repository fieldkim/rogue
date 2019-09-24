using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
	public Tile tile;
	public Tile[,] tiles;
	public Vector2Int size;
	public Map (int width, int height)
	{
		tiles = new Tile[width, height];
	}

	public Tile SetTile(Vector2Int tilePos, Tile.TileMaterial tileMaterial, Tile.TileType tileType)
	{
		tiles[tilePos.x, tilePos.y] = Instantiate(tile);
		tiles[tilePos.x, tilePos.y].Pos = tilePos;
		tiles[tilePos.x, tilePos.y].tileMaterial = tileMaterial;
		tiles[tilePos.x, tilePos.y].tileType = tileType;

		// 이웃 구역을 검색하여 타일이 있었다면 해당 타일과 스스로의 이웃에 서로의 레퍼런스를 넣는다.
		tiles[tilePos.x, tilePos.y].AdjacentTiles = new Tile[System.Enum.GetValues(typeof(Tile.Dir)).Cast<int>().Max()];

		// upLeft
		if (tilePos.x - 1 > -1 && tilePos.y - 1 > -1 && tiles[tilePos.x - 1, tilePos.y - 1])
		{
			tiles[tilePos.x, tilePos.y].AdjacentTiles[(int)Tile.Dir.upLeft] = tiles[tilePos.x - 1, tilePos.y - 1];
			tiles[tilePos.x - 1, tilePos.y - 1].AdjacentTiles[(int)Tile.Dir.downRight] = tiles[tilePos.x, tilePos.y];
		}
		// left
		if (tilePos.x - 1 > -1 && tiles[tilePos.x - 1, tilePos.y])
		{
			tiles[tilePos.x, tilePos.y].AdjacentTiles[(int)Tile.Dir.left] = tiles[tilePos.x - 1, tilePos.y];
			tiles[tilePos.x - 1, tilePos.y].AdjacentTiles[(int)Tile.Dir.right] = tiles[tilePos.x, tilePos.y];
		}
		// downLeft
		if (tilePos.x - 1 > -1 && tilePos.y + 1 < size.y && tiles[tilePos.x - 1, tilePos.y + 1])
		{
			tiles[tilePos.x, tilePos.y].AdjacentTiles[(int)Tile.Dir.downLeft] = tiles[tilePos.x - 1, tilePos.y + 1];
			tiles[tilePos.x - 1, tilePos.y + 1].AdjacentTiles[(int)Tile.Dir.upRight] = tiles[tilePos.x, tilePos.y];
		}
		// up
		if (tilePos.y - 1 > -1 && tiles[tilePos.x, tilePos.y - 1])
		{
			tiles[tilePos.x, tilePos.y].AdjacentTiles[(int)Tile.Dir.up] = tiles[tilePos.x, tilePos.y - 1];
			tiles[tilePos.x, tilePos.y - 1].AdjacentTiles[(int)Tile.Dir.down] = tiles[tilePos.x, tilePos.y];
		}
		// down
		if (tilePos.y + 1 < size.y && tiles[tilePos.x, tilePos.y + 1])
		{
			tiles[tilePos.x, tilePos.y].AdjacentTiles[(int)Tile.Dir.down] = tiles[tilePos.x, tilePos.y + 1];
			tiles[tilePos.x, tilePos.y + 1].AdjacentTiles[(int)Tile.Dir.up] = tiles[tilePos.x, tilePos.y];
		}
		// upRight
		if (tilePos.x + 1 > size.x && tilePos.y + 1 > size.y && tiles[tilePos.x + 1, tilePos.y - 1])
		{
			tiles[tilePos.x, tilePos.y].AdjacentTiles[(int)Tile.Dir.upRight] = tiles[tilePos.x - 1, tilePos.y - 1];
			tiles[tilePos.x - 1, tilePos.y - 1].AdjacentTiles[(int)Tile.Dir.downLeft] = tiles[tilePos.x, tilePos.y];
		}
		// right
		if (tilePos.x + 1 > size.x && tiles[tilePos.x + 1, tilePos.y])
		{
			tiles[tilePos.x, tilePos.y].AdjacentTiles[(int)Tile.Dir.right] = tiles[tilePos.x + 1, tilePos.y];
			tiles[tilePos.x + 1, tilePos.y].AdjacentTiles[(int)Tile.Dir.left] = tiles[tilePos.x, tilePos.y];
		}
		// downRight
		if (tilePos.x + 1 > size.x && tilePos.y - 1 > -1 && tiles[tilePos.x + 1, tilePos.y + 1])
		{
			tiles[tilePos.x, tilePos.y].AdjacentTiles[(int)Tile.Dir.downRight] = tiles[tilePos.x + 1, tilePos.y + 1];
			tiles[tilePos.x + 1, tilePos.y + 1].AdjacentTiles[(int)Tile.Dir.upLeft] = tiles[tilePos.x, tilePos.y];
		}

		return tiles[tilePos.x, tilePos.y];
	}



}
