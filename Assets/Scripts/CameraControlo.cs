using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlo : MonoBehaviour
{
    [SerializeField] private Transform Jogador;

    private void Update()
    {
        transform.position = new Vector3(Jogador.position.x, Jogador.position.y, transform.position.z);
    }
}
