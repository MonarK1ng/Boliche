using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class cambiadorBrazos : MonoBehaviour {

    SteamVR_Events.Action renderModelLoadedAction;

    public GameObject manoIzda;
    public Transform mandoIzdo;

    public GameObject manoDcha;
    public Transform mandoDcho;

	// Use this for initialization
    void Awake()
    {
        renderModelLoadedAction = SteamVR_Events.RenderModelLoadedAction(OnRenderModelLoaded);
    }

    void Start () 
    {
        renderModelLoadedAction.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate()
    {
        if (mandoIzdo && manoIzda.activeSelf)
        {
            manoIzda.transform.position = mandoIzdo.position;
            manoIzda.transform.eulerAngles = mandoIzdo.eulerAngles;
        }
        if (mandoDcho && manoDcha.activeSelf)
        {
            manoDcha.transform.position = mandoDcho.position;
            manoDcha.transform.eulerAngles = mandoDcho.eulerAngles;
        }

        //if(mandoIzdo)
    }


    private void OnRenderModelLoaded( SteamVR_RenderModel renderModel, bool succeess )
    {
        Renderer[] renderers = renderModel.gameObject.GetComponentsInChildren<MeshRenderer>();
        foreach (Renderer renderer in renderers)
        {
            renderer.enabled = false;
        }

        print("OnRenderModelLoaded");
    }
}
