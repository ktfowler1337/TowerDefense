/*  This file is part of the "3D Tower Defense Starter Kit" project by Rebound Games.
 *  You are only allowed to use these resources if you've bought them directly or indirectly
 *  from Rebound Games. You shall not license, sublicense, sell, resell, transfer, assign,
 *  distribute or otherwise make available to any third party the Service or the Content. 
 */

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

//custom wave editor window
public class WaveGen : MonoBehaviour
{
	[SerializeField]
	WaveManager waveScript;  //manager reference

	public GameObject enemyPreb;

	public PathManager Path1;

	public PathManager Path2;
	
	void Init()
	{

	}
	
	
	void Start()
	{
		GameObject wavesGO = GameObject.Find("Wave Manager");
		waveScript = wavesGO.GetComponent<WaveManager>();
		
		
		for (int x = 0; x < 10; x++) 
		{
			//create new wave option
			WaveOptions newWave = new WaveOptions();
			//initialize first row / creep of the new wave
			newWave.enemyPrefab.Add(enemyPreb);
			int enemyCount = (x + 10) + UnityEngine.Random.Range(1,10);
			newWave.enemyCount.Add(enemyCount);
			newWave.path.Add(Path1);
			newWave.enemyHP.Add(0);
			newWave.enemySH.Add(0);
			newWave.startDelayMin.Add(UnityEngine.Random.Range(0.5f,1.5f));
			newWave.startDelayMax.Add(UnityEngine.Random.Range(1.6f,4.5f));
			newWave.delayBetweenMin.Add(UnityEngine.Random.Range(0.1f,1.5f));
			newWave.delayBetweenMax.Add(UnityEngine.Random.Range(1.6f,6.5f));

			//initialize first row / creep of the new wave
			newWave.enemyPrefab.Add(enemyPreb);
			enemyCount = (x + 10) + UnityEngine.Random.Range(1,10);
			newWave.enemyCount.Add(enemyCount);
			newWave.path.Add(Path2);
			newWave.enemyHP.Add(0);
			newWave.enemySH.Add(0);
			newWave.startDelayMin.Add(UnityEngine.Random.Range(0.5f,1.5f));
			newWave.startDelayMax.Add(UnityEngine.Random.Range(1.6f,4.5f));
			newWave.delayBetweenMin.Add(UnityEngine.Random.Range(0.1f,1.5f));
			newWave.delayBetweenMax.Add(UnityEngine.Random.Range(1.6f,6.5f));
			//add new wave option to wave list
			waveScript.options.Add(newWave);
		}
		
	}
}