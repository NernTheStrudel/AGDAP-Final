﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireflySpawner : MonoBehaviour {

    public GameObject fireflies;
    public Camera cam;
    public float fireflyLife;

	// Use this for initialization
	void Start () {
		
	}

    private void OnMouseDown()
    {
        RaycastHit findLoc = new RaycastHit();

        float mouseX = Input.mousePosition.x;
        float mouseY = cam.pixelHeight - Input.mousePosition.y;
        Ray r = new Ray(cam.ScreenToWorldPoint(new Vector3(mouseX, mouseY, 1f)), cam.transform.forward);

        

        Physics.Raycast(r, out findLoc);
        Vector3 spawnPoint = findLoc.point;

        StartCoroutine(spawnFireflies(spawnPoint));
    }

    // Update is called once per frame
    void Update () {
		
	}

    public IEnumerator spawnFireflies(Vector3 pos)
    {
        GameObject firefliesInstance = Instantiate(fireflies, pos, Quaternion.identity);
        yield return new WaitForSeconds(fireflyLife);
        Destroy(firefliesInstance);
    }
}
