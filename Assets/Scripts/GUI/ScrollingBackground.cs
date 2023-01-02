using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float Speed;

    [SerializeField] 
    private Renderer backgroundRenderer;

	private void Update()
	{
		backgroundRenderer.material.mainTextureOffset += new Vector2(Speed * Time.deltaTime, 0);
	}
}
