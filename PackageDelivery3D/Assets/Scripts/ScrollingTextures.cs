using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingTextures : MonoBehaviour
{
	[SerializeField] private Vector2 scroll = new Vector2(0.05f, 0.05f);
	private Vector2 offset = new Vector2(0f, 0f);

	private Renderer rend;

	private void Awake()
	{
		rend = GetComponent<Renderer>();
	}

	private void Update()
	{
		offset += scroll * Time.deltaTime;
		rend.material.SetTextureOffset("_MainTex", offset);
	}
}