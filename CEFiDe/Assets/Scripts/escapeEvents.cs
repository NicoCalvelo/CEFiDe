using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class escapeEvents : MonoBehaviour
{
    public Button showImg;
    public List<boleans> bools;

    [System.Serializable]
    public class boleans
    {
        public string nameOf;
        public bool state = false;
        public Button exitBut;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            onCallEscape();
        }
    }
    public void setBools(string name)
    {
        boleans bo = bools.Find(b => b.nameOf == name);
        bo.state = true;
    }
    public void onCallEscape()
    {
        boleans bo = bools.Find(b => b.state == true);
        if(bo != null)
        {
            bo.exitBut.onClick.Invoke();
            bo.state = false;
        }
        foreach(boleans b in bools)
        {
            b.state = false;
        }
    }
}
