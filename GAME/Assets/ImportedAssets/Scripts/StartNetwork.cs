using UnityEngine;
using System.Collections;

public class StartNetwork : MonoBehaviour {

	private const string typename = "OhSnap!";
	private const string gamename = "test";
	private HostData[] hostlist;
	public GameObject p2prefab;
	public GameObject p1;
	public GameObject p2;
	private NetworkViewID id;

	// Use this for initialization
	void StartServer() {
		Network.InitializeServer (2, 26000, !Network.HavePublicAddress());
		MasterServer.RegisterHost (typename, gamename);
	}

	void OnServerInitialized() {
		Debug.Log ("Server started!");
		id = Network.AllocateViewID ();
		p1.networkView.viewID = id;
	}

	private void RefreshHostList() {
		MasterServer.RequestHostList (typename);
	}

	void OnMasterServerEvent(MasterServerEvent msEvent) {
		if (msEvent == MasterServerEvent.HostListReceived) {
			hostlist = MasterServer.PollHostList();
		}
	}

	private void JoinServer(HostData hostData) {
		Network.Connect (hostData);
	}

	void OnConnectedToServer() {
		Debug.Log ("Server joined");
		id = Network.AllocateViewID ();
		p2.networkView.viewID = id;
	}

	private void SpawnPlayer() {
		Network.Instantiate (p2prefab, new Vector3 (0, 0.27f, 0), Quaternion.identity, 0);
	}

	void OnGUI()
	{
		if (!Network.isClient && !Network.isServer)
		{
			if (GUI.Button(new Rect(100, 100, 250, 100), "Start Server"))
				StartServer();
			
			if (GUI.Button(new Rect(100, 250, 250, 100), "Refresh Hosts"))
				RefreshHostList();
			
			if (hostlist != null)
			{
				for (int i = 0; i < hostlist.Length; i++)
				{
					if (GUI.Button(new Rect(400, 100 + (110 * i), 300, 100), hostlist[i].gameName))
						JoinServer(hostlist[i]);
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
