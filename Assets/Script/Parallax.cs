using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    [SerializeField] float rollingSpeed;

    private void Awake() {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update() {
        meshRenderer.material.mainTextureOffset += new Vector2(rollingSpeed * Time.deltaTime, 0);
    }
}
