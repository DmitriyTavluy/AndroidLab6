using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DetectClicks : MonoBehaviour
{
    public GameObject top, settings, store, m_cube, spawn_blocks;
    public Text playText, gameName, record;
    private bool clicked;

    void OnMouseDown()
    {
        if (!clicked) {
            clicked = true;
            playText.gameObject.SetActive(false);
            gameName.text = "0";
            record.gameObject.SetActive(true);
            top.gameObject.SetActive(false);
            settings.gameObject.SetActive(false);
            store.gameObject.SetActive(false);
            m_cube.GetComponent <Animation> ().Play ("StartGameCube");
            StartCoroutine (cubeToBlock ());
            spawn_blocks.GetComponent <SpawnBlocks> ().enabled = true;
        }

        IEnumerator cubeToBlock()
        {
            yield return new WaitForSeconds (1f);
            m_cube.AddComponent<Rigidbody>();
        }
    }

    
}

