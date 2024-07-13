using UnityEngine;
using Labyrint;
using System;
using Unity.VisualScripting;

public class MainScriptGame : MonoBehaviour {
    public GameObject PlayerGameObject;
    public GameObject RoomGameObject;
    protected GameObject[][] Rooms;

    const int width = 5;
    const int height = 2;
    const int shift = 13;
    const int shiftLooping = 1;

    public void Start() {
        Scheme schem = new Scheme(width, height);
        System.Random rnd = new System.Random(Guid.NewGuid().GetHashCode());
        Debug.Log(schem.log());

        Cell[][] data = schem.getCells();
        this.Rooms = new GameObject[data.Length][];
        for (int h = 0; h < data.Length; h++)
        {
            this.Rooms[h] = new GameObject[data[h].Length];
            for (int w = 0; w < data[h].Length; w++)
            {
                Rooms[h][w] = Instantiate(this.RoomGameObject, new Vector3(shift * w, 0f, shift * -h), Quaternion.Euler(0, 0, 0));
            }
        }

        ScriptRoom SR;
        for (int h = 0; h < data.Length; h++)
        {
            for (int w = 0; w < data[h].Length; w++)
            {
                SR = Rooms[h][w].GetComponent<ScriptRoom>();
                if (data[h][w].up) SR.CreatePortal(Rooms[h-1][w], this.PlayerGameObject, ScriptRoom.up);
                if (data[h][w].rt) SR.CreatePortal(Rooms[h][w+1], this.PlayerGameObject, ScriptRoom.rt);
                if (data[h][w].dw) SR.CreatePortal(Rooms[h+1][w], this.PlayerGameObject, ScriptRoom.dw);
                if (data[h][w].lt) SR.CreatePortal(Rooms[h][w-1], this.PlayerGameObject, ScriptRoom.lt);

                if (w == 0) { SR.CreatePortal(Rooms[this.looping(MainScriptGame.height, h + MainScriptGame.shiftLooping)][MainScriptGame.width - 1], this.PlayerGameObject, ScriptRoom.lt); }
                if (w == MainScriptGame.width - 1) { SR.CreatePortal(Rooms[this.looping(MainScriptGame.height, h + MainScriptGame.shiftLooping)][0], this.PlayerGameObject, ScriptRoom.rt); }
                if (h == 0) { SR.CreatePortal(Rooms[MainScriptGame.height - 1][this.looping(MainScriptGame.width, w + MainScriptGame.shiftLooping)], this.PlayerGameObject, ScriptRoom.up); }
                if (h == MainScriptGame.height - 1) { SR.CreatePortal(Rooms[0][this.looping(MainScriptGame.width, w + MainScriptGame.shiftLooping)], this.PlayerGameObject, ScriptRoom.dw); }
            }
        }
    }

    protected int looping(int maxNumber, int number)
    {
        return number - maxNumber * (int)Math.Floor(number / (decimal)maxNumber);
    }
}
