using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class WaveGen : MonoBehaviour
{
	[SerializeField]
	WaveManager waveScript;  //manager reference

	// Enemy Prefabs
	public GameObject peasantPrefab;

	public GameObject knightPrefab;

	public GameObject knight2Prefab;

	public GameObject horseKnightPrefab;

	public GameObject horseRomePrefab;

	public GameObject dragonPrefab;


	// Paths
	public PathManager Path1;

	public PathManager Path2; 

	public PathManager Path3; 

	public PathManager Path4; 

	public List<PathManager> Paths;

	// Enemies
	[HideInInspector]
	public EnemyGroup peasant;

	[HideInInspector]
	public EnemyGroup knight;

	[HideInInspector]
	public EnemyGroup knight2;

	[HideInInspector]
	public EnemyGroup horseKnight;

	[HideInInspector]
	public EnemyGroup horseRome;

	[HideInInspector]
	public EnemyGroup dragon;
	
	void Init()
	{

	}
	
	
	void Start()
	{
		MusterForBattle ();
		GenerateAllWaves();
	}

	public void GenerateAllWaves()
	{
		GameObject wavesGO = GameObject.Find("Wave Manager");
		waveScript = wavesGO.GetComponent<WaveManager>();	
		
		for (int waveCount = 1; waveCount < 21; waveCount++) 
		{
			//create new wave option
			WaveOptions newWave = new WaveOptions();

			CreateArmy(waveCount,dragon,newWave);
			
			waveScript.options.Add(newWave);
		}

	}

	public void GenerateWave(EnemyGroup e, WaveOptions newWave)
	{
		//initialize first row / creep of the new wave
		newWave.enemyPrefab.Add(e.prefab);
		newWave.enemyCount.Add(e.count);
		newWave.path.Add(e.path);
		newWave.enemyHP.Add(e.HpOverride);
		newWave.enemySH.Add(e.ShieldOverride);
		newWave.startDelayMin.Add(UnityEngine.Random.Range(e.startDelayMin.min,e.startDelayMin.max));
		newWave.startDelayMax.Add(UnityEngine.Random.Range(e.startDelayMax.min,e.startDelayMax.max));
		newWave.delayBetweenMin.Add(UnityEngine.Random.Range(e.betweenDelayMin.min,e.betweenDelayMin.max));
		newWave.delayBetweenMax.Add(UnityEngine.Random.Range(e.betweenDelayMax.min,e.betweenDelayMax.max));
	}

	public void MusterForBattle()
	{
		Paths = new List<PathManager>();

		Paths.Add (Path1);
		Paths.Add (Path2);
		Paths.Add (Path3);
		Paths.Add (Path4);

		peasant = new EnemyGroup ();
		peasant.prefab = peasantPrefab;

		peasant.countAdjustment = 5;

		peasant.startDelayMin.min = 0.5f;
		peasant.startDelayMin.max = 1.5f;

		peasant.startDelayMax.min = 1.6f;
		peasant.startDelayMax.max = 4.5f;

		peasant.betweenDelayMin.min = 0.1f;
		peasant.betweenDelayMin.max = 1.5f;

		peasant.betweenDelayMax.min = 1.6f;
		peasant.betweenDelayMax.max = 6.5f;

		dragon = new EnemyGroup ();
		dragon.prefab = dragonPrefab;
		
		dragon.countAdjustment = 1;
		
		dragon.startDelayMin.min = 0.5f;
		dragon.startDelayMin.max = 1.5f;
		
		dragon.startDelayMax.min = 1.6f;
		dragon.startDelayMax.max = 4.5f;
		
		dragon.betweenDelayMin.min = 0.1f;
		dragon.betweenDelayMin.max = 1.5f;
		
		dragon.betweenDelayMax.min = 1.6f;
		dragon.betweenDelayMax.max = 6.5f;
	}
	
	public void CreateArmy(int waveNum, EnemyGroup enemies, WaveOptions wave)
	{
		for (int x = 0; x < 4; x++) {
			//enemies.count = (int)(((waveNum + enemies.countAdjustment) / 2)  + (UnityEngine.Random.Range(waveNum, waveNum + enemies.countAdjustment))/1.5);
			enemies.count =1;
			enemies.path = Paths[x];
			GenerateWave(enemies,wave);
		}
	}
}


public class EnemyGroup
{
	//sound to play on wave start
	public GameObject prefab;

	public int count;

	public float countAdjustment;

	public PathManager path;

	public int HpOverride;

	public int ShieldOverride;

	public CustomRange startDelayMin;
	public CustomRange startDelayMax;

	public CustomRange betweenDelayMin;
	public CustomRange betweenDelayMax;

	public EnemyGroup()
	{
		prefab = null;
		count = 0;
		path = new PathManager ();
		HpOverride = 0;
		ShieldOverride = 0;
		startDelayMin = new CustomRange();
		startDelayMax = new CustomRange();
		betweenDelayMin = new CustomRange();
		betweenDelayMax = new CustomRange();
	}
}

public class CustomRange
{
	public float min;
	public float max;

	public CustomRange()
	{
		min = 0;
		max = 0;
	}
}