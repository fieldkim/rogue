using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
	public enum TileMaterial
	{
		dirt,
		rock,
	}
	public TileMaterial tileMaterial;

	public enum TileType
	{
		blank,
		wall,
	}
	public TileType tileType;

	public enum Dir
	{
		none,
		upLeft,
		up,
		upRight,
		left,
		right,
		downLeft,
		down,
		downRight,
	}

	private Vector2Int pos;
	public Vector2Int Pos {
		get;
		set;
	}
	private Tile[] adjacentTiles;
	public Tile[] AdjacentTiles	{
		get;
		set;
	}

	// 자신의 그래픽 데이터 기본형. 각각의 타일이 자신의 게임 오브젝트를 오버라이드 하여 덮어 쓸 예정
	private GameObject shape;
	public GameObject Shape {
		get;
		set;
	}

	//

}
