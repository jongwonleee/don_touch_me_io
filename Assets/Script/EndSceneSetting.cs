using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneSetting : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas canvas;
    public Text bestRecord;
    public Text nowRecord;

    private string best;
    private bool setCanvas = false;
    private TextAsset data;
    void Start()
    {
        //data = Resources.Load("Text/BestScore.txt", typeof(TextAsset)) as TextAsset;
        //StringReader sr = new StringReader(data.text);
        //if (best == null || best == "") best = "0.0";
        //best = sr.ReadLine();
        //if (data==null) best = "0.0";
        //else
        //{

        //}
        FileStream f = new FileStream("Assets/Resources/Text/BestScore.txt",FileMode.OpenOrCreate,FileAccess.Read);
        StreamReader reader = new StreamReader(f, System.Text.Encoding.Unicode);
        best = reader.ReadLine();

    }

    // Update is called once per frame
    void Update()
    {
        if (canvas.enabled && !setCanvas && nowRecord.text!="")
        {
            float scoreNow = float.Parse(nowRecord.text, CultureInfo.InvariantCulture);
            float scoreBest = float.Parse(best, CultureInfo.InvariantCulture);
            if (scoreNow > scoreBest)
            {
                scoreBest = scoreNow;
                best = scoreBest.ToString();
                FileStream f = new FileStream("Assets/Resources/Text/BestScore.txt", FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(f, System.Text.Encoding.Unicode);
                writer.WriteLine(best);
                writer.Close();
                f.Close();
            }
            Debug.Log(nowRecord.text + " " + best);
            bestRecord.text = best;
            setCanvas = true;
        }
        else if (!canvas.enabled && setCanvas)
        {
            setCanvas = false;
        }
    }
}
