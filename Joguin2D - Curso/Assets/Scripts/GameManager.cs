using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using DG.Tweening;

public class GameManager : MonoBehaviour
{

    [Header("Player")]
    public GameObject playerPrefab;

    [Header("Enemies")]
    public List<GameObject> enemies;

    [Header("References")]
    public Transform startPoint;

    [Header("Animations")]
    public float duration = .2f;
    public float delay = .05f;
    public Ease ease = Ease.OutBack;


    private GameObject _currentPlayer;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        _currentPlayer = Instantiate(playerPrefab); //liga a variavel ao game object e permite criar ele em cena
        _currentPlayer.transform.position = startPoint.transform.position; //define a posição em que o objeto sera criado
        _currentPlayer.transform.DOScale(0, duration).SetEase(ease).From(); //detalha animação a tocar quando spawnado (crescendo de 0 [From 0] até a escala do prefab)
    }

}
