using System.Globalization;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System;

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
        try
        {
            FileStream f = new FileStream("BestScore.dat", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(f, System.Text.Encoding.Unicode);
            best = reader.ReadLine();
            reader.Close();
            f.Close();
        }
        catch (Exception)
        {
            best = "0.0";
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (canvas.enabled && !setCanvas && nowRecord.text != "")
        {
            float scoreNow = 0.0f;
            float scoreBest = 0.0f;
            try
            {
                 scoreBest = float.Parse(best, CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                scoreBest = 0f;
            }
            try
            {
                scoreNow = float.Parse(nowRecord.text, CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                scoreNow = 0f;
            }

            if (scoreNow > scoreBest)
            {
                scoreBest = scoreNow;
                best = scoreBest.ToString();
                FileStream f = new FileStream("BestScore.dat", FileMode.OpenOrCreate, FileAccess.Write);
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
