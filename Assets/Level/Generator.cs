using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator
{
	Map map;

	public void GenerateMap(int width, int height, int level, int randomSeed = 0)
	{
		// randomSeed를 넣으면 random. 없으면 랜덤 생성.
		if (randomSeed == 0)
		{
			randomSeed = Random.Range(0, int.MaxValue);
		}
		Random.InitState(randomSeed);

		map = new Map(width, height);

		// level에 따라 다른 방식으로 만들어질 필요가 있다.
		switch (level)
		{
			default :
				GenerateDefaultMap(map, width, height, level, randomSeed);
			break;
		}


	}



	// 가장 기본형이 되는 맵
	public void GenerateDefaultMap(Map map, int width, int height, int level, int randomSeed)
	{
		// 전체 맵에 대해 가용면적 비율이 채워질 때 까지 반복한다.
		float minPortion = 0.5f;
		float portion = 0f;
		while (portion < minPortion)
		{
			Debug.Log(portion);
			// 시드 포지션 지점선택
			int roomSeedPosX = Random.Range(0, width);
			int roomSeedPosY = Random.Range(0, height);
			Tile seedTile = null;

			// 시드 타일
			while (seedTile != null)
			{
				roomSeedPosX = Random.Range(0, width);
				roomSeedPosY = Random.Range(0, height);

				if (map.tiles[roomSeedPosX, roomSeedPosY] == null)
				{
					
					//map.SetTile(new Vector2Int(roomSeedPosX, roomSeedPosY), Tile.TileMaterial)
				}
			}

		}

		// 
	}
}
